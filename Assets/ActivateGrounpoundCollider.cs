using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGrounpoundCollider : MonoBehaviour
{
    public Collider CurioGroundPoundBottom;

    void Start()
    {
        CurioGroundPoundBottom.enabled = false;
    }

    void Update()
    {
        if (WalkForPlayer.GroundPoundActivated == true)
        {
            CurioGroundPoundBottom.enabled = true;
        }
        else
        {
            CurioGroundPoundBottom.enabled = false;
        }
    }
}
