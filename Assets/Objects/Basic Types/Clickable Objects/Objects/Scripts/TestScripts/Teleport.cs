using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string nextSceneName;

    void OnMouseDown()
    {
        if (FadeTransition.Instance != null)
        {
            FadeTransition.Instance.StartCoroutine(
                FadeTransition.Instance.FadeOutRoutine(nextSceneName, true, 1f)
            );
        }
    }
}
