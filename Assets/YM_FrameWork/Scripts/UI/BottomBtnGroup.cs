using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum LobbyBottonType
{
    Battle,
    Upgrade,
    Lock,
    None
}

public class BottomBtnGroup : MonoBehaviour
{
    // private LobbySceneUI _body;
    
    public LobbyBottonType curType;
    public List<Button> buttons = new();

    [ContextMenu("AutoLink")]
    public void AutoLink()
    {
        buttons = GetComponentsInChildren<Button>().ToList();
    }
    
    public void Set()//LobbySceneUI body)
    {
        // _body = body;
        curType = LobbyBottonType.Battle;
        BindBtn();
        UpdateVisual(curType);
    }

    private void BindBtn()
    {
        buttons[0].AddEvent(EventTriggerType.PointerEnter, (_) => { UpdateVisual(LobbyBottonType.Battle); });
        buttons[1].AddEvent(EventTriggerType.PointerEnter, (_) => { UpdateVisual(LobbyBottonType.Upgrade); });
    }

    private void UpdateVisual(LobbyBottonType type)
    {
        curType = type;
        buttons[0].interactable = type != LobbyBottonType.Battle;
        buttons[1].interactable = type != LobbyBottonType.Upgrade;
        for (int i = 2; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
        }

        // _body.UpdateBoard(type);
    }
}
