using System.Collections.Generic;
using UnityEngine;

public class Game_SkillPopup : Popup
{
    [SerializeField] private RectTransform boundary;
    [SerializeField] private SkillTagBox skillTagBoxPrefab;
    [SerializeField] private List<SkillTagBox> skillTagBoxes = new();
    
    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        var data = boundary.GetComponentsInChildren<SkillTagBox>();
        for (int i = 0; i < 3; i++)
        {
            Destroy(data[i].gameObject);
        }
        skillTagBoxes.Clear();

        for (int j = 0; j < 3; j++)
        {
            var skillBox = Instantiate(skillTagBoxPrefab, boundary.transform);
            skillTagBoxes.Add(skillBox);
            skillBox.SetRandomBox();
        }
    }

    public override void Close()
    {
        
    }
}
