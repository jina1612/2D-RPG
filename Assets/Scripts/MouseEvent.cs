using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject Potion_UI;
    private void Update()
    {
        MouseClick();
    }


    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.name == "PowerNPC")
                {
                    Debug.Log("Power NPC ����");
                }
                else if (hit.collider.gameObject.name == "PotionNPC")
                {
                    Potion_UI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNPC")
                {
                    Debug.Log("Battle NPC ����");
                }
            }
        }
    }
}
