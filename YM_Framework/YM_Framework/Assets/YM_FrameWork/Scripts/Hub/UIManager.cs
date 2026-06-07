using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    public Dictionary<UIType, UI> UIList = new();
    
    public override void SetUp()
    {
        var listUI = this.GetComponentsInChildren<UI>();

        foreach (var ui in listUI)
        {
            UIList.Add(ui.uiType, ui);
        }
    }
    
    public void OpenUI(UIType uiType)
    {
        if (UIList.ContainsKey(uiType))
        {
            UIList[uiType].Open();
        }
    }

    public void CloseUI(UIType uiType)
    {
        if (UIList.ContainsKey(uiType))
        {
            UIList[uiType].Close();
        }
    }

    public T GetUI<T>(UIType uiType) where T : UI
    {
        return (T)UIList[uiType];
    }
}
