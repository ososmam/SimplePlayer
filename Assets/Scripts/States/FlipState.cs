using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipState : State
{
    public FlipState (Player player) : base (player)
    {

        stateID = StateID.Flip;
    }

    public override void Tick ()
    {
        player.flip.Do (player);

    }
}