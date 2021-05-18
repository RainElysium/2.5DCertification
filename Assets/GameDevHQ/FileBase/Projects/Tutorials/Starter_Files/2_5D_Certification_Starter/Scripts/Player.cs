using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    private float _climbSpeed = 2.0f;
    [SerializeField]
    private float _jumpHeight = 15f;
    [SerializeField]
    private float _gravity = 0.5f;
    [SerializeField]
    private Vector3 _direction, _velocity, _ladderPOS;
    private float _yVelocity;
    private Animator _anim;
    private bool _jumping = false;
    [SerializeField]
    private bool _climbLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (!_controller)
            Debug.LogError("No controller founder");

        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.enabled)
            CalculateMovement();

        if (_anim.GetBool("LedgeGrab"))
            if (Input.GetKeyDown(KeyCode.E))
                _anim.SetTrigger("ClimbUp");

        if (_climbLadder)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 4.23f, transform.position.z), _climbSpeed * Time.deltaTime);

            if (transform.position.y >= _ladderPOS.y + 8.86f)
            {
                _climbLadder = false;
                _anim.SetBool("ReachedTopOfLadder", true);
            }
        }

    }
    void CalculateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.D))
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKeyDown(KeyCode.A))
                transform.rotation = Quaternion.Euler(0, -180, 0);

            _direction = new Vector3(0, 0, horizontal);
            _velocity = _direction * _speed;
            _anim.SetFloat("Speed", Mathf.Abs(horizontal));

            if (_jumping)
            {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _jumping = true;
                _anim.SetBool("Jumping", _jumping);
            }
        }
        else
            _yVelocity -= _gravity;

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void GrabLedge(Vector3 handPos)
    {
        transform.position = handPos;

        _anim.SetBool("LedgeGrab", true);
        _anim.SetFloat("Speed", 0.0f);
        _anim.SetBool("Jumping", false);
        _controller.enabled = false;
    }

    public void GrabLadder(Vector3 handPos)
    {
        transform.position = handPos;
        _ladderPOS = handPos;

        _anim.SetTrigger("ClimbLadder");
        _anim.SetFloat("Speed", 0.0f);
        _anim.SetBool("Jumping", false);
        _controller.enabled = false;

        _climbLadder = true;
    }


    public void StandUp()
    {
        var playerPosition = transform.position;

        if (playerPosition == null)
            Debug.Log("No position found");

        if (_climbLadder)
        {
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 8.89f, playerPosition.z + 1.0f);
            _climbLadder = false;
        }
        else
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 8.31f, playerPosition.z);
        
        _controller.enabled = true;
    }
}

