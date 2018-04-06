using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterManager : MonoBehaviour {

	public CCharacterAnimation _anim;
	// Vector3 initPos;

	void Start () {
		_anim = GetComponent<CCharacterAnimation>();
	}

	// void Update()
	// {
	// 	if (Input.GetKeyDown(KeyCode.Space))
	// 	{
	// 		_anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.JUMP);
	// 	}
	// }

}
