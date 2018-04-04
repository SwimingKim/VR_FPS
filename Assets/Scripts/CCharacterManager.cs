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
	// 	Vector3 targetCamPos = Camera.main.transform.position + _offset;
	// 	transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);
	// }

	
}
