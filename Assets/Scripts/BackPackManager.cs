using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;
    public GameObject BackPack_UI;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemData;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InventoryItemData = new InventoryItemData[ItemImages.Length];
    }

    private void Update()
    {
        BackPackUIOn(); 
        CoinText.text = $"Coin: {GameManager.Instance.Coin:N0}";
    }

    private void BackPackUIOn()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }    
    }

    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < ItemImages.Length; i++)
        {
            if (ItemImages[i].sprite == null)
            {
                ItemImages[i].sprite = item.itemImage;
                InventoryItemData[i] = item;
                return true;
            }
        }
        return false;
    }

}
