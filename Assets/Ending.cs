using UnityEngine;

public class Ending : MonoBehaviour
{
    ScreenNight blackScreen;
    public TextMesh textMesh;

    private void Awake()
    {
        blackScreen = GetComponent<ScreenNight>();
    }


    public void StartEnding()
    {
        blackScreen.StartFullFade();
        textMesh.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
