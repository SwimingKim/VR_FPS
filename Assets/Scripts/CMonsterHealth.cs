using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMonsterHealth : CHealth {

	public ParticleSystem _pcSystem;

	CMonsterMovement _movement;
	CMonsterFSM _fsm;

	protected override void Awake()
	{
		base.Awake();
		_movement = GetComponent<CMonsterMovement>();
		_fsm = GetComponent<CMonsterFSM>();
	}

	protected override void Damage()
	{
		if (_fsm._state == CAnimation.STATE.DIE) return;

		if (!_pcSystem.isPlaying)
		{
			_pcSystem.Play();
		}

		_hpProgress.fillAmount -= 0.3f;

		_hp = (int) (_hpProgress.fillAmount * 100f);
		if (_hp <= 0)
		{
			photonView.RPC("Die", PhotonTargets.All, photonView.ownerId);
		}
	}

	public void Die()
	{
        // _gameManager.MonsterDieCountUp();

        photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DIE, photonView.ownerId);
		_movement.Stop();
		_fsm._state = CAnimation.STATE.DIE;
		Destroy(gameObject, 3f);
	}

}
