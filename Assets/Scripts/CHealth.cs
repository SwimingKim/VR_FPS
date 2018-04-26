using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHealth : Photon.MonoBehaviour
{
    protected CAnimation _animation;

    public Image _hpProgress;

    protected virtual void Awake()
    {
        _animation = GetComponent<CAnimation>();
    }

    public virtual void Damage(int viewId)
    {
    }

    [PunRPC]
    public void PlayStateAnimation(CAnimation.STATE state, int viewId)
    {
        _animation.PlayAnimation(state);
    }

    [PunRPC]
    protected void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }

}
