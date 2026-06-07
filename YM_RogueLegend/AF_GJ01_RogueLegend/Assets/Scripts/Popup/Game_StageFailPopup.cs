using UnityEngine;
using UnityEngine.UI;

public class Game_StageFail : Popup
{
    [SerializeField] private Button _retryBtn;
    [SerializeField] private Button _lobbyBtn;
    
    protected override void ObjectNameChange()
    {
       
    }

    protected override void AutoLink()
    {
       
    }

    public override void Open()
    {
        _retryBtn.OnlyEvent(PopRetry);
        _lobbyBtn.OnlyEvent(PopLobby);
    }

    public override void Close()
    {
        
    }

    private void PopRetry()
    {
        SceneType.LobbyScene.Go();
        SceneType.GameScene.Go();
    }

    private void PopLobby()
    {
        SceneType.LobbyScene.Go();
    }
}
