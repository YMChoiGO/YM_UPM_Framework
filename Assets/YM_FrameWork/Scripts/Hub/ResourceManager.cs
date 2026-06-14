using System.Collections.Generic;
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
        SpriteAtlas[] spriteAtlas = Resources.LoadAll<SpriteAtlas>("SpriteAtlas");

        foreach (SpriteAtlas atlas in spriteAtlas)
        {
            Sprite[] sprites = new Sprite[atlas.spriteCount];
            atlas.GetSprites(sprites);

            foreach (Sprite sprite in sprites)
            {
                Sprites.Add(sprite.name.Replace("(Clone)", ""), sprite);
            }
        }
    }
}
