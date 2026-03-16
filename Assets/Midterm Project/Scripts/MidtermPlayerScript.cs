using UnityEngine;

public class MidtermPlayerScript : MonoBehaviour
{

    public float MovementSpeed;
    public float MaxSpeed;
    public Rigidbody2D PlayerRigidbody2D;
    // public Transform PlayerTransform2D;
    public Vector2 MovementVector;


    public Vector2 JumpVector;
    public float JumpHeight;
    public float Launchpoint;
    public float HangTime;

    public bool isGrounded;
    public int JumpsRemaining;

    public Vector2 DashStartPoint;
    public Vector2 DashEndPoint;

    public bool Dashing;
    public float DashingTime;
    public float DashDuration;
    public float t;
    public int DashesRemaining;



    // public Vector2 ShowInputAxis;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbody2D= GetComponent<Rigidbody2D>();
        MovementSpeed = 100f;
        MaxSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;



        //GROUND CONSTRAINTS
        if (isGrounded == true)
        {
            if(!Input.GetKey("space"))
            {
                JumpsRemaining++;
                DashesRemaining = 1;
            }
            

            //MOVEMENT CONSTRAINTS
            if(Input.GetAxisRaw("Horizontal") == 0)
            {
            PlayerRigidbody2D.linearVelocity = new Vector2(0,PlayerRigidbody2D.linearVelocity.y);
            
            }
        }
        else
        {
            MovementSpeed = 5;
        }

        //JUMP CONSTRAINTS
        if (JumpsRemaining > 1)
        {
            JumpsRemaining = 1;
        }

        if(JumpsRemaining < 0)
            {
                JumpsRemaining = 0;
            }
        

        //MOVEMENT "ENGINE"
        MovementVector = new Vector2(Input.GetAxis("Horizontal") * MovementSpeed,0);

        if (MovementVector.sqrMagnitude > MaxSpeed)
        {
            MovementVector = MovementVector.normalized * MaxSpeed;
        }


        //JUMP

        if(Input.GetKeyDown("space") == true && JumpsRemaining >= 1)
        {
            Launchpoint = transform.position.y;
            JumpHeight = Launchpoint + 5;
            JumpVector = new Vector2(0,25);
            PlayerRigidbody2D.AddForce(JumpVector, ForceMode2D.Impulse);
            HangTime = 1f;
            JumpsRemaining--;
            
        }

        if(transform.position.y > JumpHeight)
        {
            HangTime -= 0.05f;
            transform.position = new Vector2(transform.position.x, JumpHeight);

            if(HangTime < 0)
            {
                HangTime = 0;
                PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x,0);
            }

        }

        //DASH

        if (Input.GetKeyDown("f") && DashesRemaining >= 1)
        {
            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);
            
            Dashing = true;

            DashingTime = 0;
            DashDuration = 5;


            DashStartPoint = transform.position;
            DashEndPoint = DashStartPoint + new Vector2(Input.GetAxisRaw("Horizontal") * 5, 0);

            DashesRemaining--;

        }

        if(Dashing == true && DashingTime < DashDuration)
            {
                PlayerRigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionY;
                
                t = Mathf.Pow(DashingTime/DashDuration, 1f / 2f);
                DashingTime += 0.05f;

            transform.position = Vector2.Lerp(DashStartPoint,DashEndPoint, t);
        }
        else
        {
            PlayerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            Dashing = false;
        }








        PlayerRigidbody2D.AddForce(MovementVector);

    }



void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

}
