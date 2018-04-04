using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterAnimation : MonoBehaviour {

	public enum ANIM_TYPE
	{
		IDLE, WALK, JUMP, ATTACK, DIE 
	}
	public ANIM_TYPE _animType = ANIM_TYPE.IDLE;

	private Animator _animator;
	public float _animSpeed;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_animator.speed = _animSpeed;
	}

	public void PlayAnimation(ANIM_TYPE animType)
	{
		_animType = animType;

		switch (animType)
		{
			case ANIM_TYPE.IDLE:
				_animator.SetBool("Move", false);
				break;
			case ANIM_TYPE.WALK:
				_animator.SetBool("Move", true);
				break;
			case ANIM_TYPE.JUMP:
				_animator.SetTrigger("Jump");
				break;
			case ANIM_TYPE.ATTACK:
				_animator.SetBool("Animing", true);
				_animator.SetTrigger("Attack");
				break;
		}
	}

	public void setSpeedValue(float value)
	{
		_animator.SetFloat("Speed", value);
	}

	public float getSpeedValue()
	{
		return _animator.GetFloat("Speed");
	}

}
