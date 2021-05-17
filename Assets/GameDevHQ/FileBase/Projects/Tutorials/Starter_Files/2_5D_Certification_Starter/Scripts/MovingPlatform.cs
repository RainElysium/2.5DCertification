using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypointAGob, _waypointBGob;
    private Vector3 _waypointA, _waypointB;
    private int _waypointNumber = 1;

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
    void Update()
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
}
