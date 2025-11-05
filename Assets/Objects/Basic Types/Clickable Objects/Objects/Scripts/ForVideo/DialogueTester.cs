using UnityEngine;

public class DialogueTester : MonoBehaviour
{
    public WorldDialogueTrigger trigger;

    void Start()
    {
        Invoke(nameof(StartDialog), 1f);

        Invoke(nameof(Next), 3f);

        Invoke(nameof(Next), 4f);

        Invoke(nameof(Stop), 7f);
    }

    void StartDialog() => trigger.StartDialogue();
    void Next() => trigger.NextLine();
    void Stop() => trigger.StopDialogue();
}
