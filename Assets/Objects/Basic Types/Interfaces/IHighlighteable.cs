using System.Collections;
using UnityEngine;

public class HighlightBehaviour : MonoBehaviour 
{
    IEnumerator CurrentCoroutine { get; set; }
    SpriteRenderer HighlightSprite { get; set; }

    public void Highlight()
    {
        HighlightSprite.enabled = true;
    }

    public void EndHighlight()
    {
        StopAllCoroutines();
        HighlightSprite.enabled = false;
    }

    public void TimerHighlight(float time)
    {
        CurrentCoroutine = TimerHighlightCoroutine(time);
        StartCoroutine(CurrentCoroutine);
    }

    public void Blink(float interval)
    {
        CurrentCoroutine = BlinkCoroutine(interval);
        StartCoroutine(CurrentCoroutine);
    }

    public void TimerBlink(float time, float interval)
    {
        CurrentCoroutine = TimerBlinkCoroutine(time, interval);
        StartCoroutine(CurrentCoroutine);
    }




    IEnumerator TimerHighlightCoroutine(float time)
    {
        HighlightSprite.enabled = true;
        yield return new WaitForSeconds(time);
        HighlightSprite.enabled = false;
        StopCoroutine(TimerHighlightCoroutine(time));
    }

    IEnumerator BlinkCoroutine(float interval)
    {
        HighlightSprite.enabled = true;
        yield return new WaitForSeconds(interval);
        HighlightSprite.enabled = false;
    }

    IEnumerator TimerBlinkCoroutine(float time, float interval)
    {
        StartCoroutine(BlinkCoroutine(time));
        yield return new WaitForSeconds(time);
        StopCoroutine(BlinkCoroutine(time));
        HighlightSprite.enabled = false;
        StopCoroutine(TimerBlinkCoroutine(time,interval));
    }
}
