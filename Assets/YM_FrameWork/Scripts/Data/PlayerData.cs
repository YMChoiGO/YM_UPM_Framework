using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public UserData userData;
    public QuestData pickQuest;

    private bool isSFXOn;
    private bool isBGMOn;

    public bool IsSfxOn
    {
        get => isSFXOn;
        set
        {
            isSFXOn = value;
            ReloadSFX?.Invoke(isSFXOn);
        }
    }

    public bool IsBGMOn
    {
        get => isBGMOn;
        set
        {
            isBGMOn = value;
            ReloadBGM?.Invoke(isBGMOn);
        }
    }

    public static Action<bool> ReloadSFX;
    public static Action<bool> ReloadBGM;


    public List<QuestData> DailyQuestList = new();

    public int ResearchPoint
    {
        get
        {
            return researchPoint;
        }
        set
        {
            researchPoint = value;
            ReloadResearchPoint?.Invoke(researchPoint);
        }
    }

    private int researchPoint;
    
    public int ResetPoint
    {
        get
        {
            return resetPoint;
        }
        set
        {
            resetPoint = value;
            ReloadResetPoint?.Invoke(resetPoint);
        }
    }

    private int resetPoint;
        
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            ReloadGold?.Invoke(gold);
        }
    }
    
    private int gold = 0;

    public int Exp
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
            ReloadExp?.Invoke(exp);
        }
    }

    private int exp;
    
    public int timeSpeed = 1;
    
    public float GetDeltaTime()
    {
        return Time.deltaTime * timeSpeed;
    }

    public float GetTime(float time)
    {
        return time / timeSpeed;
    }

    public Dictionary<int, MineralData> MineralDatas = new();
    
    public MineralData mineral0;
    public MineralData mineral1;
    public MineralData mineral2;
    public MineralData mineral3;
    
    public void SetUp()
    {
        mineral0 = new MineralData(0);
        mineral1 = new MineralData(1);
        mineral2 = new MineralData(2);
        mineral3 = new MineralData(3);
        
        MineralDatas.Add(0, mineral0);
        MineralDatas.Add(1, mineral1);
        MineralDatas.Add(2, mineral2);
        MineralDatas.Add(3, mineral3);
    }

    public static Action<int> ReloadMineral;
    public static Action<int> ReloadGold;
    public static Action<int> ReloadExp;
    public static Action<int> ReloadResetPoint;
    public static Action<int> ReloadResearchPoint;
}

[System.Serializable]
public class MineralData
{
    public int Id;
    
    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            PlayerData.ReloadMineral?.Invoke(Id);
        }
    }

    public MineralData(int Id)
    {
        this.Id = Id;
    }
}

[System.Serializable]
public class UserData
{
    private string user_Name;
    private int user_Level;
    private int user_Exp;
    
    public string User_Name
    {
        get
        {
            return user_Name;
        }
        set
        {
            user_Name = value;
            Reload_UserName?.Invoke(user_Name);
        }
    }

    public int User_Level
    {
        get
        {
            return user_Level;
        }
        set
        {
            user_Level = value;
            Reload_UserLevel?.Invoke(user_Level);
        }
    }

    public int User_Exp
    {
        get
        {
            return user_Exp;
        }
        set
        {
            user_Exp = value;
            Reload_UserExp?.Invoke(user_Exp);
        }
    }
    
    public static Action<string> Reload_UserName;
    public static Action<int> Reload_UserLevel;
    public static Action<int> Reload_UserExp;
}

[System.Serializable]
public class QuestData
{
    public bool initialize = false;
        
    public QuestName quest_Def;
    
    public QuestEvent Quest_Trigger
    {
        get
        {
            if (!initialize)
            {
                switch (quest_Def)
                {
                    case QuestName.Quest01:
                        quest_trigger = new Quest01();
                        break;
                    case QuestName.Quest02:
                        quest_trigger = new Quest02();
                        break;
                    case QuestName.Quest03:
                        quest_trigger = new Quest03();
                        break;
                    case QuestName.Quest04:
                        quest_trigger = new Quest04();
                        break;
                    case QuestName.Quest05:
                        quest_trigger = new Quest05();
                        break;
                    case QuestName.Quest06:
                        quest_trigger = new Quest06();
                        break;
                    case QuestName.Quest07:
                        quest_trigger = new Quest07();
                        break;
                    case QuestName.Quest08:
                        quest_trigger = new Quest08();
                        break;
                    case QuestName.Quest09:
                        quest_trigger = new Quest09();
                        break;
                    case QuestName.Quest10:
                        quest_trigger = new Quest10();
                        break;
                }

                initialize = true;
            }
            
            return quest_trigger;
        }
        set
        {
            quest_trigger = value;
        }
    }

    public void ClearReward()
    {
        foreach (var rewardData in reward)
        {
            switch (rewardData.reward_Type)
            {
                case RewardType.Gold:
                    ManagerHub.I.playerData.Gold += rewardData.reward_Count;
                    break;
                case RewardType.Exp:
                    ManagerHub.I.playerData.Exp += rewardData.reward_Count;
                    break;
            }
        }
    }

    public QuestEvent quest_trigger;

    public List<RewardData> reward = new();
}

[Serializable]
public class RewardData
{
    public RewardType reward_Type;
    public int reward_Count;
}

public enum RewardType
{
    Gold,
    Exp
}

public enum QuestName
{
    Quest01,
    Quest02,
    Quest03,
    Quest04,
    Quest05,
    Quest06,
    Quest07,
    Quest08,
    Quest09,
    Quest10
}