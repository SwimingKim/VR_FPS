using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID
using UnityEngine.VR;
#endif

public class CCameraMovement : MonoBehaviour {

	Transform _transform;
	public Text _text;

	// Use this for initialization
	void Start () {
		Debug.Log("hihi");
		
		_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		float value = _transform.rotation.y;
		if ( Mathf.Abs( value ) > 10 )
		{
			Debug.Log("!!");
			transform.localRotation = Quaternion.Euler( _transform.rotation.x, value, _transform.rotation.z );
		}


		// Quaternion crtRot = GvrVRHelpers.GetHeadRotation();
		// _text.text = crtRot.ToString();
		// Debug.Log(crtRot.ToString());
		
	}
}
