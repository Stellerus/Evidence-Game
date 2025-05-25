using UnityEngine;

public class SpriteToggleOnClick : MonoBehaviour
{
    public Sprite newSprite; // New sprite to switch to on click

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    private bool isNew = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Save the original sprite
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
