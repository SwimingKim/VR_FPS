using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCanvasSize : MonoBehaviour {

	void Start()
	{
		RectTransform rt = GetComponent<RectTransform>();
		#if UNITY_ANDROID && !UNITY_EDITOR
		rt.sizeDelta = new Vector2(1920, 1450);
		#endif		
	}

}
