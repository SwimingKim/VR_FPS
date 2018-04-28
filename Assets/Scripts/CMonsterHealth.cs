using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMonsterHealth : CHealth
{
    public ParticleSystem _pcSystem;

    CMonsterMovement _movement;
    CMonsterFSM _fsm;

    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponent<CMonsterMovement>();
        _fsm = GetComponent<CMonsterFSM>();
    }

    public override void Damage(int viewId)
    {
        if (_fsm._state == CAnimation.STATE.DIE) return;

        if (!_pcSystem.isPlaying)
        {
            _pcSystem.Play();
        }

        float power = (float)(Random.Range(30, 40) * 0.01);
        _hpProgress.fillAmount -= power;
        if (_hpProgress.fillAmount <= 0)
        {
            if (PhotonNetwork.player.ID == viewId)
            {
                PhotonNetwork.player.AddScore(1);
            }

            _movement.Stop();
            _fsm._state = CAnimation.STATE.DIE;
            photonView.RPC("PlayStateAnimation", PhotonTargets.AllViaServer, CAnimation.STATE.DIE);

            Invoke("MonsterDie", 3f);
        }
    }

    void MonsterDie()
    {
        photonView.RPC("Die", PhotonTargets.AllViaServer);
    }

}
