using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterManager : Photon.MonoBehaviour
{
    public string playerName { set; get; }
    public Text _nameText;

    void Start()
    {
        playerName = photonView.owner.name;
        _nameText.text = playerName;

        GetComponentInChildren<Camera>().enabled = photonView.isMine;
        GetComponentInChildren<AudioListener>().enabled = photonView.isMine;
    }

}
