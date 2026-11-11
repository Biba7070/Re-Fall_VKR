using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidControl : MonoBehaviour
{
    public float panelSpeed, mouseSensitivity, leftX, rightX;
    public Animator paddleAnim;
    public ArkanoidGameManager agm;
    // public Rigidbody rbArk;


    // Start is called before the first frame update
    void Start()
    {
        //rbArk = GetComponent<Rigidbody>();
        paddleAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agm.gameOver)
        {
            return;
        }
            //--------------------”правление с клавы--------------------//
            float horInp = Input.GetAxis("Horizontal");
            Vector3 movePan = new Vector3(horInp, 0, 0);
            transform.Translate(Vector3.right * horInp * Time.deltaTime * panelSpeed * 100);
            //---------------------------------------------------------//

            //-------------------”правление мышкой--------------------//
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 10;
            transform.Translate(Vector3.right * mouseX);

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, 0, 0);
        //---------------------------------------------------------//
        if (transform.position.x < leftX)
        {
            transform.position = new Vector3(leftX, transform.position.y, transform.position.z);
        }
        else if((transform.position.x > rightX))
        {
            transform.position = new Vector3(rightX, transform.position.y, transform.position.z);
        }

    }
}
