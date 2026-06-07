using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : Helper
{
    private ItemData itemData;
    
    public TextMeshProUGUI IdText;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI ItemDesc;
    public Image itemImage;
    public Image itemFrame;
    public Image itemDescBox;
    public Button interactSkillBox;

    public void BoxSet(ItemData data)
    {
        itemData = data;
        
        interactSkillBox.OnlyEvent(() =>
        {
            var tagBox = ManagerHub.UI.GetUI<ItemTagBox>(UIType.ItemTagBox);
            tagBox.SetTagBox(itemData);
            ManagerHub.UI.OpenUI(UIType.ItemTagBox);
        });
    }

    public void SetRandomBox()
    {
        int ID = Random.Range(0, 12);
        IdText.text = ID.ToString();
        Name.text = ID.ToString();
        // itemImage.sprite = ManagerHub.I.Resource.Sprites[$"Weapon_{ID}"];
        
        int grade = Random.Range(0, DefaultKey.tilecount);
        itemFrame.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{grade}"];
        itemDescBox.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{grade+1}"];
        var item = new ItemData
        {
            id = ID,
            itemName = ID.ToString(),
            itemGrade = (ItemGradeType)grade,
            LevelStatData = new List<LevelStatData>
            {
                new LevelStatData
                {
                    level = 1,
                    StatData = new List<StatData>
                    {
                        new StatData
                        {
                            StatType = (StatType)Random.Range(0, 3),
                            StatValue = Random.Range(0, 20),
                        }
                    }
                }
            }
        };

        var statData = item.LevelStatData[0].StatData;
        for (int i = 0; i < statData.Count; i++)
        {
            ItemDesc.text += statData[i].StatType +  " " + statData[i].StatValue.ToString() + "\n";
        }
        
        interactSkillBox.OnlyEvent(() =>
        {
            TempUserStat.EquipItem(item.equipType, item);
            ManagerHub.I.Popup.ClosePopup(PopupType.Game_SkillPopup);
        });
    }
    
    [ContextMenu("First Name Change")]
    protected override void ObjectNameChange()
    {
        // ItemBtn.SetNameBtn("Item_Btn");
        // ItemImage.SetNameComp("Item_Image");
        // statText.SetNameComp("Item_Stat");
    }

    [ContextMenu("AutoLink")]
    protected override void AutoLink()
    {
        
    }
}
