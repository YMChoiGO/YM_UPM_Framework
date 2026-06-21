using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_QuestPopup : Popup
{
    [SerializeField] private Transform RootSlider;
    // [SerializeField] private QuestBar
    [SerializeField] private QuestBar questBarPrefab;
    [SerializeField] private Transform QuestBarRoot;
    [SerializeField] private Button refreshBtn;
    public List<QuestBar> questBars = new();
    
    void Initialize()
    {
        Refresh();
        refreshBtn.OnlyEvent(Refresh);
    }

    void Refresh()
    {
        var datas = RootSlider.GetComponentsInChildren<QuestBar>();
        foreach (var box in datas)
        {
            Destroy(box.gameObject);
        }
        
        List<QuestName> questDatas = new();

        for (int j = 0; j < 5;)
        {
            var questType = (QuestName)Random.Range(0, System.Enum.GetValues(typeof(QuestName)).Length);

            if (questDatas.Contains(questType)) continue;

            questDatas.Add(questType);
            j++;
        }

        for (int i = 0; i < 5; i++)
        {
            var quest = Instantiate(questBarPrefab, QuestBarRoot);
            questBars.Add(quest);

            QuestData questData = new QuestData
            {
                quest_Def = questDatas[i]
            };
            
            quest.Set(questData);
        }
    }

    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        Initialize();
    }

    public override void Close()
    {
        
    }
}