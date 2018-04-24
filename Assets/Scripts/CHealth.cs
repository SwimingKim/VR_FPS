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
        UpdateHealthCount();
    }

    public virtual void Damage()
    {
		UpdatePlayerState(Random.Range(5, 8));
    }

    protected virtual void UpdateHealthCount()
    {

    }

	protected virtual void UpdatePlayerState(int count)
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
