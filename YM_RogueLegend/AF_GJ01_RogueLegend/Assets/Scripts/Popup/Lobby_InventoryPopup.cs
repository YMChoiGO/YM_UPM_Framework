using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lobby_InventoryPopup : Popup
{
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;

    [SerializeField] private RectTransform inventory;
    [SerializeField] private ItemBox itemBoxPrefab;
    public List<ItemBox> itemboxes = new();
    
    [ContextMenu("First Name Change")]
    protected override void ObjectNameChange()
    {
        CloseBtn.SetNameBtn("Close");
    }

    [ContextMenu("AutoLink")]
    protected override void AutoLink()
    {
        CloseBtn.Link("Close");
    }

    public override void Open()
    {
        var itemBoxes = inventory.GetComponentsInChildren<ItemBox>();
        foreach (var itemBox in itemBoxes)
        {
            Destroy(itemBox.gameObject);
        }
        itemboxes.Clear();

        for (int i = 0; i < 8; i++)
        {
            var itemBox = Instantiate(itemBoxPrefab, inventory);
            itemboxes.Add(itemBox);
            itemBox.SetRandomBox();
        }
    }

    public override void Close()
    {
        
    }
}
