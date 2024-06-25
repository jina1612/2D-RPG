using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    public GameObject DialogujeUI;

    private GameObject playerObj;
    private float distance;

    public GameObject[] DialogueTextobj;
    private int dIndex = 0;


    private void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
       

        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        if (distance <= 3)
            DialogujeUI.SetActive(true);
        else
            DialogujeUI.SetActive(false);

    }


    public void NextBtn(string name)
    {
        DialogueTextobj[dIndex].SetActive(false);
        if(name == "Next")
        {
            if (dIndex < DialogueTextobj.Length - 1) dIndex++;
        }
        else if (name == "Prev")
        {
            if (dIndex > 0) dIndex--;
        }
        DialogueTextobj[dIndex].SetActive(true);
    }

    public void TownBtn()
    {
        SceneManager.LoadScene("TownScene");
    }
}
     


