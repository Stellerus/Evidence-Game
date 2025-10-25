using TMPro;
using UnityEngine;

public class MapCountBehaviour : MonoBehaviour
{
    public int startCount = 2;            
    public int currentCount { get; set; } = 0;  

    public TextMesh counterText;

    void Awake()
    {
        currentCount = startCount;
        UpdateText();
    }

    void Update()
    {

    }


    public void Decrease()
    {
        if (currentCount <= 0) return;

        currentCount--;
        UpdateText();
    }

    public void SetNumber(int number)
    {
        currentCount = number;
        UpdateText();
    }

    private void UpdateText()
    {
        if (counterText != null)
            counterText.text = currentCount.ToString();
    }
}