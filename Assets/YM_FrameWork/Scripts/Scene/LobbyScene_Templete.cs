#if Templete

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyScene : Helper
{
    [SerializeField] private Button play_button;
    [SerializeField] private Button setting_button;
    [SerializeField] private Button inventory_button;
    [SerializeField] private Button store_button;

    private void Start()
    {
        BindBtn();
    }

    private void BindBtn()
    {
        play_button.OnlyEvent(PopPlaying01);
        setting_button.OnlyEvent(PopSetting);
        inventory_button.OnlyEvent(PopInventory);
        store_button.OnlyEvent(PopStore);
    }
    
    private void PopPlaying01()
    {
        SceneType.GameScene.Go();
    }
    
    private void PopPlaying02()
    {
        SceneType.GameScene2.Go();
    }
    
    private void PopSetting()
    {
        ManagerHub.Popup.OpenPopup(PopupType.All_SettingPopup);
    }

    private void PopInventory()
    {
        ManagerHub.Popup.OpenPopup(PopupType.Lobby_InventoryPopup);
    }

    private void PopStore()
    {
        ManagerHub.Popup.OpenPopup(PopupType.All_StorePopup);
    }

    [ContextMenu("First Name Change")]
    protected override void ObjectNameChange()
    {
        play_button.SetNameBtn("Play");
        setting_button.SetNameBtn("Setting");
        inventory_button.SetNameBtn("Inventory");
        store_button.SetNameBtn("Store");
    }

    [ContextMenu("AutoLink")]
    protected override void AutoLink()
    {
        play_button.Link("Play");
        setting_button.Link("Setting");
        inventory_button.Link("Inventory");
        store_button.Link("Store");
    }
}
#endif