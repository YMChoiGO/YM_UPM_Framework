using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : Popup
{
    [SerializeField] private Button SFXBtn;
    [SerializeField] private Image SFXBtnOnOff;
    
    [SerializeField] private Button BGMBtn;
    [SerializeField] private Image BGMBtnOnOff;
    
    [SerializeField] private Button PrivacyBtn;
    [SerializeField] private Button ReviewBtn;

    [SerializeField] private Sprite[] onOffImage;

    private void Initialize()
    {
        SFXBtnOnOff.sprite = ManagerHub.I.playerData.IsSfxOn ? onOffImage[0] : onOffImage[1];
        BGMBtnOnOff.sprite = ManagerHub.I.playerData.IsBGMOn ? onOffImage[0] : onOffImage[1];
        
        SFXBtn.OnlyEvent(ChangeSFX);
        BGMBtn.OnlyEvent(ChangeBGM);
        PrivacyBtn.OnlyEvent(LinkPrivacy);
        ReviewBtn.OnlyEvent(LinkReview);
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

    void ChangeSFX()
    {
        ManagerHub.I.playerData.IsSfxOn = !ManagerHub.I.playerData.IsSfxOn;
        SFXBtnOnOff.sprite = ManagerHub.I.playerData.IsSfxOn ? onOffImage[0] : onOffImage[1];
    }

    void ChangeBGM()
    {
        ManagerHub.I.playerData.IsBGMOn = !ManagerHub.I.playerData.IsBGMOn;
        BGMBtnOnOff.sprite = ManagerHub.I.playerData.IsBGMOn ? onOffImage[0] : onOffImage[1];
    }

    void LinkPrivacy()
    {
        
    }

    void LinkReview()
    {
        
    }
}
