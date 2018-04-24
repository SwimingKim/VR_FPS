using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterAnimation : CAnimation {

	CMonsterFSM _fsm;

	protected override void Awake()
	{
		base.Awake();
		_fsm = GetComponent<CMonsterFSM>();
	}

    public override void PlayAnimation(STATE state)
	{
		switch (state)
		{
			case CAnimation.STATE.IDLE :
				_animator.SetBool("Walk", false);
				_animator.SetBool("Attack", false);
				break;
			case CAnimation.STATE.WALK :
				_animator.SetBool("Walk", true);
				_animator.SetBool("Attack", false);
				break;
			case CAnimation.STATE.ATTACK :
				_animator.SetBool("Walk", false);
				_animator.SetBool("Attack", true);
				break;
			case CAnimation.STATE.DIE :
				_animator.SetTrigger("Death");
				break;
		}
	}

	
}
