using UnityEngine;

public class AutoScaling : MonoBehaviour
{
    void Start()
    {
        ResizeBackground();
    }

    void ResizeBackground()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null) return;

        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        Vector2 spriteSize = sr.sprite.bounds.size;
        transform.localScale = new Vector3(screenWidth / spriteSize.x, screenHeight / spriteSize.y, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
