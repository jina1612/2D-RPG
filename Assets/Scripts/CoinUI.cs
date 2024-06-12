using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinText; // UI Text 요소

    void Start()
    {
        UpdateCoinText(); // 초기화 시 코인 개수를 업데이트
    }

    // 코인 개수를 UI Text에 표시하는 함수
    public void UpdateCoinText()
    {
        //coinText.text = "Coins: " + PlayerCoinCollector.coinCount.ToString(); // 코인 개수 업데이트
    }
}
