using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

	[SerializeField] CCameraManager cameraManager;
	[SerializeField] CCharacterManager characterManager;

	public bool IsOnMagent { set; get; }

	void Awake()
	{
		IsOnMagent = false;
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			cameraManager.IsRun = !cameraManager.IsRun;
			bool isRun = cameraManager.IsRun;
			if (isRun) {
				characterManager._anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.WALK);
			}
			else {
				characterManager._anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.IDLE);
			}
			Debug.Log("!!");
		}
		
	}
}
