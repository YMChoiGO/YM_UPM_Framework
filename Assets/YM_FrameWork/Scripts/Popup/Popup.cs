using UnityEngine;
using UnityEngine.UI;

public abstract class Popup : Helper
{
    public PopupType PopupType => _popupType;
    public PopupType _popupType;

    public Button CloseBtn;

    public CanvasGroup CanvasGroup
    {
        get
        {
            if(_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }
            
            return _canvasGroup;
        }
    }
    public CanvasGroup _canvasGroup;

    public virtual void SetCloseBtn()
    {
        if(CloseBtn != null)
            CloseBtn.OnlyEvent(() => ManagerHub.Popup.ClosePopup(_popupType));
    }
    public abstract void Open();
    public abstract void Close();

    public void OnOpen()
    {
        CanvasGroup.Active(true);
        Open();
    }

    public void OnClose()
    {
        Close();
        CanvasGroup.Active(false);
    }
}
