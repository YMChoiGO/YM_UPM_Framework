using UnityEngine;

public abstract class UI : MonoBehaviour
{
    public UIType uiType;
    
    public abstract void Open();
    public abstract void Close();
}
