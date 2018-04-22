using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerManager : MonoBehaviour
{
	public string playerName { set; get; }
	public Vector3 _pos;

    GameObject localPlyer;
    CCharacterAnimation _anim;
    
    public void initPlayerPrefab()
    {
        localPlyer = PhotonNetwork.Instantiate("PlayerControl", Vector3.zero, Quaternion.identity, 0);
        // localPlyer.transform.SetParent(Camera.main.transform);
        // localPlyer.transform.localPosition = _pos;
        // localPlyer.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

		playerName = PhotonNetwork.playerName;

		localPlyer.GetComponentInChildren<Text>().text = playerName;
        _anim = localPlyer.GetComponent<CCharacterAnimation>();
    }

    public void PlayMotion(bool b)
    {
        _anim.PlayAnimation(b ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE);
    }

}
