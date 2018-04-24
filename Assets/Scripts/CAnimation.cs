using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimation : MonoBehaviour {

	protected Animator _animator;
	public enum STATE { IDLE, WALK, ATTACK, DAMAGE, DIE }

	protected virtual void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public virtual void PlayAnimation(STATE state)
	{

	}

}
