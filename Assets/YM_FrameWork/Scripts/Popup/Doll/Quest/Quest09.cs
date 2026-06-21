using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest09 : QuestEvent
{
    public override string Name()
    {
        return this.GetType().Name;
    }

    public override string Desc()
    {
        return this.GetType().Name;
    }

    public override string QuestCondition()
    {
        return this.GetType().Name;
    }

    public override string QuestReward()
    {
        return this.GetType().Name;
    }

    public override bool UnlockQuest()
    {
        return true;
    }

    public override bool QuestClear()
    {
        return false;
    }
}
