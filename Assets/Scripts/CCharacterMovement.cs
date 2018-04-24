using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterMovement : Photon.MonoBehaviour
{
    public CCameraManager cameraManager;
    CCharacterAnimation _anim;

    void Awake()
    {
        _anim = GetComponent<CCharacterAnimation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (photonView.isMine)
				photonView.RPC("Move", PhotonTargets.All, photonView.viewID);
        }
    }

    [PunRPC]
    void Move(int viewId)
    {
        cameraManager.IsRun = !cameraManager.IsRun;
        _anim.PlayAnimation(cameraManager.IsRun ? CAnimation.STATE.WALK : CAnimation.STATE.IDLE);
    }

}
