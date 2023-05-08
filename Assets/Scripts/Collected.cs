using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    public int collectibleCount;
    public TextMeshProUGUI collectText;
    public TextMeshProUGUI GameOvercollectText;
    public TextMeshProUGUI WincollectText;
    
    void Update()
    {
        GetComponent<AudioSource>();
        collectText.text = collectibleCount.ToString();
        GameOvercollectText.text = collectibleCount.ToString();
        WincollectText.text = collectibleCount.ToString();
        

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Collectible"))
        {
            collectibleCount+=1;
            
            Destroy(other.gameObject);
            if (collectibleCount == 3)
            {
                Debug.Log("3/3 objects collected");
            }
        }
    }
}
