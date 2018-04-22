using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterManager : MonoBehaviour {

	public string playerName { set; get; }
	public Text _nameText;

	void Start () {
		playerName = PhotonNetwork.playerName;
		_nameText.text = playerName;
	}

}
