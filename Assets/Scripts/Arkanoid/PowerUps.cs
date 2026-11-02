using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveOnAxisZ = Mathf.MoveTowards(transform.position.z, -200, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, moveOnAxisZ);
        if (transform.position.z < -105)
        {
            Destroy(gameObject);
        }
    }
}
