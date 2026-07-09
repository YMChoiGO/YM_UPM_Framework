using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Profile : Popup
{
    [SerializeField] private InputField nameField;
    [SerializeField] private Button nameSelect;

    [SerializeField] private CharacterBox characterBoxPrefab;
    [SerializeField] private Button upgradeBtn;
    // [SerializeField] private CharacterBox character;
    
    void Initialize()
    {
        nameSelect.OnlyEvent(PickName);
        upgradeBtn.OnlyEvent(TryUpgrade);
    }

    void PickName()
    {
        ManagerHub.I.playerData.userData.User_Name = nameField.text;
    }
    
    public void TryUpgrade()
    {
        var playerData = ManagerHub.I.playerData;
        if (playerData.Gold < playerData.userData.User_Level * 10) return;
        if (playerData.Exp < playerData.userData.User_Level * 5) return;
        
        ManagerHub.I.playerData.Gold -= playerData.userData.User_Level * 10;
        ManagerHub.I.playerData.Exp -= playerData.userData.User_Level * 5;

        ManagerHub.I.playerData.userData.User_Level++;
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