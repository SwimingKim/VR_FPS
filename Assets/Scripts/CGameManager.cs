using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

	[SerializeField] CCameraManager cameraManager;
	[SerializeField] CCharacterManager characterManager;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W))
		{
			cameraManager.IsRun = !cameraManager.IsRun;
			characterManager._anim.PlayAnimation( cameraManager.IsRun ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE );
		}
		
	}
}
