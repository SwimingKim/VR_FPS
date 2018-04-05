using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraManager : MonoBehaviour {

	[SerializeField] Transform camera;
	// [SerializeField] Transform character;

	public bool IsRun { set; get; }
	float speed;

	void Awake()
	{
		IsRun = false;
		speed = 2f;
	}

	void Update () {
		if (!IsRun) return;
		
		RaycastHit hit;
		Vector3 forwardDir = camera.transform.TransformDirection(Vector3.forward);
		forwardDir.y = 0.0f;
		if (Physics.Raycast(transform.position, forwardDir, out hit, 1.0f)) {
			return;
		}

		transform.position += forwardDir * speed * Time.deltaTime;
		// character.position += forwardDir * speed * Time.deltaTime;
	}
}
