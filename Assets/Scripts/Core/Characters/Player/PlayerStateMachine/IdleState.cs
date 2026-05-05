namespace Scripts.Core.Characters
{
    public class IdleState : IPlayerState
    {
        private PlayerAnimation _playerAnimation;

        public IdleState(PlayerAnimation playerAnimation)
        {
            _playerAnimation = playerAnimation;
        }

        public void Enter()
        {
            _playerAnimation.SetRunAnimation(false);
            _playerAnimation.SetLoseAnimation(false);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }

    }
}