using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    public int _ownerId { set; get; }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spider")
        {
            other.SendMessage("Damage", _ownerId);
        }
        else
        {
            PhotonView.Destroy(gameObject);
        }
    }
}
