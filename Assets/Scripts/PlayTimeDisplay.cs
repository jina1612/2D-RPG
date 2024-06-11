using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeDisplay : MonoBehaviour
{
    public Text playTimeText; // UI �ؽ�Ʈ ������Ʈ
    private float playTime; // ��� �ð�

    void Start()
    {
        playTime = 0f; // ��� �ð��� 0���� �ʱ�ȭ
    }

    void Update()
    {
        playTime += Time.deltaTime; // �����Ӹ��� ��� �ð��� ����

        // ��� �ð��� ��, ��, �ʷ� ��ȯ
        int hours = Mathf.FloorToInt(playTime / 3600f);
        int minutes = Mathf.FloorToInt((playTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);

        // ��� �ð��� "HH:MM:SS" �������� ǥ��
         playTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
