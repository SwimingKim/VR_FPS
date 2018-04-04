using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamerMovement : MonoBehaviour {

	public Transform target;
	public float dist = 10.0f;
	public float height = 5.0f;
	public float dampRotate = 5.0f;

	private Transform transform;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
	}

	void LateUpdate()
	{
		float currYAngle = Mathf.LerpAngle(transform.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);
		Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

		transform.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
		transform.LookAt(target);
	}
	
}
