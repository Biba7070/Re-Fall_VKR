using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public WalkForPlayer wfp;
    public GameObject uiBorders, cutsceneCam, capsToLvl2and3;
    // Start is called before the first frame update
    void Start()
    {
        uiBorders.SetActive(false);
        cutsceneCam.SetActive(false);
        capsToLvl2and3.SetActive(false);
    }



    public void StartCutscene()
    {
        wfp.enabled = false;
        uiBorders.SetActive(true);
        cutsceneCam.SetActive(true);
    }

    public void EndCutscene()
    {
        wfp.enabled = true;
        uiBorders.SetActive(false);
        cutsceneCam.SetActive(false);
    }
}
