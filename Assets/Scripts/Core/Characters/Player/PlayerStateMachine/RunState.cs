namespace Scripts.Core.Characters
{
    public class RunState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerAnimation _playerAnimation;

        public RunState(Player player, PlayerAnimation playerAnimation)
        {
            _player = player;
            _playerAnimation = playerAnimation;
        }

        public void Enter()
        {
            _playerAnimation.SetRunAnimation(true);
        }

        public void Execute()
        {
            if (_player.IsCrashed)
            {
                var loseState = _player.PlayerStateMachine.LoseState;
                _player.PlayerStateMachine.TransitionTo(loseState);
            }

        }

        public void Exit()
        {
            _playerAnimation.SetRunAnimation(false);
        }

    }
}