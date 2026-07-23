
namespace DevConfigs.GameStateMachine
{
    public abstract class GameState
    {
        public virtual void Enter() { }
        public virtual void Execute() { }
        public virtual void Exit() { }
    }
}