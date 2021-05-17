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
        transform.position = new Vector3(_player.transform.position.x + 15.0f, _player.transform.position.y + 7.0f, _player.transform.position.z + 5.0f);

    }
}
