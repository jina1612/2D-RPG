using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Infor")]
    public Text NameTxt;
    public Text FeatureTxt;
    public Image CharImage;

    [Header("Character")]
    public GameObject[] Characters; //Warrior, Archer, Mage
    public CharacterInfo[] CharacterInfos;
    private int charIndex = 0;

    [Header("GameStart")]
    public GameObject GameStart;
    public Text GameCountTxt;
    private bool isPlayButtonClicked = false;
    private float gameCount = 5f;

    private void Update()
    {
        if (isPlayButtonClicked)
        {
            gameCount -= Time.deltaTime;
            if (gameCount <= 0 )
            {
                SceneManager.LoadScene("MainScene");
            }
            GameCountTxt.text = $"곧 게임이 시작됩니다. \n {gameCount:F1}";
        }
    }


    public void PlayBtn()
    {
        GameStart.SetActive(true);
        isPlayButtonClicked = true;
        GameManager.Instance.CharacterName = CharacterInfos[charIndex].Name;
    }

    private void Start()
    {
        SetPanelInfo();
    }

    public void SelectCharacterBtn(string btnName)
    {
        Characters[charIndex].SetActive(false);
        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % Characters.Length;
        }

        if (btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % Characters.Length;
            charIndex = charIndex < 0 ? charIndex + Characters.Length : charIndex;
        }

        Debug.Log($"CharIndex : {charIndex}");
        Characters[charIndex].SetActive(true);

        SetPanelInfo();
    }

    private void SetPanelInfo()
    {
        NameTxt.text = CharacterInfos[charIndex].Name;
        FeatureTxt.text = CharacterInfos[charIndex].Feature;
        CharImage.sprite = Characters[charIndex].GetComponent<SpriteRenderer>().sprite;
    }
}
