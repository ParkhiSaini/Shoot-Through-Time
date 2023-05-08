using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform Player;

     void LateUpdate() {
        Vector3 newPosition = Player.position;
        newPosition.y=transform.position.y;
        transform.position= newPosition;

        transform.rotation= Quaternion.Euler(90f,Player.eulerAngles.y, 0f);
        


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
