using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
[ExecuteAlways]
#endif
[RequireComponent(typeof(DialogueSystem))]
[RequireComponent(typeof(TextMesh))]
public sealed class LegacyTextLimiter : MonoBehaviour
{
    [Header("String Parameters")]
    [SerializeField, Min(0)] private int maxLength = 120;
    [SerializeField, Min(1)] private int maxLines = 5;

    [SerializeField] private DialogueSystem dialog;

    private TextMesh finalText { get; set; }

    [SerializeField] private bool editorMode;

    private void Awake() =>
        CacheTextComponent();

    [System.Diagnostics.Conditional("DEBUG")]
    private void OnValidate() =>
        CacheTextComponent();

    private void Update()
    {
        if (!editorMode)
            return;
        

        UpdateText(uiText.text);
    }

    public void UpdateText(string text)
    {
        if (text.Length > maxLength)
        {
            
            ValidateTextLines(text);
        }
        else
        {
            uiText.text = text;
        }
    }

    /// <summary>
    /// Divides string by maxLength, and inserts /n between each line
    /// </summary>
    /// <param name="text"> Original text </param>
    /// <returns> String separated among maxLines </returns>
    private string ValidateTextLines(string text)
    {

        //next part of the line
        string nextLine = string.Empty;

        //returned value
        string res = string.Empty;

        //cached length of nextLine
        int cachedLength = 0;

        //starts from the end of last nextLine character
        int processedLength = text.Length;

        // endl each substring
        //
        //for (int i = 0; i < maxLines; i++)
        //{
        //    cachedLength = nextLine.Length;
            
        //    nextLine = $"\n{text.Substring(processedLength, maxLength - 1)}";
        //    processedLength = text.Length + nextLine.Length;
        //    res = $"{text}{nextLine}";
        //}

        // by insert endl by maxlines
        //
        //for (int i = 1; i <= maxLines; i++)
        //{
        //    text.Insert(i * maxLength, "/n");
        //    if (i <= maxLines && i * maxLength > )
        //    {

        //    }
        //}

        //get substrings and return new one 

        return res;
    }


    private void CacheTextComponent()
    {
        if (uiText == null)
            uiText = GetComponent<TextMesh>();
    }
}
