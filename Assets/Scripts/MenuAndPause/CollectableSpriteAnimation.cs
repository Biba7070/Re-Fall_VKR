using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSpriteAnimation : MonoBehaviour
{
    public Image capImage;
    public Sprite[] capFrames;
    public float frameDelay = 0.1f;
    private int indexSprite;
    private Coroutine animationCoroutine;

    void Start()
    {
        StartCapAnimation();
    }

    public void StartCapAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(PlayCapAnim());
    }

    public void StopCapAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }

    IEnumerator PlayCapAnim()
    {
        while (true)
        {
            capImage.sprite = capFrames[indexSprite];

            // Увеличиваем индекс для следующего кадра
            indexSprite = (indexSprite + 1) % capFrames.Length; // Автоматический сброс при достижении конца

            yield return new WaitForSeconds(frameDelay);
        }
    }
}
