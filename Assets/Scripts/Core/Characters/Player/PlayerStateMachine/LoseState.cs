using UnityEngine;

namespace Scripts.Core.Characters
{
    public class LoseState : IPlayerState
    {
        private PlayerAnimation _playerAnimation;

        public LoseState(PlayerAnimation playerAnimation)
        {
            _playerAnimation = playerAnimation;
        }
        
        public void Enter()
        {
            _playerAnimation.SetLoseAnimation(true);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            _playerAnimation.SetLoseAnimation(false);
        }

    }
}