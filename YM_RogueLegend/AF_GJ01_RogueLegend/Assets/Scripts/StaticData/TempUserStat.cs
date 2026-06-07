using System;
using System.Collections.Generic;
using UnityEngine;

public static class TempUserStat
{
    public static List<SkillData> skillList = new();
    public static int Level;

    public static int exp
    {
        get { return _exp;  }
        set
        {
            _exp = value;
            InvokeAddStatEvent();
            while (_exp >= 100)
            {
                AddLevel();
            }
        }
    }
    private static int _exp;
    
    public static int curHp
    {
        get { return _curHp; }
        set
        {
            _curHp = value;
            InvokeAddStatEvent();
        }
    }

    private static int _curHp;
    
    public static int maxHp;

    public static int ATK;
    public static int DEF;
    public static int Coin;

    public static int ITEM_HP;
    public static int ITEM_ATK;
    public static int ITEM_DEF;

    public static int ADD_HP_Percent;
    public static int ADD_DEF_Percent;
    public static int ADD_ATK_Percent;

    public static int LoopCount;

    public static int RoundCount
    {
        get { return _roundCount;  }
        set
        {
            _roundCount = value;
            InvokeRoundEvent();
        }
    }

    private static int _roundCount;
    private static Action RoundEvent;
    
    public static void InvokeRoundEvent() => RoundEvent?.Invoke();

    public static UnitData GetStat()
    {
        UnitData stat = new UnitData();
        stat.status = new StatusData();
        stat.status.Atk = new StatData();
        stat.status.Def = new StatData();
        stat.status.CurHp = new StatData();
        stat.status.MaxHp = new StatData();
        stat.status.Atk.StatValue = ATK;
        stat.status.Def.StatValue = DEF;
        stat.status.CurHp.StatValue = curHp;
        stat.status.MaxHp.StatValue = maxHp;

        return stat;
    }

    public static void UserData()
    {
        Level = 1;
        
        curHp = 50;
        maxHp = 50;

        ATK = 5;
        DEF = 5;
        Coin = 5;
        ADD_HP_Percent = 100;
        ADD_DEF_Percent = 100;
        ADD_ATK_Percent = 100;

        ITEM_HP = 0;
        ITEM_ATK = 0;
        ITEM_DEF = 0;

        skillList.Clear();
    }

    public static void SkillAdd(SkillData skill)
    {
        skillList.Add(skill);
    }

    public static void AddLevel()
    {
        Level += 1;
        exp -= 100;
        MultiPleDef(0.1f);
        MultipleATK(0.1f);
        MutliPleHP(0.1f);
        InvokeAddStatEvent();
    }
    
    public static void MultiPleDef(float value)
    {
        DEF = (int)(DEF * value);
    }

    public static void MultipleATK(float value)
    {
        ATK = (int)(ATK * value);
    }

    public static void MutliPleHP(float value)
    {
        int AddHP = (int)(maxHp * value);
        maxHp += AddHP;
        curHp += AddHP;
    }

    public static void AddStat(StatType stat, float value)
    {
        switch (stat)
        {
            case StatType.HP:
                MutliPleHP(value);
                break;
            case StatType.DEF:
                MultiPleDef(value);
                break;
            case StatType.ATK:
                MultipleATK(value);
                break;
        }

        InvokeAddStatEvent();
    }

    public static Action AddStatEvent;
    public static void InvokeAddStatEvent() => AddStatEvent?.Invoke();

    public static ItemData head;
    public static ItemData body;
    public static ItemData Hand;
    public static ItemData Leg;

    public static void MinusStat(StatType stat, float value)
    {
        switch (stat)
        {
            case StatType.HP:
                maxHp -= (int)value;
                curHp = Mathf.Min(curHp, maxHp);
                break;
            case StatType.DEF:
                DEF -= (int)value;
                break;
            case StatType.ATK:
                ATK -= (int)value;
                break;
        }
    }
    
    public static void PlusStat(StatType stat, float value)
    {
        switch (stat)
        {
            case StatType.HP:
                maxHp += (int)value;
                curHp += (int)value;
                break;
            case StatType.DEF:
                DEF += (int)value;
                break;
            case StatType.ATK:
                ATK += (int)value;
                break;
        }
    }
    
    public static void DequeItem(EquipType equip)
    {
        switch (equip)
        {
            case EquipType.Head:
                for (int i = 0; i < head.LevelStatData.Count; i++)
                {
                    var stat = head.LevelStatData[i].StatData[head.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    MinusStat(statType, statValue);
                }
                
                head = null;
                break;
            case EquipType.Body:
                for (int i = 0; i < body.LevelStatData.Count; i++)
                {
                    var stat = body.LevelStatData[i].StatData[body.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    MinusStat(statType, statValue);
                }
                
                body = null;
                break;
            case EquipType.Hand:
                for (int i = 0; i < Hand.LevelStatData.Count; i++)
                {
                    var stat = Hand.LevelStatData[i].StatData[Hand.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    MinusStat(statType, statValue);
                }
                
                Hand = null;
                break;
            case EquipType.Leg:
                for (int i = 0; i < Leg.LevelStatData.Count; i++)
                {
                    var stat = Leg.LevelStatData[i].StatData[Leg.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    MinusStat(statType, statValue);
                }
                Leg = null;
                break;
        }
    }

    public static void EquipItem(EquipType equip, ItemData item)
    {
        switch (equip)
        {
            case EquipType.Head:
                if (head != null) DequeItem(equip); 
                for (int i = 0; i < head.LevelStatData.Count; i++)
                {
                    var stat = head.LevelStatData[i].StatData[head.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    PlusStat(statType, statValue);
                }
                break;
            case EquipType.Body:
                if (body != null) DequeItem(equip); 
                for (int i = 0; i < body.LevelStatData.Count; i++)
                {
                    var stat = body.LevelStatData[i].StatData[body.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    PlusStat(statType, statValue);
                }
                break;
            case EquipType.Hand:
                if (Hand != null) DequeItem(equip); 
                for (int i = 0; i < Hand.LevelStatData.Count; i++)
                {
                    var stat = Hand.LevelStatData[i].StatData[Hand.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    PlusStat(statType, statValue);
                }
                break;
            case EquipType.Leg:
                if (Leg != null) DequeItem(equip); 
                for (int i = 0; i < Leg.LevelStatData.Count; i++)
                {
                    var stat = Leg.LevelStatData[i].StatData[Leg.curLevel];
                    var statType = stat.StatType;
                    var statValue = stat.StatValue;
                    PlusStat(statType, statValue);
                }
                Leg = null;
                break;
        }
    }
    
}
