using System;
using System.Data;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public RunTileType runTileType;
    public BigEventTileType bigEventType;
    
    private int _line;
    private int _index;
    public int totalIndex => _line * DefaultKey.maxLineCount + _index;

    [SerializeField] private SpriteRenderer mainVisual;
    [SerializeField] private SpriteRenderer overlayVisual;
    [SerializeField] private SpriteRenderer topSpriteVisual;

    public void Set(int line, int index)
    {
        _line = line;
        _index = index;
        SetOrder();
        SetPos();
    }
    
    private int OrderSize()
    {
        int order = totalIndex - DefaultKey.maxLineCount * 2;
        if (order < 0) order *= -1;
        return order;
    }
    
    private void SetOrder()
    {
        int order = OrderSize();
        mainVisual.sortingOrder = DefaultKey.DefaultTileOrder + order * DefaultKey.DefaultTileOffsetOrder;
        overlayVisual.sortingOrder = DefaultKey.DefaultTileOverlayOrder + order * DefaultKey.DefaultTileOffsetOrder;
        topSpriteVisual.sortingOrder = DefaultKey.DefaultTileTopImageOrder + order * DefaultKey.DefaultTileOffsetOrder;
    }

    private void SetPos()
    {
        float x = -DefaultKey.maxLineCount, y = -DefaultKey.maxLineCount;
        switch (_line)
        {
            case 0:
                x += -_index + DefaultKey.maxLineCount;
                y += _index;
                break;
            case 1:
                x += _index;
                y += _index + DefaultKey.maxLineCount;
                break;
            case 2:
                x += _index + DefaultKey.maxLineCount;
                y += - _index + DefaultKey.maxLineCount * 2 ;
                break;
            case 3: // right → bottom : X-, Y-
                x += - _index + DefaultKey.maxLineCount * 2;
                y += - _index + DefaultKey.maxLineCount;
                break;
        }
        
        if (x != 0)
        {
            if (x > 0)
            {
                x += DefaultKey.bigTileOffset;
            }
            else
            {
                x -= DefaultKey.bigTileOffset;
            }
        }

        if (y != 0)
        {
            if (y > 0)
            {
                y += DefaultKey.bigTileOffset;
            }
            else
            {
                y -= DefaultKey.bigTileOffset;
            }
        }
        
        x *= DefaultKey.tileOffsetX;
        y *= DefaultKey.tileOffsetY;

        this.transform.position = new Vector2(x, y);
    }
    public void AutoGenerate()
    {
        tileType = (TileType) Random.Range(0, DefaultKey.tilecount) + 1;
        runTileType = RunTileType.Skip;

        if (_index == 0)
        {
            switch (_line)
            {
                case 0:
                    bigEventType = BigEventTileType.Brazier;
                    break;
                case 1:
                    bigEventType = BigEventTileType.Box;
                    break;
                case 2:
                    bigEventType = BigEventTileType.Shop;
                    runTileType = RunTileType.Stop;
                    break;
                case 3:
                    bigEventType = BigEventTileType.Crystal;
                    break;
            }
        }

        if (bigEventType != BigEventTileType.None)
        {
            tileType = TileType.None;
        }

        GetSprite();
    }

    private void GetSprite()
    {
        string subText = "";
        if (bigEventType != BigEventTileType.None)
        {
            subText = "6"; //"Big";
        }
        else
        {
            subText = $"{(int)tileType}"; //$"Small{(int)tileType}";
        }
        
        overlayVisual.sprite = ManagerHub.I.Resource.Sprites[DefaultKey.bg_tile + subText];
        GetTopIcon();
    }

    private void GetTopIcon()
    {
        // if (bigEventType != BigEventTileType.None)
        // {
        //     topSpriteVisual.sprite = ManagerHub.I.Resource.Sprites[DefaultKey.obj + bigEventType.ToString()];
        // }
        // else
        // {
        //     switch (tileType)
        //     {
        //         case TileType.Battle:
        //             topSpriteVisual.sprite = ManagerHub.I.Resource.Sprites["Monster_Bat@"];
        //             break;
        //         case TileType.Happy:
        //             topSpriteVisual.sprite = ManagerHub.I.Resource.Sprites["Icon_ExclamationMark"];
        //             break;
        //         case TileType.Sad:
        //             topSpriteVisual.sprite = ManagerHub.I.Resource.Sprites["Icon_ExclamationMark"];
        //             break;
        //         default:
        //             topSpriteVisual.enabled = false;
        //             break;
        //     }
        // }
    }

    public void PopTile()
    {
        switch (tileType)
        {
            case TileType.Battle:
                ManagerHub.I.Popup.OpenPopup(PopupType.Game_BattlePopup);
                break;
            case TileType.Happy:
                StatType upStat = (StatType)Random.Range(0, 3);
                TempUserStat.AddStat(upStat, 0.1f);
                GameEntryEvent.InvokeEndEvent();
                break;
            case TileType.Sad :
                StatType downStat = (StatType)Random.Range(0, 3);
                TempUserStat.AddStat(downStat, -0.1f);
                GameEntryEvent.InvokeEndEvent();
                break;
            case TileType.Normal:
                break;
            case TileType.Random_Event:
                break;
            case TileType.View_Event:
                break;
        }

        switch (bigEventType)
        {
            case BigEventTileType.Shop:
                ManagerHub.I.Popup.OpenPopup(PopupType.Game_ShopPopup);
                break;
        }
    }
}
