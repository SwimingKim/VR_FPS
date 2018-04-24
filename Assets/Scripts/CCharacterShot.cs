using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterShot : Photon.MonoBehaviour
{
    public float _shootDelayTime;
    float _timer;

    CCharacterAnimation _anim;

    public GameObject _bulletPrefab;
    public Transform _shotPos;
    public float _shotPower;
    public AudioClip _shotEffect;
    AudioSource _audioSource;

    void Awake()
    {
        _anim = GetComponent<CCharacterAnimation>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
		if (photonView.isMine) {
	        _timer += Time.deltaTime;

			if (Input.GetKeyDown(KeyCode.LeftShift) && _timer >= _shootDelayTime && Time.timeScale != 0)
			{
				photonView.RPC("Shot", PhotonTargets.All, _shotPos.position, _shotPos.forward, transform.rotation, photonView.viewID);
			}
		} 
    }

    [PunRPC]
    public void Shot(Vector3 pos, Vector3 forward, Quaternion qt, int viewId)
    {
        if (_anim.IsDie) return;

        _timer = 0f;

        _audioSource.PlayOneShot(_shotEffect, 0.1f);
        _anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.ATTACK);

        GameObject bullet = Instantiate(_bulletPrefab, pos, qt);
        bullet.GetComponentInChildren<Rigidbody>().velocity = forward * _shotPower;
        Destroy(bullet, 0.5f);
    }

}
