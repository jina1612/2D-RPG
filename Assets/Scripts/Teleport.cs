using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player; // �ڷ���Ʈ�� ĳ���� ������Ʈ
    public Vector3 teleportLocation; // �ڷ���Ʈ�� ��ġ

    void Update()
    {
        // 'T' Ű�� ������ �� �ڷ���Ʈ ����
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




