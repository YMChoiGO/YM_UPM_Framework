using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestBar : MonoBehaviour
{
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descTxt;

    public Button questBtn;

    private QuestData privateQuest;

    public void Set(QuestData questData)
    {
        privateQuest = questData;
        
        nameTxt.text = privateQuest.Quest_Trigger.Name();
        descTxt.text = privateQuest.Quest_Trigger.Desc();
        questBtn.interactable = privateQuest.Quest_Trigger.UnlockQuest() && (ManagerHub.I.playerData.pickQuest != privateQuest);
        questBtn.OnlyEvent(PickQuest);
    }

    public void PickQuest()
    {
        if (privateQuest.Quest_Trigger.UnlockQuest())
        {
            ManagerHub.I.playerData.pickQuest = privateQuest;
            Refresh();
        }
    }

    public void Refresh()
    {
        questBtn.interactable = privateQuest.Quest_Trigger.UnlockQuest() && (ManagerHub.I.playerData.pickQuest != privateQuest);
    }
}
