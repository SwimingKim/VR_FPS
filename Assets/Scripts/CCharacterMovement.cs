using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterMovement : Photon.MonoBehaviour
{
    public Transform _camera;
    
    CCharacterAnimation _anim;
    CCameraManager cameraManager;

    Vector3 currPos = Vector3.zero;
    Quaternion currRot = Quaternion.identity;

    void Awake()
    {
        _anim = GetComponent<CCharacterAnimation>();
        cameraManager = GameObject.FindWithTag("Control").GetComponent<CCameraManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (photonView.isMine)
				photonView.RPC("Move", PhotonTargets.All, photonView.viewID);
        }

        if (photonView.isMine)
        {

        }
        else
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            transform.position = Vector3.Lerp(pos, currPos, Time.deltaTime*3.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, currRot, Time.deltaTime*3.0f);
        }
    }

    [PunRPC]
    void Move(int viewId)
    {
        cameraManager.IsRun = !cameraManager.IsRun;
        _anim.PlayAnimation( cameraManager.IsRun ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE );
        // manager.playerManager.PlayMotion(manager.cameraManager.IsRun);
		// manager.cameraManager.IsRun = !manager.cameraManager.IsRun;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(cameraManager.transform.position);
            stream.SendNext(cameraManager.transform.rotation);
        }
        else
        {
            currPos = (Vector3) stream.ReceiveNext();
            currRot = (Quaternion) stream.ReceiveNext();
        }
    }

}
