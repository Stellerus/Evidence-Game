using UnityEngine;


public class Jail : MonoBehaviour
{
    public SpriteDropper gol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        gol.StartDrop();
    }
}
