using UnityEngine;

public class MidtermPlayerScript : MonoBehaviour
{

    public float MovementSpeed;
    public float MaxSpeed;
    public Rigidbody2D PlayerRigidbody2D;
    // public Transform PlayerTransform2D;
    public Vector2 MovementVector;
    public float InputMotionSync;
    public float MagAlongMovementVector;


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



    public RaycastHit2D RightNormalDetector;
    public RaycastHit2D LeftNormalDetector;
    public RaycastHit2D MiddleNormalDetector;
    public RaycastHit2D FrontNormalDetector;
    public Vector3 LeadingTangentVector;

    // public Vector2 ShowInputAxis;
    // public float RaycastDistance;

     public LayerMask TargetLayers;
    public Vector2 SurfSecVector;

    public Vector2 SurfNormalVector;

    // public Vector2 testVector;
    // public Vector2 testVector2;

    public float testAngle;


    public float PlayerHealth;
    public float HitDamage;
    public float DamageReceived;

    public bool isDamaged;

    public GameObject Enemy;
    public Collider2D myCollider2D;

    public Vector3 testVector;

    public Vector2 InstaSurfNormVector;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbody2D= GetComponent<Rigidbody2D>();
        MovementSpeed = 1.0f;
        MaxSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // PlayerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        RightNormalDetector = Physics2D.Raycast(transform.position + transform.right * 0.20f, -transform.up, 0.55f, TargetLayers);
        LeftNormalDetector = Physics2D.Raycast(transform.position - transform.right * 0.20f, -transform.up, 0.55f, TargetLayers);
        MiddleNormalDetector = Physics2D.Raycast(transform.position, -transform.up, 0.55f, TargetLayers);
        
        FrontNormalDetector = Physics2D.Raycast(transform.position + transform.right * Input.GetAxisRaw("Horizontal") * 0.20f, -transform.up, 0.55f, TargetLayers);
        
        LeadingTangentVector = Vector3.Cross(FrontNormalDetector.normal, Vector3.forward * Input.GetAxisRaw("Horizontal"));

        testVector = FrontNormalDetector.normal;


        Debug.DrawRay(transform.position + transform.right * 0.20f, -transform.up * 0.55f, Color.green);
        Debug.DrawRay(transform.position - transform.right * 0.20f, -transform.up * 0.55f, Color.green);
        Debug.DrawRay(transform.position, LeadingTangentVector * 1.0f, Color.red);


        if(MiddleNormalDetector.collider != null)
        {
            
        }





        if (RightNormalDetector && LeftNormalDetector)
        {
            

            SurfSecVector = RightNormalDetector.point - LeftNormalDetector.point;

            SurfNormalVector = new Vector2(-SurfSecVector.y,SurfSecVector.x);

        }

        if (RightNormalDetector.collider != null && LeftNormalDetector.collider != null)
        {
            // testVector = RightNormalDetector.point;
            // testVector2 = LeftNormalDetector.point;
            testAngle = Mathf.Atan2(SurfNormalVector.y, SurfNormalVector.x) * Mathf.Rad2Deg;

            float NormalAngle = Mathf.Atan2(SurfNormalVector.y, SurfNormalVector.x) * Mathf.Rad2Deg;


            Quaternion targetRotation = Quaternion.Euler(0f, 0f, NormalAngle-90);

            transform.rotation = targetRotation;

            
            // LeadingTangentVector = new Vector3(FrontNormalDetector.point.x, FrontNormalDetector.point.y, 0) - transform.position;

            


        }
        else
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        
        
        MagAlongMovementVector = Mathf.Abs(Vector2.Dot(PlayerRigidbody2D.linearVelocity, MovementVector));


            //MOVEMENT CONSTRAINTS
            if(MagAlongMovementVector > MaxSpeed)
            {
            PlayerRigidbody2D.linearVelocity = new Vector2(MovementVector.normalized.x * MaxSpeed, PlayerRigidbody2D.linearVelocity.y);
            
            }

        //GROUND CONSTRAINTS
        if (isGrounded == true)
        {

            MovementVector = LeadingTangentVector.normalized * MovementSpeed;


            if(!Input.GetKey("space"))
            {
                JumpsRemaining = 1;
                DashesRemaining = 1;
            }


            

            // MagAlongMovementVector = Vector2.Dot(SurfSecVector, PlayerRigidbody2D.linearVelocity)/(SurfSecVector.magnitude*SurfNormalVector.magnitude);
            
            // if(InputMotionSync > 1)
            // {
            //     InputMotionSync = 1;
            // }

            // if(InputMotionSync < 0)
            // {
            //     PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x * -1,PlayerRigidbody2D.linearVelocity.y);
            // }
        }
        else
        {
            MovementSpeed = 5;
            MovementVector = MovementVector = transform.right * Input.GetAxisRaw("Horizontal") * MovementSpeed;
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
        

        // if (PlayerRigidbody2D.linearVelocity.magnitude > MaxSpeed)
        // {
        //     PlayerRigidbody2D.linearVelocity = PlayerRigidbody2D.linearVelocity.normalized * MaxSpeed;
        // }

        PlayerRigidbody2D.AddForce(MovementVector);


        //JUMP

        if(Input.GetKeyDown("space") == true && JumpsRemaining >= 1)
        {
            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);

            Launchpoint = transform.position.y;
            JumpHeight = Launchpoint + 5;
            JumpVector = transform.up;
            PlayerRigidbody2D.AddForce(JumpVector * 25f, ForceMode2D.Impulse);
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


        //DIVE

        if(isGrounded == false && Input.GetKeyDown("d"))
        {

            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);

                PlayerRigidbody2D.AddForce(new Vector2(0,-5f));

        }


        // TAKE DAMAGE
        if (isDamaged == true)
        {
            PlayerRigidbody2D.AddForce((transform.position - Enemy.transform.position), ForceMode2D.Impulse);
        } 



        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isDamaged = true;
            PlayerRigidbody2D.AddForce(((transform.position - Enemy.transform.position) + Vector3.up*2)*0.1f, ForceMode2D.Impulse);
        }
        else
        {
            isDamaged = false;
        }

        

    }




// void OnCollisionEnter(Collision Enemycollision) {
//     if (Enemycollision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
//         isDamaged = true;
//     }
// }

void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

}
