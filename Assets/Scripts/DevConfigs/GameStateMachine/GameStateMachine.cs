using System;
using UnityEngine;

namespace DevConfigs.GameStateMachine
{
    public class GameStateMachine
    {
        public IGameState CurrentState { get; private set; }
        // public FactoryGameState factoryGameState;
        public event Action<IGameState> OnChangeState;

        public GameStateMachine()
        {
            // factoryGameState = new FactoryGameState();
        }

        public void Initialize(IGameState gameState)
        {
            CurrentState = gameState;
            gameState.Enter();
            OnChangeState?.Invoke(gameState);

            Debug.Log(CurrentState);
        }
        public void TransitionTo(IGameState gameState)
        {
            if (CurrentState == gameState)
                return;

            CurrentState.Exit();
            CurrentState = gameState;
            gameState.Enter();
            OnChangeState?.Invoke(gameState);

            Debug.Log(CurrentState);
        }
        public void Execute() // each per frame
        {
            CurrentState?.Execute();
        }
    }
}