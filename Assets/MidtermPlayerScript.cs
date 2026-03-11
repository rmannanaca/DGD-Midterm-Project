using UnityEngine;

public class MidtermPlayerScript : MonoBehaviour
{

    public float MovementSpeed;
    public float MaxSpeed;
    public Rigidbody2D PlayerRigidbody2D;
    public Vector2 MovementVector;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbody2D= GetComponent<Rigidbody2D>();
        MovementSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        

        MovementVector= new Vector2(Input.GetAxis("Horizontal") * MovementSpeed, Input.GetAxis("Vertical") * MovementSpeed);

        //if (MovementVector.sqrMagnitude > MaxSpeed)
        //{

        //}

        PlayerRigidbody2D.AddForce(MovementVector);

    }
}
