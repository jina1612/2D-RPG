using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;

    private void Start()
    {
        
    }

    void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 2.7f, -10);
        }
    }
}
