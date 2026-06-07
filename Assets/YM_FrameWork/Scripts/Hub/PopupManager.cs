using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Manager
{
    public Dictionary<PopupType, Popup> Popups = new();
    public RectTransform baseRect;
    
    public override void SetUp()
    {
        var listPopup = baseRect.GetComponentsInChildren<Popup>();

        foreach (var popup in listPopup)
        {
            if(!Popups.ContainsKey(popup.PopupType))
                Popups.Add(popup.PopupType, popup);
        }
    }

    public void OpenPopup(PopupType popupType)
    {
        if (Popups.ContainsKey(popupType))
        {
            Popups[popupType].OnOpen();
            Popups[popupType].SetCloseBtn();
        }
    }

    public void ClosePopup(PopupType popupType)
    {
        if (Popups.ContainsKey(popupType))
        {
            Popups[popupType].OnClose();
        }
    }
}
