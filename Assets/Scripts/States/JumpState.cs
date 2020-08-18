using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{

    public JumpState (Player player) : base (player)
    {

        stateID = StateID.Jump;
    }

    public override void Tick ()
    {
        player.jump.Do (player);
        player.SetState (StateID.InAir);

    }
}