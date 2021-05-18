using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.y > 55.0f)
            transform.position = new Vector3(_player.transform.position.x + 20f, _player.transform.position.y + 8.0f, _player.transform.position.z + 7.0f);
        else
            transform.position = new Vector3(_player.transform.position.x + 20f, _player.transform.position.y + 8.0f, _player.transform.position.z - 7.0f);
    }
}
