using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestEvent
{
    public abstract string Name();
    public abstract string Desc();
    public abstract string QuestCondition();
    public abstract string QuestReward();
    
    public abstract bool UnlockQuest();
    public abstract bool QuestClear();
}
