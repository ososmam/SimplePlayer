public enum StateID
{
    NullStateID,
    Grounded,
    Jump,
    InAir,
    Flip,
    Duck,
    Dash,
    Attack
}
public abstract class State
{
    protected Player player;
    protected StateID stateID;
    public StateID ID { get { return stateID; } }
    public abstract void Tick ();

    public virtual void OnStateEnter () { }
    public virtual void OnStateExit () { }

    public State (Player player)
    {
        this.player = player;
    }
}