using UnityEngine;

public class BasicDecorationObj : MonoBehaviour, IVisible
{
    public SpriteRenderer Renderer { get; set; }

    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }
}
