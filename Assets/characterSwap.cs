using UnityEngine;

public class characterSwap : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Sprite adelina;
    public Sprite larsen;

    public void SwapToAdelina()
    {
        sprite.sprite = adelina;
    }

    public void SwapToVictor()
    {
        sprite.sprite = larsen;
    }

    public void ClearSprite()
    {
        sprite.sprite = null;
    }

    
}
