using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterGenerator : Photon.MonoBehaviour
{
    public GameObject[] _monsterPrefabs;
    public Transform[] _genPoints;
    public float _genDelayTime;
    public GameObject _spawnEffectPrefab;

	// void Start()
	// {
	// 	StartCoroutine(MonsterGenCoroutine());
	// }

    IEnumerator MonsterGenCoroutine()
    {
        while (true)
        {
            int pointNum = Random.Range(0, _genPoints.Length);

            if (_genPoints[pointNum].childCount > 0)
            {
                yield return null;
                continue;
            }

            Instantiate(_spawnEffectPrefab, _genPoints[pointNum].position, Quaternion.identity);

        	GameObject monster = PhotonNetwork.Instantiate("Spider"+Random.Range(0, _monsterPrefabs.Length),  _genPoints[pointNum].position, _genPoints[pointNum].rotation, 0);
            monster.transform.SetParent(_genPoints[pointNum]);
            yield return new WaitForSeconds(_genDelayTime);
        }
    }
}
