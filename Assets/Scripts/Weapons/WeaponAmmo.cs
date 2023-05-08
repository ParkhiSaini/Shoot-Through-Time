using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    
    public int extraAmmo;
    public int currentAmmo;
    
    public TextMeshProUGUI Ammotext;

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;
    }

    void Update() {
        Ammotext.text=currentAmmo.ToString()+ " / " + extraAmmo.ToString();
    }
    
    public void Reload()
    {
        if (extraAmmo >= clipSize)
        {
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
        
    }
}
