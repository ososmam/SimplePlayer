using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckState : State
{
    public DuckState (Player player) : base (player)
    {

        stateID = StateID.Duck;
    }

    public override void OnStateEnter ()
    {
    }
    public override void Tick ()
    {
        player.duck.Do (player);
        player.SetState (StateID.Grounded);

    }
}