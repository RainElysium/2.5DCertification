using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{

    Vector3 _ledgeGrabPos = new Vector3(-0.52f, 69.69f, 123.52f);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.tag);
        if (other.CompareTag("Ledge_Grab_Checker"))
        {
            Debug.Log("Collided /w ledge grab checker!");

            var player = other.GetComponentInParent<Player>();

            if (player)
                player.GrabLedge(_ledgeGrabPos);
        }
    }
}
