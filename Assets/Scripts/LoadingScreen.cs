using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadingScreen : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;
    public float delayTime = 7.0f; // Minimum time to display the loading screen

    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        yield return new WaitForSeconds(delayTime); // Wait for the minimum time before loading the next scene

        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1); // Load the next scene asynchronously

        while (gameLevel.progress < 1)
        {
            loadingBar.value = gameLevel.progress;
            loadingText.text = "Loading: " + (gameLevel.progress * 100) + "%";
            yield return null;
        }
    }
}
