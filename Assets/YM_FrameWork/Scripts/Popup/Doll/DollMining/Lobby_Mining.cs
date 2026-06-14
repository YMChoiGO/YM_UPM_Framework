using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Mining : Popup
{
    [SerializeField] private Transform RootSlider;
    [SerializeField] private SellBox _sellBox;
    
    [SerializeField] private Button OkButton;
    
    
    void Initialize()
    {
        var datas = RootSlider.GetComponentsInChildren<SellBox>();
        foreach (var box in datas)
        {
            Destroy(box.gameObject);
        }
        
        for (int i = 0; i < 4; i++)
        {
            var prefab = Instantiate(_sellBox, RootSlider);
            prefab.Initialize(i);
        }
        
        OkButton.OnlyEvent(OnClose);
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