

public class PlayerStateMachine
{
    public IPlayerState CurrentState { get; private set;}

    public IdleState _idleState;
    public RunState _runState;
    public LoseState _loseState;

    public PlayerStateMachine()
    {
        _idleState = new IdleState();
        _runState = new RunState();
        _loseState = new LoseState();
    }

    public void Initialize(IPlayerState playerState)
    {
        CurrentState = playerState;
        playerState.Enter();
    }

    public void TransitionTo(IPlayerState playerState)
    {
        CurrentState.Exit();
        CurrentState = playerState;
        playerState.Enter();
    }

    public void Execute()
    {
        CurrentState?.Execute();
    }
}
