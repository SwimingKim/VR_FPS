using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CMonsterMovement : MonoBehaviour
{

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

    public void Trace(GameObject target)
    {
        _navMeshAgent.SetDestination(target.transform.position);
        _navMeshAgent.isStopped = false;
    }

}
