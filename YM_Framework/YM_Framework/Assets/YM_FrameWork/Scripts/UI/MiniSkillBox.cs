using UnityEngine;
using UnityEngine.UI;

public class MiniSkillBox : MonoBehaviour
{
    public Image itemImage;
    public Image itemFrame;
    public Image itemDescBox;
    
    public void Set(SkillData skillData)
    {
        itemImage.sprite = ManagerHub.I.Resource.Sprites[$"Weapon_{skillData.id}"];
        itemFrame.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{(int)skillData.colorGrade}"];
        itemDescBox.sprite = ManagerHub.I.Resource.Sprites[$"Tile_{(int)skillData.colorGrade+1}"];
    }
}
