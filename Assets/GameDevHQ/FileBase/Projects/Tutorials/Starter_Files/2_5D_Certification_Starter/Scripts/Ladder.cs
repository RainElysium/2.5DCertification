using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    private Vector3 _collisionPoint;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided with number: " + collision.contactCount);
    //    _collisionPoint = collision.GetContact(1).point;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder_Grab_Checker"))
        {
            _collisionPoint = new Vector3(0f, 43.11f, 43.84f);
            var player = other.GetComponentInParent<Player>();

            //if (player.transform.parent != null)
            //    player.transform.parent = null;

            if (player)
                player.GrabLadder(_collisionPoint);
        }
    }
}
