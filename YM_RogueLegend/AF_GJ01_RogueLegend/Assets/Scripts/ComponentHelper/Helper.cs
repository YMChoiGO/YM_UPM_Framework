using UnityEngine;

public abstract class Helper : MonoBehaviour
{
    private ManagerHub _managerHub;
    public ManagerHub ManagerHub
    {
        get
        {
            if (_managerHub == null)
            {
                _managerHub = GameObject.FindObjectOfType<ManagerHub>();
            }
            
            return _managerHub;
        }
    }

    protected abstract void ObjectNameChange();
    protected abstract void AutoLink();
}
