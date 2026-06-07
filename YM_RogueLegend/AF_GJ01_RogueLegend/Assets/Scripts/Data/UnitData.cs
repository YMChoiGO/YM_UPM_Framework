using UnityEngine;

public class UnitData
{
    public int id;
    
    public int dropGold;
    public int dropExp;
    public StatusData status;

    public UnitData SetRandom(int loopCount, int round, int level)
    {
        return new UnitData()
        {
            dropGold = loopCount * 100 + round * 10 + level * 50,
            dropExp = loopCount * 5 + round * 5 + level * 5,
            status = DefaultMonster(1 + loopCount * 0.3f + round * 0.05f),
        };
    }
    
    private StatusData DefaultMonster(float value)
    {
        return new StatusData
        {
            Atk = new StatData
            {
                StatType = StatType.ATK,
                StatValue = (int)(20 * value)
            }, // 소괄호 제거 및 쉼표 처리
            Def = new StatData
            {
                StatType = StatType.DEF,
                StatValue = (int)(5 * value)
            },
            CurHp = new StatData
            {
                StatType = StatType.HP,
                StatValue = (int)(100 * value)
            },
            MaxHp = new StatData
            {
                StatType = StatType.HP,
                StatValue = (int)(100 * value)
            }
        };
    }
}

public class StatusData
{
    public StatData Atk;
    public StatData Def;
    public StatData CurHp;
    public StatData MaxHp;
}
