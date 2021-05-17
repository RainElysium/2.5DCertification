using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftActivator : MonoBehaviour
{
    private float _speed = 4.0f;
    private bool _activateLift = false;
    [SerializeField]
    private bool _doOnce = true;
    [SerializeField]
    private bool _wait = true;
    [SerializeField]
    private int _floor;
    [SerializeField]
    private GameObject _lift, _liftBottom, _liftTop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");

            if (CompareTag("Lift_Activator_Top"))
            {
                var _player = GameObject.Find("Player").GetComponent<Player>();
                _player.transform.parent = _lift.transform;
                _activateLift = true;
            }

        }
    }

    private void Update()
    {
        if (_activateLift)
        {
            if (_lift.transform.position == _liftBottom.transform.position && _doOnce)
            {
                _floor = 1;
                StartCoroutine(LiftWait());
            }
            else if (_lift.transform.position == _liftTop.transform.position && _doOnce)
            {
                _floor = 2;
                StartCoroutine(LiftWait());
            }

            if (!_wait)
            {

                if (_floor == 2)
                    _lift.transform.position = Vector3.MoveTowards(_lift.transform.position, _liftBottom.transform.position, _speed * Time.deltaTime);
                else if (_floor == 1)
                    _lift.transform.position = Vector3.MoveTowards(_lift.transform.position, _liftTop.transform.position, _speed * Time.deltaTime);
            }
        }
    }

    IEnumerator LiftWait()
    {
        Debug.Log("CoRoutine hit");

        _doOnce = false;
        _wait = true;
        yield return new WaitForSeconds(5.0f);
        _wait = false;
        yield return new WaitForSeconds(1.0f);
        _doOnce = true;
    }
}
