using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuManager : MonoBehaviour  
{
    // public AudioSource source;
    public void LoadGame()
    {
        SceneManager.LoadScene(2);

    }

    public void exit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     source.Play();
    // }
}
