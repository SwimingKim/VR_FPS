using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHealth : Photon.MonoBehaviour
{
    CAnimation _animation;

    public int _hp;
    public Image _hpProgress;

    protected virtual void Awake()
    {
        _animation = GetComponent<CAnimation>();
    }

    protected virtual void Damage()
    {

    }

	[PunRPC]
    public void PlayStateAnimation(CAnimation.STATE state, int viewId)
    {
		_animation.PlayAnimation(state);
    }

}
