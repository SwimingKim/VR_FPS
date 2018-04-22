using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterMovement : Photon.MonoBehaviour
{
    public Transform _camera;
	public Vector3 _pos;
    public CCharacterAnimation _anim;

    bool IsRun { set; get; }
    float speed;

    void Awake()
    {
        speed = 2f;
        _anim = GetComponent<CCharacterAnimation>();
    }

	void Start()
	{
		if (photonView.isMine)
		{
			transform.SetParent(Camera.main.transform);
			transform.localPosition = _pos;
			transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
		}
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
        IsRun = !IsRun;
        _anim.PlayAnimation( IsRun ? CCharacterAnimation.ANIM_TYPE.WALK : CCharacterAnimation.ANIM_TYPE.IDLE );
        // manager.playerManager.PlayMotion(manager.cameraManager.IsRun);
		// manager.cameraManager.IsRun = !manager.cameraManager.IsRun;
    }

}
