using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCanvasSize : MonoBehaviour
{
    void Awake()
    {
        RectTransform rt = GetComponent<RectTransform>();
#if UNITY_ANDROID && !UNITY_EDITOR
		rt.sizeDelta = new Vector2(1920, 1450);
#endif

        if (PhotonNetwork.connected && !GetComponentInParent<PhotonView>().isMine)
        {
            gameObject.SetActive(false);
        }
    }

}
