using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CParticleDestoyer : MonoBehaviour {

	// 파티클 시스템
	ParticleSystem _particleSystem;

	void Awake()
	{
		_particleSystem = GetComponentInChildren<ParticleSystem>();
	}

	void Start () {

		// 파티클이 재생중이 아니면 재생함
		if (!_particleSystem.isPlaying)
		{
			_particleSystem.Play();
		}

		// 파티클 재생 시간 뒤에 현재 오브젝트를 제거함
		Destroy(gameObject, _particleSystem.main.duration);
		
	}
	
}
