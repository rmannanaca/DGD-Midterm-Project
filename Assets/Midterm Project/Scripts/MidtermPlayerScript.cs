using UnityEngine;

public class MidtermPlayerScript : MonoBehaviour
{
public Rigidbody2D PlayerRigidBody2D;

//UPDATE
void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

//JUMP
[SerializeField] float jumpForce;
void Jump()
    {
        PlayerRigidBody2D.linearVelocity = Vector2.up * jumpForce;
    }

//FIXED UPDATE
void FixedUpdate()
    {
        Gravity();
    }


[SerializeField] float gravity;

//GRAVITY
void Gravity()
    {
        PlayerRigidBody2D.linearVelocity -= Vector2.up * gravity * Time.deltaTime;
    }

//GROUND
void Ground()
    {
        
    }

}
