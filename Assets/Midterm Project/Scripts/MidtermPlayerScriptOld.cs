using UnityEngine;

public class MidtermPlayerScriptOld : MonoBehaviour
{

    public float MovementSpeed;
    public float MaxSpeed;
    public Rigidbody2D PlayerRigidbody2D;
    // public Transform PlayerTransform2D;
    public Vector2 MovementVector;
    public Vector2 MagAlongMovementVector;


    public Vector2 JumpVector;
    public float JumpHeight;
    public float Launchpoint;
    public float HangTime;

    public bool isGrounded;
    public int JumpsRemaining;

    public bool isJumping;
    public float totalJumpDuration;




    public Vector2 DashStartPoint;
    public Vector2 DashEndPoint;

    public float DashDirection;

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


    public float DashTimeElapsed;

    public Animator MidtermAnimationController;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbody2D= GetComponent<Rigidbody2D>();
        MovementSpeed = 1.0f;
        MaxSpeed = 5.0f;
        // HangTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        RightNormalDetector = Physics2D.Raycast(transform.position + transform.right * 0.20f, -transform.up, 0.55f, TargetLayers);
        LeftNormalDetector = Physics2D.Raycast(transform.position - transform.right * 0.20f, -transform.up, 0.55f, TargetLayers);
        MiddleNormalDetector = Physics2D.Raycast(transform.position, -transform.up, 0.55f, TargetLayers);
        
        FrontNormalDetector = Physics2D.Raycast(transform.position + transform.right * Input.GetAxisRaw("Horizontal") * 0.20f, -transform.up, 0.55f, TargetLayers);
        
        LeadingTangentVector = Vector3.Cross(FrontNormalDetector.normal, Vector3.forward * Input.GetAxisRaw("Horizontal")); // - transform.up * 6f
        
        
        // LeadingTangentVector = transform.right * Input.GetAxisRaw("Horizontal") * MovementSpeed - transform.up * 7.5f;

        // testVector = FrontNormalDetector.normal;


        // Debug.DrawRay(transform.position + transform.right * 0.20f, -transform.up * 0.55f, Color.green);
        // Debug.DrawRay(transform.position - transform.right * 0.20f, -transform.up * 0.55f, Color.green);
        // Debug.DrawRay(transform.position, LeadingTangentVector * 1.0f, Color.red);



        transform.rotation = Quaternion.Euler(0f,0f,0f);




        // //Match Normal and Hug Terrain
        if(MiddleNormalDetector.collider != null || LeftNormalDetector.collider != null || RightNormalDetector.collider != null)
        {
            isGrounded = true;

            // float NormalAngle = Mathf.Atan2(MiddleNormalDetector.normal.y, MiddleNormalDetector.normal.x) * Mathf.Rad2Deg;


            // Quaternion targetRotation = Quaternion.Euler(0f, 0f, NormalAngle-90);
            // transform.rotation = targetRotation;

        }
        else
        {
            isGrounded = false;
        }

        if(MiddleNormalDetector.collider == null)
        {
            if(FrontNormalDetector.collider != null)
            {
                // float NormalAngle = Mathf.Atan2(SurfNormalVector.y, SurfNormalVector.x) * Mathf.Rad2Deg;
                // Quaternion targetRotation = Quaternion.Euler(0f, 0f, NormalAngle-90);
                
                // transform.rotation = targetRotation;
            }
        }


        // if (MiddleNormalDetector && FrontNormalDetector)
        // {
        //     // SurfSecVector = RightNormalDetector.point - LeftNormalDetector.point;

        //     SurfSecVector = FrontNormalDetector.point - MiddleNormalDetector.point;

        //     SurfNormalVector = new Vector2(-SurfSecVector.y,SurfSecVector.x);

        // }
        // else
        // {
        //     transform.rotation = Quaternion.Euler(0f,0f,0f);
        // }
        
        
        //MOVEMENT "ENGINE"
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if(isGrounded == true && !Input.GetKey("space"))
            {
                PlayerRigidbody2D.linearVelocity = new Vector2(0, PlayerRigidbody2D.linearVelocity.y);
            }
        }

        PlayerRigidbody2D.AddForce(MovementVector);

        MagAlongMovementVector = Vector2.Dot(PlayerRigidbody2D.linearVelocity, MovementVector.normalized) * MovementVector.normalized;

        //MOVEMENT CONSTRAINTS
        if(MagAlongMovementVector.magnitude > MaxSpeed)
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

        }
        else
        {
            MovementSpeed = 5;
            MovementVector = transform.right * Input.GetAxisRaw("Horizontal") * MovementSpeed;
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
        


        //JUMP
        if(Input.GetKeyDown("space") == true && JumpsRemaining >= 1)
        {


            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);

            Launchpoint = transform.position.y;
            JumpHeight = Launchpoint + 3;
            JumpVector = transform.up;


            // PlayerRigidbody2D.AddForce(JumpVector * 25f, ForceMode2D.Impulse);
            
            HangTime = 0.1f;
            totalJumpDuration = 3f;

            isJumping = true;
            // HangTime = 1f;
            JumpsRemaining--;
            
        }

        // isJumping=false;

        

        if(isJumping == true && HangTime<totalJumpDuration)
        {
            
            HangTime += 3f * Time.deltaTime;

            float j = 0.02f * 1/((HangTime/totalJumpDuration) + 0.019615f) - 0.019615f;

            PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x, (75f * j));
        }

        // if(transform.position.y > JumpHeight)
        // {
        //     HangTime -= 0.05f;
        //     transform.position = new Vector2(transform.position.x, JumpHeight);

        //     if(HangTime < 0)
        //     {
        //         HangTime = 0;
        //         PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x,0);
        //     }

        // }

        //DASH
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKeyDown("f") && DashesRemaining >= 1)
        {
            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);
            
            isJumping = false;
            Dashing = true;

            DashingTime = 0;
            DashDuration = 0.25f;

            DashTimeElapsed = 0;


            DashStartPoint = transform.position;
            DashEndPoint = DashStartPoint + new Vector2(Input.GetAxisRaw("Horizontal") * 5, 0);

            DashDirection = Input.GetAxisRaw("Horizontal");

            DashesRemaining--;

        }

        if(Dashing == true && DashingTime < DashDuration)
            {
                PlayerRigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionY;
                
                // float k = Mathf.Pow(DashingTime/DashDuration, 0.5f);

                float k = (1/(90f*(DashingTime + 0.01099f))) - 0.01099f;
                DashingTime += Time.deltaTime;

                DashTimeElapsed += Time.deltaTime;

            // transform.position = Vector2.Lerp(DashStartPoint,DashEndPoint, t);

            // PlayerRigidbody2D.linearVelocity = new Vector2((21.2661f * (1 - k)),PlayerRigidbody2D.linearVelocity.y) * DashDirection;
            PlayerRigidbody2D.linearVelocity = new Vector2((80f * k),PlayerRigidbody2D.linearVelocity.y) * DashDirection;
                                                        //21.2661f
            // Vector2 TargetPosition = Vector2.Lerp(DashStartPoint,DashEndPoint, t);
            // PlayerRigidbody2D.MovePosition(TargetPosition);

        }
        else
        {
            // PlayerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            Dashing = false;
        }


        //DIVE
        if(isGrounded == false && Input.GetKeyDown("d"))
        {

            PlayerRigidbody2D.linearVelocity = new Vector2(0,0);

            
        }

        if (isGrounded == false && Input.GetKey("d"))
            {
                isJumping = false;
                PlayerRigidbody2D.AddForce(new Vector2(0,-20f));
            }


        // TAKE DAMAGE
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isDamaged = true;
            PlayerRigidbody2D.AddForce(((transform.position - Enemy.transform.position) + Vector3.up*2)*0.1f, ForceMode2D.Impulse);
        }
        else
        {
            isDamaged = false;
        }

        

        //ANIMATIONS
        if(isGrounded == true)
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                MidtermAnimationController.SetBool("isWalking", true);
            }
            else
            {
                MidtermAnimationController.SetBool("isWalking", false);
            }
        }
        if(DashingTime < DashDuration)
        {
            MidtermAnimationController.SetBool("isDashing", Dashing);
            MidtermAnimationController.SetBool("isWalking",false);
        }
        else
        {
            MidtermAnimationController.SetBool("isDashing", false);
        }

        if(PlayerRigidbody2D.linearVelocity.y < 0 && isGrounded == false)
        {
            MidtermAnimationController.SetBool("isFalling", true);
        }
        else
        {
            MidtermAnimationController.SetBool("isFalling",false);
        }


    }




void OnCollisionEnter(Collision Enemycollision) {
    if (Enemycollision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
        isDamaged = true;
    }
}

// void OnCollisionEnter2D(Collision2D other)
//     {
//         isGrounded = true;
//     }

// void OnCollisionExit2D(Collision2D other)
//     {
//         isGrounded = false;
//     }


void CustomEaseOut()
    {
        
    }



}
