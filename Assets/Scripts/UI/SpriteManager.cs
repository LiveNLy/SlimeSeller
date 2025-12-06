using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite LoadSprite(string savedSpriteName)
    {
        Sprite loadedSprite = Resources.Load<Sprite>("CharacterSprites/" + savedSpriteName);
        return loadedSprite;
    }
}