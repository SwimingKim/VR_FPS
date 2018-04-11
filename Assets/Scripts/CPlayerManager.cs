using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerManager : MonoBehaviour
{
	public string playerName { set; get; }
	public Vector3 _pos;

    CCharacterAnimation _anim;

    public void initPlayerPrefab()
    {
        GameObject localPlyer = PhotonNetwork.Instantiate("Sci-fi Soldier", Vector3.zero, Quaternion.identity, 0);
        localPlyer.transform.SetParent(Camera.main.transform);
        localPlyer.transform.localPosition = _pos;

		playerName = PhotonNetwork.playerName;

		localPlyer.GetComponentInChildren<Text>().text = playerName;
        _anim = localPlyer.GetComponent<CCharacterAnimation>();
    }

    public void PlayMotion(bool b)
    {
        _anim.PlayAnimation(b ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE);
    }

}
