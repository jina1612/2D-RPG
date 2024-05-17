using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Infor")]
    public Text NameTxt;
    public Text FeatureTxt;
    public Text CharImage;

    [Header("Character")]
    public GameObject[] Characters; //Warrior, Archer, Mage
    private int charIndex = 0;

    public void SelectCharacterBtn(string btnName)
    {
        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % Characters.Length;
        }

        if (btnName == "Prev")
        {
            charIndex ++;
            charIndex = charIndex % Characters.Length;
        }
        if (btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % Characters.Length;
        }

        Debug.Log($"CharIndex : {charIndex}");
    }
}
