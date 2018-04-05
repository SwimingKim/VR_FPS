using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterManager : MonoBehaviour {

	public CCharacterAnimation _anim;
	// Vector3 initPos;

	void Start () {
		_anim = GetComponent<CCharacterAnimation>();
	}

}
