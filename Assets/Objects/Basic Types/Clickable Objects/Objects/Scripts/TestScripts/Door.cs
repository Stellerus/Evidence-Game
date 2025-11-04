using UnityEngine;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    void OnMouseDown()
    {
        FadeTransition.Instance.StartCoroutine(
            FadeTransition.Instance.FadeOut(nextSceneName, 1f)
        );
    }
}
