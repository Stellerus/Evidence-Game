using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("List of keys")]
    public List<KeyCode> usedKeyCodes = new List<KeyCode>();

    private void Reset()
    {
        // Fill in only English letters A-Z
        usedKeyCodes.Clear();
        for (char c = 'a'; c <= 'z'; c++)
        {
            KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString().ToUpper());
            usedKeyCodes.Add(key);
        }
    }
}
