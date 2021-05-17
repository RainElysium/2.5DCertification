using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypointAGob, _waypointBGob;
    private Vector3 _waypointA, _waypointB;
    private int _waypointNumber = 1;
    private CharacterController _controller;

    private float _speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _waypointA = _waypointAGob.transform.position;
        _waypointB = _waypointBGob.transform.position;

        _waypointAGob.transform.parent = null;
        _waypointBGob.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == _waypointA)
            _waypointNumber = 1;

        else if (transform.position == _waypointB)
            _waypointNumber = 2;


        if (_waypointNumber == 1)
            transform.position = Vector3.MoveTowards(transform.position, _waypointB, _speed * Time.deltaTime);
        else if (_waypointNumber == 2)
            transform.position = Vector3.MoveTowards(transform.position, _waypointA, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided!");
        if (other.CompareTag("Player"))
        {
            _controller = other.GetComponent<CharacterController>();
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }

    }
}
