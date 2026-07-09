using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour
{
    private int id;
    private ProfileType _profileType;
    private FrameType _frameType;
    
    [SerializeField] private Image characterImage;
    [SerializeField] private Image gradeImage;

    public void Initialize(ProfileType profile, FrameType frame)
    {
        _profileType = profile;
        _frameType = frame;
        
        characterImage.sprite = ManagerHub.I.Resource.Sprites[$"Profile{_profileType}"];
        gradeImage.sprite = ManagerHub.I.Resource.Sprites[$"Profile_Frame{_profileType}"];
    }

    public DollData GetData()
    {
        return new DollData()
        {
            profile = _profileType,
            frame = _frameType
        };
    }

    public void Activate(bool avatar, bool frame)
    {
        characterImage.enabled = avatar;
        gradeImage.enabled = frame;
    }
}
