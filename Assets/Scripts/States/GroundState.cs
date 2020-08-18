using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : State
{

    public GroundState (Player player) : base (player)
    {

        stateID = StateID.Grounded;
    }
    
    public override void Tick ()
    {
        Debug.Log ("Grounded");
    }
}