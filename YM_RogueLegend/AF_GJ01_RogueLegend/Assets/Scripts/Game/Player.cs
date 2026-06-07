using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public override IEnumerator GetHit(int damage)
    {
        int dmg = Mathf.Max(0, damage - def);
        curHp -= dmg;
        TempUserStat.curHp = curHp;
        ReloadHp();
        yield return new WaitForSeconds(TimeHelper.GetTime(0.5f));
    }
}
