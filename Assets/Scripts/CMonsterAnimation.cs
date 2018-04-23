using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterAnimation : MonoBehaviour {

	Animator _animator;
	CMonsterFSM _fsm;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_fsm = GetComponent<CMonsterFSM>();
	}

	public void PlayAnimation(CMonsterFSM.STATE state)
	{
		switch (state)
		{
			case CMonsterFSM.STATE.IDLE :
				_animator.SetBool("Walk", false);
				_animator.SetBool("Attack", false);
				break;
			case CMonsterFSM.STATE.TRACE :
				_animator.SetBool("Walk", true);
				_animator.SetBool("Attack", false);
				break;
			case CMonsterFSM.STATE.ATTACK :
				_animator.SetBool("Walk", false);
				_animator.SetBool("Attack", true);
				break;
			case CMonsterFSM.STATE.DIE :
				_animator.SetTrigger("Death");
				break;
		}
	}

	
}
