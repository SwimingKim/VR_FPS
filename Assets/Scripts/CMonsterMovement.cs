using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CMonsterMovement : MonoBehaviour {

	NavMeshAgent _navMeshAgent;

	void Awake()
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		Stop();	
	}

	public void Stop()
	{
		_navMeshAgent.isStopped = true;
	}

	public void Trace()
	{
		Vector3 pos = new Vector3(1, 0, -40);
		// _navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
		_navMeshAgent.SetDestination(pos);
		_navMeshAgent.isStopped = false;
	}

}
