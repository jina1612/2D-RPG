using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinText; // UI Text ���

    void Start()
    {
        UpdateCoinText(); // �ʱ�ȭ �� ���� ������ ������Ʈ
    }

    // ���� ������ UI Text�� ǥ���ϴ� �Լ�
    public void UpdateCoinText()
    {
        //coinText.text = "Coins: " + PlayerCoinCollector.coinCount.ToString(); // ���� ���� ������Ʈ
    }
}
