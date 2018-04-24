using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spider")
        {
            other.SendMessage("Damage");
        }
        else
        {
            PhotonView.Destroy(gameObject);
        }
    }
}
