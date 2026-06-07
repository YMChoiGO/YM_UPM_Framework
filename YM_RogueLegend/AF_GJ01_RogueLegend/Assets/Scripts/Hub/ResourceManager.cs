using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.U2D;

public class ResourceManager : Manager
{
    public Dictionary<string, Sprite> Sprites = new();
    
    public override void SetUp()
    {
        GetSprite();
    }

    private void GetSprite()
    {
        SpriteAtlas Item = Resources.Load<SpriteAtlas>("SpriteAtlas/Item");
        SpriteAtlas Player = Resources.Load<SpriteAtlas>("SpriteAtlas/Player");
        SpriteAtlas Tile = Resources.Load<SpriteAtlas>("SpriteAtlas/Tile");
        // SpriteAtlas Logue01 = Resources.Load<SpriteAtlas>("SpriteAtlas/LogLegend_01");
        
        Sprite[] itemSprite = new Sprite[Item.spriteCount];
        Item.GetSprites(itemSprite);
        Sprite[] playerSprite = new Sprite[Player.spriteCount];
        Player.GetSprites(playerSprite);
        Sprite[] tileSprite = new Sprite[Tile.spriteCount];
        Tile.GetSprites(tileSprite);
        // Sprite[] logue01Sprite = new Sprite[Logue01.spriteCount];
        // Logue01.GetSprites(logue01Sprite);

        foreach (Sprite sprite in itemSprite)
        {
            Sprites.Add(sprite.name.Replace("(Clone)", ""), sprite);
        }

        foreach (Sprite sprite in playerSprite)
        {
            Sprites.Add(sprite.name.Replace("(Clone)", ""), sprite);
        }

        foreach (Sprite sprite in tileSprite)
        {
            Sprites.Add(sprite.name.Replace("(Clone)", ""), sprite);
        }

        // foreach (Sprite sprite in logue01Sprite)
        // {
        //     Sprites.Add(sprite.name.Replace("(Clone)", ""), sprite);
        // }
    }
}
