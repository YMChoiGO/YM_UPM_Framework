using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_DollspawnPopup : Popup
{
    [SerializeField] private Button characterDrop;
    [SerializeField] private Button OkButton;

    private ProfileType _profile;
    private FrameType _frame;

    [SerializeField] private CharacterBox character;
    
    void Initialize()
    {
        RandomSpawn();
        
        characterDrop.OnlyEvent(RandomSpawn);
        OkButton.OnlyEvent(GetInventory);
    }

    void RandomSpawn()
    {
        int profileCount = System.Enum.GetValues(typeof(ProfileType)).Length;
        _profile = (ProfileType)Random.Range(0, profileCount);
        int frameCount = System.Enum.GetValues(typeof(FrameType)).Length;
        _frame = (FrameType)Random.Range(0, frameCount);
        
        character.Initialize(_profile, _frame);
    }

    void GetInventory()
    {
        var characterData = new CharacterData
        {
            profile = _profile,
            frame = _frame
        };

        ManagerHub.I.playerData.DollData.Add(characterData);
        
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

public class CharacterData
{
    public ProfileType profile;
    public FrameType frame;
}