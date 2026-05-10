using Scripts.Patterns;
using UnityEngine;

public class EndGameCommand : ICommand
{
    private const int STOP_GAME_TIME = 0;
    public EndGameCommand()
    {
        
    }

    public void Execute()
    {
        Time.timeScale = STOP_GAME_TIME;
        
    }
}
