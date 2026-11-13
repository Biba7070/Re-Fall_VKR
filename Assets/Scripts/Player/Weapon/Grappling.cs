using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{

    private WalkForPlayer wfp;
    public Transform cam, gunTip;
    public LayerMask isItGrappleable;
    public LineRenderer lr;


    public float maxGrappleDistance, grappleDelayTime;
    private Vector3 grapplePoint;

    private bool grappling;

    public float grapplingCooldown;
    private float grapplingCooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        wfp = GetComponent<WalkForPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Aiming.isAimingActive == true)
        {
            StartGrapple();
        }
        if (grapplingCooldownTimer > 0)
        {
            grapplingCooldownTimer -= Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartGrapple()
    {
      if (grapplingCooldownTimer > 0)
        {
            return;
        }
        grappling = true;
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, isItGrappleable))
        {
            grapplePoint = hit.point;
            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;
            Invoke(nameof(StopGrapple), grappleDelayTime);
        }
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExecuteGrapple()
    {

    }

    private void StopGrapple()
    {
        grappling = false;
        grapplingCooldownTimer = grapplingCooldown;
        lr.enabled = false;
    }
}
