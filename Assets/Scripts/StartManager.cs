using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("Membership")]
    public GameObject MembershipUI;
    public InputField MemberShipID;
    public InputField MemberShipPW;
    public InputField MemberShipFind;

    [Header("Login")]
    public GameObject LoginUI;
    public InputField LoginID;
    public InputField LoginPW;

    [Header("Find")]
    public GameObject FindUI;
    public InputField FindFind;

    [Header("ErrorMessage")]
    public GameObject ErrorUI;
    public Text ErrorMessage;

    public void Membershipbtn()
    {
        PlayerPrefs.SetString("ID", MemberShipID.text);
        PlayerPrefs.SetString("PW", MemberShipPW.text);
        PlayerPrefs.SetString("FIND", MemberShipFind.text);
        MembershipUI.SetActive(false);
        Debug.Log($"���ԿϷ� ID :{PlayerPrefs.GetString("ID")}, PW:{PlayerPrefs.GetString("PW")}, FIND:{PlayerPrefs.GetString("FIND")}");
    }
    public void LoginBtn()
    {
        if (PlayerPrefs.GetString("ID") != LoginID.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "���̵� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != LoginPW.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }

        SceneManager.LoadScene("SelectScene");
    }

    void ErrorMessageExit()
    {
        ErrorUI.SetActive(false);
    }


    private void Update()
    {
        //Debug.Log("ID : " + PlayerPrefs.GetString("ID"));
        //Debug.Log("PW : " + PlayerPrefs.GetString("PW"));
        //Debug.Log("FIND : " + PlayerPrefs.GetString("FIND"));
    }
    public void FindBtn()
    {
        FindUI.SetActive(false);
        ErrorUI.SetActive(true);
        if (PlayerPrefs.GetString("FIND") == FindFind.text)
        {
            ErrorMessage.text = $"ID : {PlayerPrefs.GetString("ID")}\nPW : {PlayerPrefs.GetString("PW")}";
        }
        else
        {
            ErrorMessage.text = "�߸� �� ��Ʈ�Դϴ�.";
        }
        Invoke("ErrorMessageExit", 3f);
    }
}
