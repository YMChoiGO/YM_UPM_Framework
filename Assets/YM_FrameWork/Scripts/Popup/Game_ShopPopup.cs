using System.Collections.Generic;
using UnityEngine;

public class Game_ShopPopup : Popup
{
    private List<SkillData> sellSkill = new();

    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        OnClose();
    }

    public override void Close()
    {
        TempUserStat.InvokeAddStatEvent();
    }
}
