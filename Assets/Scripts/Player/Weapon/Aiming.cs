using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Aiming : MonoBehaviour
{
    public GameObject showAimCenter, hook;
    public CinemachineFreeLook SkepCamera, AimCamera;
    Animator animator;
    public static bool isAimingActive;
    // Start is called before the first frame update
    void Start()
    {
        showAimCenter.SetActive(false);
        hook.SetActive(false);
        AimCamera.Priority = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WalkForPlayer.isSkepActive == true)
        {
            if (Input.GetMouseButton(1))
            {
                showAimCenter.SetActive(true);
                AimCamera.Priority = 2;
                animator.SetBool("isAiming", true);
                isAimingActive = true;
                hook.SetActive(true);
            }
            else
            {
                showAimCenter.SetActive(false);
                AimCamera.Priority = 0;
                animator.SetBool("isAiming", false);
                isAimingActive = false;
                hook.SetActive(false);
            }
        }
    }
}
