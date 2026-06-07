using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    public int id;
    public string name;
    public string description;
    public SkillGradeType colorGrade;
    public List<AbilityData> abilityData = new();
}

public class AbilityData
{
    public AbilityType abilityType;
    public int value;
}