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

    protected override void UpdatePlayerState(int count)
    {
        if (_fsm._state == CAnimation.STATE.DIE) return;

        if (!_pcSystem.isPlaying)
        {
            _pcSystem.Play();
        }

        _hp -= count;
		UpdateHealthCount();

        if (_hp <= 0)
        {
            _movement.Stop();
            _fsm._state = CAnimation.STATE.DIE;
            photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DIE, photonView.ownerId);

            Invoke("Die", 3f);
        }
    }

	protected override void UpdateHealthCount()
	{
        float percentage = (float)(_hp * 0.2);
        _hpProgress.fillAmount = percentage;
	}

}
