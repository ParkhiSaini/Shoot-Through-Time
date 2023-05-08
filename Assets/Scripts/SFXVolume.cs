using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolume : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
			Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
        
    }

    // Update is called once per frame
    public void UpdateVolume (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
		}
}
