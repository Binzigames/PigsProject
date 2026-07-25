using System;
using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class GameStateMachine
    {
        public GameState CurrentState { get; private set; }
        public event Action<GameState> OnChangeState;


        public void Initialize(GameState gameState)
        {
            CurrentState = gameState;
            gameState.Enter();
            OnChangeState?.Invoke(gameState);
        }
        public void TransitionTo(GameState gameState)
        {
            if (CurrentState == gameState)
                return;

            CurrentState.Exit();
            CurrentState = gameState;
            gameState.Enter();
            OnChangeState?.Invoke(gameState);

            Debug.Log(CurrentState);
        }
        public void Execute()
        {
            CurrentState?.Execute();
        }
    }
}