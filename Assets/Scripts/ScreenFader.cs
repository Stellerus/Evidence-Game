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
    private float fadeAmount;

    [SerializeField]
    private bool enabled = false;

    private float blackMaskOrigTransparency;
    private float fadeMaskOrigTransparency;

    void Awake()
    {
        blackMaskOrigTransparency = BlackMask.color.a;
        fadeMaskOrigTransparency = FadeMask.color.a;

    }

    void Update()
    {
        if (enabled && (FadeMask.color.a > 0 || BlackMask.color.a > 0))
        {
            ChangeTransparency(true, fadeAmount);
            ChangeTransparency(false, fadeAmount);
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
            FadeMask.color -= new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, FadeMask.color.a - (amount * fadeSpeed * Time.deltaTime));

            return FadeMask.color.a;
        }
        else
        {
            BlackMask.color -= new Color(BlackMask.color.r, BlackMask.color.g, BlackMask.color.b, BlackMask.color.a - (amount * fadeSpeed * Time.deltaTime));

            return BlackMask.color.a;
        }
    }


    public void Enable()
    {
        enabled = true;
    }
}
