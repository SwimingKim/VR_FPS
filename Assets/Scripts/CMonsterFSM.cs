using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterFSM : Photon.MonoBehaviour
{
    public enum STATE { IDLE, TRACE, ATTACK, DIE }
    public STATE _state = STATE.IDLE;

    CMonsterMovement _movement;
    CMonsterAnimation _anim;
    CMonsterAttack _attack;

    public float _attackDist;
    public float _traceDist;

    void Awake()
    {
        _movement = GetComponent<CMonsterMovement>();
        _anim = GetComponent<CMonsterAnimation>();
        _attack = GetComponent<CMonsterAttack>();
    }

    void Start()
    {
        StartCoroutine("MonsterCheckFSMCoroutine");
        StartCoroutine("MonsterDoActionCoroutine");
    }

    IEnumerator MonsterCheckFSMCoroutine()
    {
        while (_state != STATE.DIE)
        {
            if (_attack._attackTarget == null)
            {
                _state = CMonsterFSM.STATE.IDLE;
                yield return null;
                continue;
            }

            float dist = _attack.GetAttackTargetDistance();
            if (dist <= _attackDist)
            {
                _state = CMonsterFSM.STATE.ATTACK;
            }
            else if (dist <= _traceDist)
            {
                _state = CMonsterFSM.STATE.TRACE;
            }
            else
            {
                _state = CMonsterFSM.STATE.IDLE;
            }
            yield return null;
        }
    }

    IEnumerator MonsterDoActionCoroutine()
    {
        while (_state != STATE.DIE)
        {
            photonView.RPC("MonsterDoAction", PhotonTargets.All, photonView.ownerId);
            yield return null;
        }
    }

    [PunRPC]
    void MonsterDoAction(int viewId)
    {
        switch (_state)
        {
            case CMonsterFSM.STATE.IDLE:
                _movement.Stop();
                _anim.PlayAnimation(CMonsterFSM.STATE.IDLE);
                break;
            case CMonsterFSM.STATE.ATTACK:
                transform.LookAt(_attack._attackTarget.transform);
                _movement.Stop();
                _anim.PlayAnimation(CMonsterFSM.STATE.ATTACK);
                break;
            case CMonsterFSM.STATE.TRACE:
                _anim.PlayAnimation(CMonsterFSM.STATE.TRACE);
                _movement.Trace(_attack._attackTarget);
                break;
        }
    }



}
