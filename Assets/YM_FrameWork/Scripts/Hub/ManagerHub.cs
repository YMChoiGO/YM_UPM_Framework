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
        
        Resource = GetComponent<ResourceManager>();
        Resource.SetUp();
        
        Popup = GetComponent<PopupManager>();
        Popup.SetUp();
        UI = GetComponent<UIManager>();
        UI.SetUp();
    }

    public PopupManager Popup;
    public UIManager UI;
    public ResourceManager Resource;
}
