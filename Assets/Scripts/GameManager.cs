using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // public TextMeshProUGUI timeText;
    public GameObject pausePanel;
    public float gameTime;
    public bool isPaused=false;
    public GameObject objectivePanel;
    private bool isPanelActive;
    public GameObject player; // player object 
    public float countdownTime = 3f;
    private bool isCountdownActive = true;
    public TextMeshProUGUI Countdowntext;
    public GameObject CountdownPanel;
    

    public GameObject WinPanel;

    
    public GameObject wavemanagerobj;
    WaveManager wavemanager;
    Collected collected;

    void Start()
    {
         wavemanager=wavemanagerobj.GetComponent<WaveManager>();
        collected = player.GetComponent<Collected>();
        objectivePanel.SetActive(false);
        isPanelActive = false;

        gameTime=0f;
        UpdateTime();

        // Start the countdown coroutine
        StartCoroutine(CountdownCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused=!isPaused;
            pausePanel.SetActive(isPaused);
            Time.timeScale=isPaused?0f:1f;
        }

        if (!isPaused && !isCountdownActive)
        {
            gameTime+=Time.deltaTime;
            UpdateTime();
        }

        CheckObjectives();
    }

    private void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        // timeText.text = "Time: " + minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

    public void OnObjectiveButtonClick()
    {
        objectivePanel.SetActive(true);
        isPanelActive = true;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPanelActive)
        {
            if (eventData.pointerCurrentRaycast.gameObject == null || eventData.pointerCurrentRaycast.gameObject.tag != "ObjectivePanel")
            {
                objectivePanel.SetActive(false);
                isPanelActive = false;
            }
        }
    }

    //main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Countdown coroutine function
    IEnumerator CountdownCoroutine()
    {
        // Disable player movement during countdown
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        CountdownPanel.SetActive(true);


        // Display countdown text
        for (int i = 3; i >= 1; i--)
        {
            Countdowntext.text =  i.ToString();
            yield return new WaitForSeconds(1f);
        }

        CountdownPanel.SetActive(false);
        // Enable player movement after countdown
        characterController.enabled = true;
        isCountdownActive = false;
        // timeText.text = "Time: 00:00";
    }

    public void CheckObjectives()
    {
        if (wavemanager.kills==10 && collected.collectibleCount==3 && wavemanager.currentWave==wavemanager.maxWaves)
        {
            Debug.Log("You win");
            WinPanel.SetActive(true);
        }
        
    }
}
