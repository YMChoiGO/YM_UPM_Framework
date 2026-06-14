using JSAM;
using UnityEngine;

public class ManagerHub : MonoBehaviour
{
    public static ManagerHub I;
    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        I = this;
        
        playerData = GetComponent<PlayerData>();
        playerData.SetUp();
        Resource = GetComponent<ResourceManager>();
        Resource.SetUp();
        Popup = GetComponent<PopupManager>();
        Popup.SetUp();
        UI = GetComponent<UIManager>();
        UI.SetUp();
        Time = GetComponent<TimeManager>();
        Time.SetUp();
        Lobby = GetComponent<LobbyScene>();
        Lobby.Starter();
    }

    public PlayerData playerData;

    public PopupManager Popup;
    public UIManager UI;
    public ResourceManager Resource;
    public TimeManager Time;
    public LobbyScene Lobby;
}
