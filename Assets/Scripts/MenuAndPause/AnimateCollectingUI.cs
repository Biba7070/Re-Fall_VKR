using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCollectingUI : MonoBehaviour
{
    Animator animator;
    private bool isUIShown = false;

    public float timeToHideUI = 3f;

    private Coroutine hideCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInventory.showTopUI)
        {
            ShowTopUI();
        }
    }


    public void ShowTopUI()
    {
        PlayerInventory.showTopUI = false;

        if (isUIShown)
        {
            StartHideTimer();
        }
        else
        {
            animator.SetBool("showTopMenu", true);
            isUIShown = true;

            StartHideTimer();
        }
    }

    public void HideUI()
    {
        animator.SetBool("showTopMenu", false);
        isUIShown = false;

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
            hideCoroutine = null;
        }
    }

    private void StartHideTimer()
    {
        // Останавливаем предыдущую корутину, если она есть
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        // Запускаем новую корутину
        hideCoroutine = StartCoroutine(HideUITimer());
    }

    IEnumerator HideUITimer()
    {
        yield return new WaitForSeconds(timeToHideUI);
        HideUI();
    }

}
