using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{

    private WalkForPlayer wfp;
    public Transform cam, gunTip;
    public LayerMask isItGrappleable;

    public float maxGrappleDistance, grappleDelayTime;
    private Vector3 grapplePoint;

    private bool grappling;
    // Start is called before the first frame update
    void Start()
    {
        wfp = GetComponent<WalkForPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGrapple()
    {
      
    }

    private void ExecuteGrapple()
    {

    }

    private void StopGrapple()
    {

    }
}
