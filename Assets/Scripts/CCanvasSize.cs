using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCanvasSize : MonoBehaviour {

	void Start()
	{
		RectTransform rt = GetComponent<RectTransform>();
		#if UNITY_ANDROID
		rt.sizeDelta = new Vector2(1920, 1450);
		#elif UNITY_EDITOR || UNITY_WEBGL
		rt.sizeDelta = new Vector2(1920, 1080);
		#endif		
		Debug.Log(rt.rect.height);

	}

}
