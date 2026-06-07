using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JSAM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : Helper
{
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Exp;
    [SerializeField] private Slider Exp_Slider;
    
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private Slider HP_Slider;
    
    [SerializeField] private TextMeshProUGUI Def;
    [SerializeField] private TextMeshProUGUI Atk;
    
    [SerializeField] private Tile TilePrefab;
    private List<Tile> Tiles = new();
    private Dictionary<int, Tile> TileDic = new();
    [SerializeField] private Pin playerPin;
    
    [SerializeField] private Button RollDice;
    [SerializeField] private TextBox Dice_01;
    [SerializeField] private TextBox Dice_02;

    [SerializeField] private Slider Gage_Slider;
    [SerializeField] private TextMeshProUGUI Gage;

    // [SerializeField] private LogText_Mesh logTextMesh;
    
    private int Dice_Point01;
    private int Dice_Point02;
    private int Dice_Total;

    // private int line = 0;
    private int targetIndex = 0;

    private void SliderBind()
    {
        Level.text = $"{TempUserStat.Level}";
        Exp.text = $"{TempUserStat.exp}/100";
        Exp_Slider.value = (float)TempUserStat.exp / 100f;
        HP_Slider.value = (float)TempUserStat.curHp / TempUserStat.maxHp;
        
        HP.text = $"{TempUserStat.curHp}/{TempUserStat.maxHp}";
        Def.text = $"{TempUserStat.DEF}";
        Atk.text = $"{TempUserStat.ATK}";

        // logTextMesh.LogStart(playerPin.transform.position, text: "");
    }

    private void Start()
    {
        Initialize();
        BindBtn();
        SliderBind();
        TempUserStat.AddStatEvent -= SliderBind;
        TempUserStat.AddStatEvent += SliderBind;
        // AudioManager.PlayMusic(AudioMusic.OutlawLoop);
    }

    private void BindBtn()
    {
        RollDice.OnlyEvent(PopRollDice);
    }

    private void Initialize()
    {
        for (int line = 0; line < 4; line++)
        {
            for (int block = 0; block < DefaultKey.maxLineCount; block++)
            {
                var tile = Instantiate(TilePrefab, TilePrefab.transform.position, TilePrefab.transform.rotation,
                    transform);
                
                Tiles.Add(tile);
                tile.Set(line, block);
                tile.AutoGenerate();
                TileDic.Add(tile.totalIndex, tile);
            }
        }
        
        TempUserStat.UserData();
    }
    
    
    protected override void ObjectNameChange()
    {
        
    }

    protected override void AutoLink()
    {
        
    }
    
    private void PopRollDice()
    {
        TempUserStat.RoundCount++;
        StartCoroutine(RollAnimation());
    }

    private IEnumerator RollAnimation()
    {
        Dice_01.CanvasGroup.Active(true);
        Dice_02.CanvasGroup.Active(true);
        
        float time = 0;
        float targetTime = 0.5f;
        while (time < targetTime)
        {
            time += TimeHelper.GetDeltaTime();
            Dice_Point01 = Random.Range(0, DefaultKey.tilecount) + 1;
            // Dice_01.SetImage(ManagerHub.Resource.Sprites[$"UI_Dice_{Dice_Point01}"]);
            Dice_01.SetText(Dice_Point01.ToString());
            yield return null;
        }

        time = 0;
        
        while (time < targetTime)
        {
            time += TimeHelper.GetDeltaTime();
            Dice_Point02 = Random.Range(0, DefaultKey.tilecount) + 1;
            // Dice_02.SetImage(ManagerHub.Resource.Sprites[$"UI_Dice_{Dice_Point02}"]);
            Dice_02.SetText(Dice_Point02.ToString());
            yield return null;
        }
        
        yield return new WaitForSeconds(TimeHelper.GetTime(0.5f));
        Dice_01.CanvasGroup.Active(false);
        Dice_02.CanvasGroup.Active(false);

        Dice_Total = Dice_Point01 + Dice_Point02;
        
        yield return StartCoroutine( CharacterMove());
    }

    public void CharacterMoveTrigger()
    {
        StartCoroutine(CharacterMove());
    }

    private IEnumerator CharacterMove()
    {
        if (Dice_Total <= 0) yield break;
        
        while (Dice_Total > 0)
        {
            targetIndex += 1;
            targetIndex %= DefaultKey.maxLineCount * 4;
            Dice_Total -= 1;

            int line = targetIndex / DefaultKey.maxLineCount;
            int targetBlock = targetIndex % DefaultKey.maxLineCount;
            
            Sequence seq = DOTween.Sequence();

            seq.Append(playerPin.transform.DOMove(TileDic[targetIndex].transform.position, TimeHelper.GetTime(0.2f)));
            
            yield return seq.WaitForCompletion();
            if (TileDic[targetIndex].runTileType == RunTileType.Stop)
            {
                Dice_Total = 0;
                GameEntryEvent.onEndEvent -= CharacterMoveTrigger;
                GameEntryEvent.onEndEvent += CharacterMoveTrigger;
                TileDic[targetIndex].PopTile();
                break;
            }
        }
        
        TileDic[targetIndex].PopTile();
    }

    private void ChangeSlider()
    {
        Gage_Slider.value = (float)TempUserStat.RoundCount / DefaultKey.RoundCount;
        Gage.text = $"{TempUserStat.RoundCount}/{DefaultKey.RoundCount}";
    }
}
