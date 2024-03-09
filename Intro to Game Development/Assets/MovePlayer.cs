using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float jumpHeight = 15;
    public float speed = 5f;
    public float gravity = 200f;
    public float airControl = 0.5f;

    public float turnVelocity = 0.1f;
    public float smoothValue;

    Vector3 jumpDirection;

    CharacterController controller;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;


            targetAngle = Mathf.SmoothDampAnge(transform.eulerAngles.y, targetAngles, ref turnVelocity, smoothValue);

            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            direction = transform.foward;
        }
        direction *= speed;

        if (controller.isGround)
        {
            jumpDirection = direcion;

            if (Input.GetButtonDown("Jump"))
            {
                jumpDirection.y = jumpHeight;
            }
            else
            {
                jumpDirection.y = 0;
            }
        }
        else
        {
            direction.y = jumpDirection.y;
            //change the jumpDirection based on the direction.
            jumpDirection = Vector3.Lerp(jumpDirection, directrion, airControl * Time.deltaTime);
        }
        jumpDirection.y -= gravity * Time.deltaTime;

        //transform.position += direction * Time.deltaTime;
        controller.Move(jumpDirection * Time.deltaTime);
    }
}
