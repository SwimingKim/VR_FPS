using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterShot : Photon.MonoBehaviour
{
    public float _shootDelayTime;
    float _timer;

    CCharacterAnimation _anim;

    public Transform _shotPos;
    public Text _shotText;
    public float _shotPower;
    public AudioClip _shotEffect;
    AudioSource _audioSource;
    int _killCount;

    void Awake()
    {
        _anim = GetComponent<CCharacterAnimation>();
        _audioSource = GetComponent<AudioSource>();

        // if (PhotonNetwork.connected)
        // {
        //     photonView.owner.SetScore(0);
        // }
    }

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            _timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift) && _timer >= _shootDelayTime && Time.timeScale != 0)
            {
                photonView.RPC("Shot", PhotonTargets.All, _shotPos.position, _shotPos.forward, transform.rotation, photonView.viewID);
            }
        }

        _shotText.text = photonView.owner.GetScore().ToString() + "마리 Kill";
    }

    [PunRPC]
    public void Shot(Vector3 pos, Vector3 forward, Quaternion qt, int viewId)
    {
        if (_anim.IsDie) return;

        _timer = 0f;

        _audioSource.PlayOneShot(_shotEffect, 0.1f);
        _anim.PlayAnimation(CAnimation.STATE.ATTACK);

        GameObject bullet = PhotonNetwork.Instantiate("Bullet", pos, qt, 0);
        bullet.GetComponentInChildren<Rigidbody>().velocity = forward * _shotPower;
        bullet.GetComponentInChildren<CBullet>()._ownerId = photonView.ownerId;
        Destroy(bullet, 0.5f);
    }

}
