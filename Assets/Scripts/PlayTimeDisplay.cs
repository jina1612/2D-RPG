using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeDisplay : MonoBehaviour
{
    public Text playTimeText; // UI 텍스트 오브젝트
    private float playTime; // 경과 시간

    void Start()
    {
        playTime = 0f; // 경과 시간을 0으로 초기화
    }

    void Update()
    {
        playTime += Time.deltaTime; // 프레임마다 경과 시간을 누적

        // 경과 시간을 시, 분, 초로 변환
        int hours = Mathf.FloorToInt(playTime / 3600f);
        int minutes = Mathf.FloorToInt((playTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);

        // 경과 시간을 "HH:MM:SS" 형식으로 표시
         playTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
