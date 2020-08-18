using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : State
{
    public InAirState (Player player) : base (player)
    {

        stateID = StateID.InAir;
    }
    public override void OnStateEnter ()
    { }
    public override void Tick ()
    {
        Debug.Log ("InAir");
    }
}