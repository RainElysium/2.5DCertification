using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.addPoint();
            Destroy(this.gameObject);
        }
    }
}
