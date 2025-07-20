using UnityEngine;

public class SpriteToggleOnClick : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    public bool isNew = false;

    public bool IsNew => isNew; // Property to check if the sprite is new

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isNew && CompareTag("Player"))
        {
            // Reset to original sprite when Escape is pressed
            spriteRenderer.sprite = originalSprite;
            isNew = false;
        }
    }
    public void OnMouseDown()
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

