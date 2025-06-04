using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    [SerializeField] bool blurEnable;
    [SerializeField] bool blurDisable;

    public void BlurEnable()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void BlurDisable()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (blurEnable)
        {
            BlurEnable();
            blurEnable = false;
        }
        if (blurDisable)
        {
            BlurDisable();
            blurDisable = false;
        }
    }
}
