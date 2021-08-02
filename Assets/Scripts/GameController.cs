using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private GameEvent gameCompleted;
    [SerializeField]
    private GameEvent gameFailed;
    
    public static GameController Instance;

    private bool _hasGameStart;
    private bool _hasCompleted;
    private bool _hasFailed;
    private bool _hasCompletedTrick;
    private bool _hasFailedTrick;
    private bool _hasGameEnded;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameStart()
    {
        _hasGameStart = true;
    }

    public void GameCompleted()
    {
        _hasCompleted = true;
        if (!_hasFailed)
        {
            if (!_hasCompletedTrick)
            {
                gameCompleted.Raise();
                _hasGameEnded = true;
                _hasCompletedTrick = true;
            }
        }
    }
    
    public void GameFailed()
    {
        _hasFailed = true;
        if (!_hasCompleted)
        {
            if (!_hasFailedTrick)
            {
                gameFailed.Raise();
                _hasGameEnded = true;
                _hasFailedTrick = true;
            }
        }
    }

    public bool GetGameStartState()
    {
        return _hasGameStart;
    }

    public bool GetGameEndedState()
    {
        return _hasGameEnded;
    }
}
