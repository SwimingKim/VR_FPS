using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterAttack : MonoBehaviour {

	[HideInInspector]
	public GameObject _attackTarget;
	
	public Transform _attackPoint;
	public float _attackRange;

	void Start () {
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		float dist = Vector3.Distance(players[0].transform.position, transform.position);
		foreach (var player in players)
		{
			float playerDist = Vector3.Distance(player.transform.position, transform.position);
			if (playerDist <= dist)
			{
				dist = playerDist;
				_attackTarget = player;
			}
		}
	}

	public float GetAttackTargetDistance()
	{
		float dist = Vector3.Distance(
			_attackTarget.transform.position, transform.position
		);
		return dist;
	}
	
	public void Attack()
	{
		Collider[] hitColliders = Physics.OverlapSphere(_attackPoint.position, _attackRange, 1 << LayerMask.NameToLayer("Player"));
		if (hitColliders.Length <= 0) return;
		hitColliders[0].transform.GetChild(0).SendMessage("Damage", -1);
	}

}
