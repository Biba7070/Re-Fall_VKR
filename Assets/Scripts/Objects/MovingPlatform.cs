using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField]  public float changeDirectionDelay;
   [SerializeField] Transform startPoint, endPoint;
    private Transform destinationTarget, departTarget;
    private float startTime;
    private float journeyLength;
    bool issWaiting;
    // Start is called before the first frame update
    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if(!issWaiting)
        {
            if(Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
            }

            else
            {
                issWaiting = true;
                StartCoroutine(changeDelay());
            }
        }
    }

    void changeDestination()
    {
        if(departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
    }

    IEnumerator changeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        changeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        issWaiting = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

}
