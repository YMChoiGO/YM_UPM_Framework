using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTagBox : UI
{
    public TextMeshProUGUI IdText;
    public TextMeshProUGUI Name;
    public Image itemImage;
    public Image itemFrame;
    public Image itemDescBox;
    public Button interactSkillBox;
    
    public void SetTagBox(SkillData skillData)
    {
        
    }

    public void SetRandomBox()
    {
        int ID = Random.Range(0, 12);
        IdText.text = ID.ToString();
        Name.text = ID.ToString();
        itemImage.sprite = ManagerHub.I.Resource.Sprites[$"Weapon_{ID}"];
        
        int grade = Random.Range(0, DefaultKey.tilecount);
        itemFrame.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{grade}"];
        itemDescBox.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{grade+1}"];
        var skill = new SkillData
        {
            id = ID,
            name = ID.ToString(),
            colorGrade = (SkillGradeType)grade,
            abilityData = null,
        };
        
        interactSkillBox.OnlyEvent(() =>
        {
            TempUserStat.SkillAdd(skill);
            ManagerHub.I.Popup.ClosePopup(PopupType.Game_SkillPopup);
        });
    }
    
    public override void Open()
    {
        
    }

    public override void Close()
    {
        
    }
}
