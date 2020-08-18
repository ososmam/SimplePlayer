using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public DashState (Player player) : base (player)
    {
        stateID = StateID.Dash;
    }

    public override void OnStateEnter ()
    {
        player.superDashCharge = 0;
    }
    public override void Tick ()
    {
        player.dash.Do (player);
        player.SetState (StateID.Grounded);
    }
}