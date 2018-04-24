using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterFSM : Photon.MonoBehaviour
{
    public CAnimation.STATE _state = CAnimation.STATE.IDLE;

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
        while (_state != CAnimation.STATE.DIE)
        {
            if (_attack._attackTarget == null)
            {
                _state = CAnimation.STATE.IDLE;
                yield return null;
                continue;
            }

            float dist = _attack.GetAttackTargetDistance();
            if (dist <= _attackDist)
            {
                _state = CAnimation.STATE.ATTACK;
            }
            else if (dist <= _traceDist)
            {
                _state = CAnimation.STATE.WALK;
            }
            else
            {
                _state = CAnimation.STATE.IDLE;
            }
            yield return null;
        }
    }

    IEnumerator MonsterDoActionCoroutine()
    {
        while (_state != CAnimation.STATE.DIE)
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
            case CAnimation.STATE.IDLE:
                _movement.Stop();
                _anim.PlayAnimation(CAnimation.STATE.IDLE);
                break;
            case CAnimation.STATE.ATTACK:
                transform.LookAt(_attack._attackTarget.transform);
                _movement.Stop();
                _anim.PlayAnimation(CAnimation.STATE.ATTACK);
                break;
            case CAnimation.STATE.WALK:
                _anim.PlayAnimation(CAnimation.STATE.WALK);
                _movement.Trace(_attack._attackTarget);
                break;
        }
    }



}
