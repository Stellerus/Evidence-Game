using UnityEngine;

public class SpriteToggleOnClick : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    private bool isNew = false;

    public bool IsNew => isNew; // Property to check if the sprite is new

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void OnMouseDown()
    {
        if (!isNew)
        {
            spriteRenderer.sprite = newSprite;
            isNew = true;
        }
        else
        {
            spriteRenderer.sprite = originalSprite;
            isNew = false;
        }
    }
}

