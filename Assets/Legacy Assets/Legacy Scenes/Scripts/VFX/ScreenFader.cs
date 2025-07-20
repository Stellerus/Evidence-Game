using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [Header("Insert black image")]
    [SerializeField] private SpriteRenderer BlackMask;

    [Header("Insert mask\n(Mask is a gradient from black to transparent)")]
    [SerializeField] private SpriteRenderer FadeMask;

    [Header("")]
    [SerializeField] private float fadeSpeed;
    private float fadeAmount = 1;

    [SerializeField] private bool fading = false;
    [SerializeField] private bool debugReset = false;

    private bool IsAlphaAbove => (FadeMask.color.a > 0 || BlackMask.color.a > 0);
    private bool IsAlphaBelow => (FadeMask.color.a <= 0 && BlackMask.color.a <= 0);


    private float blackMaskOrigTransparency = 1f;
    private float fadeMaskOrigTransparency = 1f;



    void Update()
    {
        if (debugReset)
        {
            Enable();
            debugReset = false;
        }
        if (fading && IsAlphaAbove)
        {
            ChangeTransparency(true, fadeAmount);
            ChangeTransparency(false, fadeAmount * 1f);
        }
        else if (fading && (IsAlphaBelow))
        {
            fading = false;
            Debug.Log("Fade ended successfully");
        }
    }



    /// <summary>
    /// Changes Alpha channel of Sprite by amount and returns amount
    /// </summary>
    /// <param name="ChangeFadeMask"> If false changes Black Mask </param>
    /// <param name="amount"> Amount of transparancy change by iteration</param>
    /// <returns> Returns changed alpha value of chosen mask</returns>
    public float ChangeTransparency(bool ChangeFadeMask, float amount)
    {
        if (ChangeFadeMask)
        {
            FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, FadeMask.color.a - (amount * fadeSpeed * Time.deltaTime));
            Debug.Log($"Fade mask alpha changed to: {FadeMask.color.a} by {amount * fadeSpeed * Time.deltaTime}");

            return FadeMask.color.a;
        }
        else
        {
            BlackMask.color = new Color(BlackMask.color.r, BlackMask.color.g, BlackMask.color.b, BlackMask.color.a - (amount * fadeSpeed * Time.deltaTime));
            Debug.Log($"Black mask alpha changed to: {BlackMask.color.a} by {amount * fadeSpeed * Time.deltaTime}");

            return BlackMask.color.a;
        }
    }


    public void Enable()
    {
        ResetValues();

        fading = true;

        Debug.Log("Fade started");
    }



    private void ResetValues()
    {
        FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, fadeMaskOrigTransparency);

        BlackMask.color = new Color(BlackMask.color.r, BlackMask.color.g, BlackMask.color.b, blackMaskOrigTransparency);

        Debug.Log("Fade values are reset");
    }
}
