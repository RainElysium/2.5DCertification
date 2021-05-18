using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    private float _speed = 1.0f;
    [SerializeField]
    private Vector3 _waypointA, _waypointB;
    private int _waypointNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        _waypointA = this.transform.position;
        _waypointB = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
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
