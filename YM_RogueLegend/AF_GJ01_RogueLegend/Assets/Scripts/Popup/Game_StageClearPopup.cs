using UnityEngine;
using UnityEngine.UI;

public class Game_StageClear : Popup
{
    [SerializeField] private Button _clearBtn;
    [SerializeField] private Button _rewardBtn;
    
    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        SetBtn();
    }

    public override void Close()
    {
       
    }

    private void SetBtn()
    {
        _clearBtn.OnlyEvent(PopClear);
        _rewardBtn.OnlyEvent(PopClearReward);
    }

    private void PopClear()
    {
        SceneType.LobbyScene.Go();
        OnClose();
    }
    
    private void PopClearReward()
    {
        SceneType.LobbyScene.Go();
        OnClose();
    }
}
