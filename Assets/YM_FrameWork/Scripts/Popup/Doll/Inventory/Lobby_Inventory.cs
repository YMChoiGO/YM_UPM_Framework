using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Inventory : Popup
{
    [SerializeField] private Transform RootSlider;
    
    
    void Initialize()
    {
        var datas = RootSlider.GetComponentsInChildren<SellBox>();
        foreach (var box in datas)
        {
            Destroy(box.gameObject);
        }
    }

    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        Initialize();
    }

    public override void Close()
    {
        
    }
}