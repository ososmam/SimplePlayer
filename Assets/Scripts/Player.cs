using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IMovement movement;
    public IJump jump;
    public IFlip flip;
    public IDuck duck;
    public IDash dash;
    public IAttack attack;
    public GameObject movementType;
    public GameObject jumpType;
    public GameObject flipType;
    public GameObject duckType;
    public GameObject dashType;
    public GameObject attackType;
    public Rigidbody mainRigidbody;

    public int superDashCharge;
    private StateSystem sm;

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
        duck = duckType.GetComponent<IDuck> ();
        dash = dashType.GetComponent<IDash> ();
        attack = attackType.GetComponent<IAttack> ();
        mainRigidbody = GetComponent<Rigidbody> ();
        _moveState = MoveState.Idle;
        CreateStateMachine (this);
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
            if (sm.CurrentStateID == StateID.InAir)
                SetState (StateID.Flip);

        if (Input.GetKeyDown (KeyCode.Space))
            if (sm.CurrentStateID == StateID.Grounded)
                SetState (StateID.Jump);

        if (Input.GetKeyDown (KeyCode.DownArrow))
        {

            if (sm.CurrentStateID == StateID.InAir)
            {
                SetState (StateID.Attack);
            }
        }

        if (Input.GetKey (KeyCode.DownArrow))
        {
            if (sm.CurrentStateID == StateID.Grounded)
            {
                SetState (StateID.Duck);
            }
        }

        if (sm.CurrentStateID == StateID.Duck)
        {
            if (Input.GetKeyDown (KeyCode.LeftAlt))
            {
                superDashCharge++;
            }
        }
        else superDashCharge = 0;

        if (superDashCharge == 5)
        {
            SetState (StateID.Dash);
        }

        sm.CurrentState.Tick ();
        DoMove (_moveState);
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
        if (sm.CurrentStateID != StateID.Grounded)
            if (collision.gameObject.tag == "Floor")
                SetState (StateID.Grounded);

    }
    public void SetState (StateID id)
    {
        sm.SetState (id);
    }
    public void CreateStateMachine (Player player)
    {
        sm = new StateSystem ();
        sm.AddState (new GroundState (player));
        sm.AddState (new JumpState (player));
        sm.AddState (new InAirState (player));
        sm.AddState (new FlipState (player));
        sm.AddState (new DashState (player));
        sm.AddState (new DuckState (player));
        sm.AddState (new AttackState (player));
    }
}