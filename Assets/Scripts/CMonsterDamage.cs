using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMonsterDamage : Photon.MonoBehaviour {

	public int _hp;
	public Image _hpProgress;

	public ParticleSystem _pcSystem;

	CMonsterMovement _movement;
	CMonsterFSM _fsm;
	CMonsterAnimation _animator;

	void Awake()
	{
		_movement = GetComponent<CMonsterMovement>();
		_fsm = GetComponent<CMonsterFSM>();
		_animator = GetComponent<CMonsterAnimation>();
	}

	[PunRPC]
	public void Damage(int viewId)
	{
		if (_fsm._state == CMonsterFSM.STATE.DIE) return;

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

	[PunRPC]
	public void Die(int viewId)
	{
		// _gameManager.MonsterDieCountUp();

		_animator.PlayAnimation(CMonsterFSM.STATE.DIE);
		_movement.Stop(); // 이동 중지
		_fsm._state = CMonsterFSM.STATE.DIE;
		Destroy(gameObject, 3f);
	}



}
