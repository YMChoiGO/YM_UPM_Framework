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
        
        playerData = GetComponentInChildren<PlayerData>();
        playerData.SetUp();
        Resource = GetComponentInChildren<ResourceManager>();
        Resource.SetUp();
        Popup = GetComponentInChildren<PopupManager>();
        Popup.SetUp();
        UI = GetComponentInChildren<UIManager>();
        UI.SetUp();
        Time = GetComponentInChildren<TimeManager>();
        Time.SetUp();
    }

    public PlayerData playerData;

    public PopupManager Popup;
    public UIManager UI;
    public ResourceManager Resource;
    public TimeManager Time;
}
