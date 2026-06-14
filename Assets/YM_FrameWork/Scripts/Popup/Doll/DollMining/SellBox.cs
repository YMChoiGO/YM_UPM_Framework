using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellBox : MonoBehaviour
{
    [SerializeField] private Image mineralImage;

    [SerializeField] private TextMeshProUGUI mineralCount;
    [SerializeField] private TextMeshProUGUI mineralPrice;

    [SerializeField] private TextMeshProUGUI mineralAllPrice;
    [SerializeField] private Button sellBtn;

    private int _boxId;
    
    public void Initialize(int ID)
    {
        _boxId = ID;
        mineralImage.sprite = ManagerHub.I.Resource.Sprites[$"Gem_{ID}"];
        var count = ManagerHub.I.playerData.MineralDatas[ID].Count;
        mineralCount.text = $"{count}";
        mineralPrice.text = $"{ID}";
        mineralAllPrice.text = $"{ID * count}";
        
        sellBtn.OnlyEvent(SellEvent);

        PlayerData.ReloadMineral -= BindingEvent;
        PlayerData.ReloadMineral += BindingEvent;
    }

    private void OnDestroy()
    {
        PlayerData.ReloadMineral -= BindingEvent;
    }

    private void BindingEvent(int ID)
    {
        if (_boxId != ID) return;
        
        var count = ManagerHub.I.playerData.MineralDatas[ID].Count;
        mineralCount.text = $"{count}";
        mineralAllPrice.text = $"{ID * count}";
    }

    private void SellEvent()
    {
        D.Log($"팔림 다이아 + {_boxId} + {ManagerHub.I.playerData.MineralDatas[_boxId].Count}");
        ManagerHub.I.playerData.Gold += _boxId * ManagerHub.I.playerData.MineralDatas[_boxId].Count;
        ManagerHub.I.playerData.MineralDatas[_boxId].Count = 0;
    }
}
