using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupMsgManager : MonoBehaviour
{
    public static PopupMsgManager instance;
    public Text popupText;
    public float displayTime = 3f;

    private GameObject Panel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Panel = popupText.transform.parent.parent.gameObject;
    }

    public void ShowPopupMessage(string message)
    {
        Panel.SetActive(true);
        popupText.text = (message);
        StartCoroutine(HideMessageAfterDelay());

    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        popupText.text = "";
        Panel.SetActive(false);
    }
}
