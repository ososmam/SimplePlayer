using UnityEngine;

public class AttackState : State
{
    public AttackState (Player player) : base (player)
    {
        stateID = StateID.Attack;
    }
    public override void Tick ()
    {
        player.attack.Do ();
        player.SetState(StateID.Grounded);
    }
}