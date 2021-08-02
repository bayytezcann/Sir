using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Events")] 
    public GameEvent gameStart;
    public ScoreVariable scoreVariable;
    
    [Header("Canvas")] 
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject successPanel;
    public GameObject failedPanel;

    [Header("Text")] [SerializeField] 
    private TMP_Text scoreTMPText;
    
    public static UIController Instance;

    private bool _hasGameStart;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartPanelOpen();
    }

    public void StartPanelOpen()
    {
        startPanel.gameObject.SetActive(true);
        startPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.3f);
    }

    public void StartPanelOpenWithTime(float waitTime)
    {
        Invoke("StartPanelOpen", waitTime);
    }
    
    public void StartPanelClose()
    {
        if (!_hasGameStart)
        {
            startPanel.gameObject.SetActive(false);
            gameStart.Raise();
            GameController.Instance.GameStart();
            _hasGameStart = true;
        }
    }

    public void GamePanelOpen()
    {
        gamePanel.gameObject.SetActive(true);
        gamePanel.GetComponent<CanvasGroup>().DOFade(1f, 0.3f);
    }
    
    public void GamePanelClose()
    {
        gamePanel.gameObject.SetActive(false);
    }

    public void CompletedPanelOpen(float waitTime)
    {
        Invoke("CompletedPanelOpenTime", waitTime);
    }
    
    private void CompletedPanelOpenTime()
    {
        scoreTMPText.text = "Score : " + scoreVariable.Score;
        successPanel.gameObject.SetActive(true);
        successPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.3f);
    }

    public void FailedPanelOpenTime(float waitTime)
    {
        Invoke("FailedPanelOpen", waitTime);
    }

    private void FailedPanelOpen()
    {
        failedPanel.gameObject.SetActive(true);
        failedPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.3f);
    }

    public void RestartScene()
    {
        ScoreController.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        ScoreController.Instance.ResetScore();
    }
}
