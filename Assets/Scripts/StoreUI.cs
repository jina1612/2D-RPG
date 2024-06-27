using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image[] ItemImages;
    public Text[] ItemTexts;
    public InventoryItemData[] ItemDatas;

    private void Start()
    {
        for (int i = 0; i < ItemDatas.Length; i++)
        {
            ItemImages[i].sprite = ItemDatas[i].itemImage;
            ItemTexts[i].text = $"{ItemDatas[i].itemName} ({ItemDatas[i].itemPrice:N0}P)";
        }
    }
}
