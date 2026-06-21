using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_DollspawnPopup : Popup
{
    [SerializeField] private Button characterDrop;
    [SerializeField] private Button character_TenDrop;
    [SerializeField] private Button OkButton;

    // private ProfileType _profile;
    // private FrameType _frame;

    public List<CharacterBox> characterBoxes = new();
    [SerializeField] private CharacterBox characterPrefab;
    [SerializeField] private Transform root;
    
    // [SerializeField] private CharacterBox character;
    
    void Initialize()
    {
        ClearList();
        // RandomSpawn();
        character_TenDrop.OnlyEvent(() => RandomSpawn(10));
        characterDrop.OnlyEvent(() => RandomSpawn(1));
        OkButton.OnlyEvent(GetInventory);
    }

    void ClearList()
    {
        foreach (var character in characterBoxes)
        {
            Destroy(character.gameObject);
        }
        characterBoxes.Clear();
    }

    void RandomSpawn(int count)
    {
        ClearList();
        
        for (int i = 0; i < count; i++)
        {
            int profileCount = System.Enum.GetValues(typeof(ProfileType)).Length;
            ProfileType _profile = (ProfileType)Random.Range(0, profileCount);
            int frameCount = System.Enum.GetValues(typeof(FrameType)).Length;
            FrameType _frame = (FrameType)Random.Range(0, frameCount);

            var character = Instantiate(characterPrefab, root);
            character.Initialize(_profile, _frame);
            characterBoxes.Add(character);
        }
    }

    void GetInventory()
    {
        foreach (var character in characterBoxes)
        {
            var characterData = character.GetData();
            ManagerHub.I.playerData.DollData.Add(characterData);
        }

        OnClose();
    }

    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }

    public override void Open()
    {
        Initialize();
    }

    public override void Close()
    {
        
    }
}

public class DollData
{
    public int level;
    
    public int stat1;
    public int stat2;
    public int stat3;
    public int stat4;

    public LevelData[] priceData;
    
    public ProfileType profile;
    public FrameType frame;

    public bool TryPrice(int checkLevel)
    {
        if (priceData[checkLevel].gold > ManagerHub.I.playerData.Gold)
        {
            return false;
        }
        if (priceData[checkLevel].exp > ManagerHub.I.playerData.Exp)
        {
            return false;
        }

        return true;
    }

    public void LevelUp()
    {
        level += 1;
        
        stat1 = priceData[level].stat1;
        stat2 = priceData[level].stat2;
        stat3 = priceData[level].stat3;
        stat4 = priceData[level].stat4;
    }
}