using System;
using DevConfigs.GameStateMachine;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{   
    private GameStateMachine _gameStateMachine;
    public GameStateMachine GameStateMachine => _gameStateMachine;

    private void Awake()
    {
        _gameStateMachine = new GameStateMachine();

        var menuState = _gameStateMachine.factoryGameState.GetGameState(GameStateType.MenuState);
        _gameStateMachine.Initialize(menuState);
    }
}
