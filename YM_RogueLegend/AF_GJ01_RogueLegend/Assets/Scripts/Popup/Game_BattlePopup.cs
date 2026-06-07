using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_BattlePopup : Popup
{
    public Player player;
    public Unit monster;

    public RectTransform playerInventory;
    public MiniSkillBox miniSkillBoxPrefab;

    // public LogText_UI logText;

    public bool win = false;
    public bool lose = false;

    private IEnumerator BattleSequence()
    {
        while (!win && !lose)
        {
            yield return StartCoroutine(monster.GetHit(player.atk));
            var posRect = Camera.main.ScreenToWorldPoint(monster.transform.position);
            // logText.LogStart(posRect, text: $"-{player.atk - monster.def}");
            if(monster.curHp <= 0)
            {
                win = true;
                break;
            }
            yield return StartCoroutine(player.GetHit(monster.atk));
            if (player.curHp <= 0)
            {
                lose = true;
                break;
            }
        }

        if (win)
        {
            TempUserStat.Coin += monster.dropGold;
            TempUserStat.exp += monster.dropExp;
            GameEntryEvent.InvokeEndEvent();
            
            OnClose();
        }
        else if (lose)
        {
            ManagerHub.Popup.OpenPopup(PopupType.Game_StageFailPopup);
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
        win = false;
        lose = false;
        player.SetUnitData(TempUserStat.GetStat());
        monster.SetUnitData(RandomMob());
        StartCoroutine(BattleSequence());

        var invenSkill = playerInventory.GetComponentsInChildren<MiniSkillBox>();
        foreach (MiniSkillBox box in invenSkill)
        {
            Destroy(box.gameObject);
        }
        invenSkill = null;

        for (int i = 0; i < TempUserStat.skillList.Count; i++)
        {
            var miniSkillBox = Instantiate(miniSkillBoxPrefab, playerInventory);
            miniSkillBox.Set(TempUserStat.skillList[i]);
        }
    }

    public override void Close()
    {
        
    }

    private UnitData RandomMob()
    {
        UnitData unitData = new UnitData();
        unitData.status = new StatusData();
        unitData.status.CurHp = new StatData();
        unitData.status.MaxHp = new StatData();
        unitData.status.Atk = new StatData();
        unitData.status.Def = new StatData();
        
        return unitData.SetRandom(TempUserStat.LoopCount, TempUserStat.RoundCount, TempUserStat.Level);
    }
}
