using UnityEngine;

namespace UI
{
    public class SpriteManager : MonoBehaviour
    {
        public Sprite LoadSprite(string savedSpriteName)
        {
            Sprite loadedSprite = Resources.Load<Sprite>("CharacterSprites/" + savedSpriteName);
            return loadedSprite;
        }
    }
}