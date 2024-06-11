using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player; // 텔레포트할 캐릭터 오브젝트
    public Vector3 teleportLocation; // 텔레포트할 위치

    void Update()
    {
        // 'T' 키를 눌렀을 때 텔레포트 실행
        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport();
        }
    }

    void 
        Teleport()
    {
        if (player != null)
        {
            player.transform.position = teleportLocation;
        }
        else
        {
            Debug.LogWarning("Player object is not assigned.");
        }
    }
}




