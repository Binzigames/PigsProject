namespace Scripts.Core.Characters
{
    public interface IPlayerState
    {
        public void Enter();
        public void Execute();
        public void Exit();
    }
}