using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterManager : MonoBehaviour {

	public CCharacterAnimation _anim;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<CCharacterAnimation>();
	}

	
}
