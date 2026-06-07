using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] private Slider hp_slider;
    [SerializeField] private Image character;
    [SerializeField] private TextMeshProUGUI hp_txt;
    [SerializeField] private TextMeshProUGUI atk_txt;
    [SerializeField] private TextMeshProUGUI def_txt;
    
    public int curHp;
    public int maxHp;
    public int atk;
    public int def;
    public int dropGold;
    public int dropExp;
    
    public void SetUnitData(UnitData unitData)
    {
        curHp = unitData.status.CurHp.StatValue;
        maxHp = unitData.status.MaxHp.StatValue;
        atk = unitData.status.Atk.StatValue;
        def = unitData.status.Def.StatValue;
        dropGold = unitData.dropGold;
        dropExp = unitData.dropExp;

        TempUserStat.AddStatEvent -= ReloadHp;
        TempUserStat.AddStatEvent += ReloadHp;
    }

    public virtual IEnumerator GetHit(int damage)
    {
        curHp -= damage - def;
        ReloadHp();
        yield return new WaitForSeconds(TimeHelper.GetTime(0.5f));
    }

    protected void ReloadHp()
    {
        hp_txt.text = curHp + "/" + maxHp;
        hp_slider.value = (float)curHp / maxHp;
    }
}
