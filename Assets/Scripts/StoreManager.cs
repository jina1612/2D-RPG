using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryItemData[] items;
    public GameObject Purchase_UI;
    public Image ItemImage;
    public Text ItemNameText;
    public Text ItemCoinText;
    public Text ItemExplainText;

    private Dictionary<string, InventoryItemData> itemDictionary;
    private string SelectedItemID;

    public void Start()
    {
        itemDictionary = new Dictionary<string, InventoryItemData>();
        foreach (InventoryItemData item in items)
        {
            itemDictionary[item.itemID] = item;
        }
    }


    public void SelectItem(string itemID)
    {
        if (itemDictionary.TryGetValue(itemID, out InventoryItemData selectedItem))
        {
            Purchase_UI.SetActive(true);
            ItemImage.sprite = selectedItem.itemImage;
            ItemNameText.text = selectedItem.itemName;
            ItemCoinText.text = $"({selectedItem.itemPrice:N0}point)";
            ItemExplainText.text = selectedItem.itemDescription;

            SelectedItemID = itemID;
        }
        else
        {
            Debug.LogError("Item ID not found " + itemID);
        }
    }    

    public void Purchase()
    {
        InventoryItemData selectedItem = itemDictionary[SelectedItemID];
        if (GameManager.Instance.Coin >= selectedItem.itemPrice)
        {
            if (BackPackManager.Instance.AddItem(selectedItem))
            {
                GameManager.Instance.Coin -= selectedItem.itemPrice;
                PopupMsgManager.instance.ShowPopupMessage("���� ����");
            }
            else
            {
                PopupMsgManager.instance.ShowPopupMessage("BackPack�� �� ������ �����ϴ�.");
            }
        }
        else
        {
            PopupMsgManager.instance.ShowPopupMessage($"�ܾ��� �����մϴ�. �ܾ� : {GameManager.Instance.Coin}");
        }
        
    }
}
