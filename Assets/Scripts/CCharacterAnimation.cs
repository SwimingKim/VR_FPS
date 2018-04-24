using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterAnimation : CAnimation
{
    public STATE _state = STATE.IDLE;
    public bool IsDie = false;
    public float _animSpeed;

    protected override void Awake()
    {
        base.Awake();
        _animator.speed = _animSpeed;
    }

    public override void PlayAnimation(STATE state)
    {
        _state = state;

        switch (state)
        {
            case STATE.IDLE:
                _animator.SetFloat("Speed", 0f);
                break;
            case STATE.WALK:
                _animator.SetFloat("Speed", 0.4f);
                break;
            case STATE.ATTACK:
                _animator.SetTrigger("Attack");
                break;
            case STATE.DAMAGE:
                _animator.SetTrigger("Damage");
                break;
            case STATE.DIE:
                IsDie = true;
                _animator.SetTrigger("Death");
                break;
        }
    }

}
