using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterAnimation : MonoBehaviour
{

    public enum ANIM_TYPE
    {
        IDLE, WALK, ATTACK, DAMAGE, DIE
    }
    public ANIM_TYPE _animType = ANIM_TYPE.IDLE;
    public bool IsDie = false;

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
                _animator.SetFloat("Speed", 0f);
                break;
            case ANIM_TYPE.WALK:
                _animator.SetFloat("Speed", 0.4f);
                break;
            case ANIM_TYPE.ATTACK:
                _animator.SetTrigger("Attack");
                break;
            case ANIM_TYPE.DAMAGE:
                _animator.SetTrigger("Damage");
                break;
            case ANIM_TYPE.DIE:
                IsDie = true;
                _animator.SetTrigger("Death");
                break;
        }
    }

}
