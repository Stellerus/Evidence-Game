using TMPro;
using UnityEngine;

public class MapCountBehaviour : MonoBehaviour
{
    public int startCount = 2;            
    public int currentCount { get; private set; } = 0;  

    public TextMesh counterText;

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        counterText = GetComponent<TextMesh>();
        currentCount = startCount;
        UpdateText();
    }

    void Update()
    {

    }


    public void Decrease()
    {
        if (currentCount <= 0) 
            return;

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