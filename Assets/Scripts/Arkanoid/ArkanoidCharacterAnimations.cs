using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidCharacterAnimations : MonoBehaviour
{
    [SerializeField] ArkanoidGameManager agm;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agm.isLevelComplete == true)
        {
           animator.SetBool("LevelComplete", true);
        }
        else
        {
            animator.SetBool("LevelComplete", false);
            animator.SetBool("isPlaying", true);
        }
    }
}
