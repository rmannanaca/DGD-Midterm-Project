using UnityEngine;

public class MidtermCameraScript : MonoBehaviour
{
    
    public MidtermPlayerScriptOld midtermPlayerScriptOld;
    public Vector3 CameraPosition; 
    public Vector3 GroundedPosition;
    public Vector3 PlayerPosition;

    public float panTime;
    public float TotalPanTime;

    public float CameraYGap;
    public bool Panning;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    transform.position = new Vector3(0,0,-10f);
    }

    // Update is called once per frame
    void Update()
    {


       PlayerPosition = midtermPlayerScriptOld.transform.position;

       CameraYGap = PlayerPosition.y - transform.position.y;



       TotalPanTime = 1.0f;

        if(midtermPlayerScriptOld.isGrounded == true && CameraYGap > -2.826995f)
        {
            Panning = true;
            panTime = 0f;

            GroundedPosition = new Vector3(PlayerPosition.x, PlayerPosition.y + 2.826995f, -10f);
            
        }

        if(Panning == true && panTime < TotalPanTime)
        {
            
            panTime += 2.0f * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, GroundedPosition, panTime/TotalPanTime);
        }
        if(panTime >= TotalPanTime)
        {
            Panning = false;
            panTime = 0f;
        }

        if(PlayerPosition.y - transform.position.y < -2.826995f)
        {
            transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y + 2.826995f, -10f);
        }

        

        transform.position = new Vector3(PlayerPosition.x, transform.position.y,-10f);
        

        // transform.position = CameraPosition;


        // if(midtermPlayerScriptOld.transform.position.y - CameraPosition.y > 5)
        // {
        //     CameraPosition = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y + 5f,-10); 
        // }

        // if(midtermPlayerScriptOld.transform.position.y - transform.position.y < -1)
        // {
        //     CameraPosition = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y + 1f,-10); 
        // }

        // void OnRay
        // {
            
        // }


    }
}
