using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class PlayerUI1 : MonoBehaviour
{
    public Text IdText;


    private void Start()
    {
        IdText.text = GameManager.Instance.UserID;
    }
}
