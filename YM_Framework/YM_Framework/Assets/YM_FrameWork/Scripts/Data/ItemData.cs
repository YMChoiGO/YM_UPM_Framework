using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public int id;
    public string itemName;
    public EquipType equipType;
    public ItemGradeType itemGrade;
    public List<LevelStatData> LevelStatData = new();
    public int curLevel;
    public int maxLevel;
    
    public void SetMaxLevel(int level)
    {
        maxLevel = level;
    }
    
    public void SetCurLevel(int level)
    {
        curLevel = level; 
    }

    public LevelStatData GetStatData()
    {
        return LevelStatData[curLevel];
    } 
}

public class LevelStatData
{
    public int level;
    public List<StatData> StatData = new();
}

public class StatData
{
    public StatType StatType;
    public int StatValue;
}