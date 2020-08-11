using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    IMovement movement;
    IJump jump;
    IFlip flip;
    public GameObject movementType;
    public GameObject jumpType;
    public GameObject flipType;
    Rigidbody mainRigidbody;

    public enum State
    {
        Grounded,
        Jump,
        InAir,
        Flip
    }
    public enum MoveState
    {
        Idle,
        Left,
        Right
    }

    public State _state;
    MoveState _moveState;

    private void Start ()
    {
        movement = movementType.GetComponent<IMovement> ();
        jump = jumpType.GetComponent<IJump> ();
        flip = flipType.GetComponent<IFlip> ();
        mainRigidbody = GetComponent<Rigidbody> ();
        _state = State.Grounded;
        _moveState = MoveState.Idle;
    }

    private void Update ()
    {
        if (Input.GetAxisRaw ("Horizontal") > 0)
            _moveState = MoveState.Right;
        else
        if (Input.GetAxisRaw ("Horizontal") < 0)
            _moveState = MoveState.Left;
        else
            _moveState = MoveState.Idle;
        if (Input.GetKeyDown (KeyCode.Space))
            if (_state == State.InAir)
                _state = State.Flip;
        if (Input.GetKeyDown (KeyCode.Space))
            if (_state == State.Grounded)
                _state = State.Jump;

        DoMove (_moveState);
        DoAction (_state);
    }
    protected void DoAction (State state)
    {

        switch (state)
        {
            case State.Grounded:
                break;
            case State.Jump:
                jump.DoJump (mainRigidbody);
                _state = State.InAir;
                break;
            case State.Flip:
                flip.DoFlip (mainRigidbody);
                break;
        }
    }
    protected void DoMove (MoveState state)
    {

        switch (state)
        {
            case MoveState.Idle:
                break;
            case MoveState.Left:
                movement.DoMove (mainRigidbody, -1);
                break;
            case MoveState.Right:
                movement.DoMove (mainRigidbody, 1);
                break;
        }
    }
    private void OnCollisionEnter (Collision collision)
    {

        if (_state != State.Grounded)
            if (collision.gameObject.tag == "Floor")
                _state = State.Grounded;

    }
}