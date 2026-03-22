using UnityEngine;

public class MidtermCameraScript : MonoBehaviour
{
    
    public MidtermPlayerScriptOld midtermPlayerScriptOld;
    public Vector3 CameraPosition; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(midtermPlayerScriptOld.transform.position.x, transform.position.y,-10);

        // transform.position = CameraPosition;


        // if(midtermPlayerScriptOld.transform.position.y - CameraPosition.y > 5)
        // {
        //     CameraPosition = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y + 5f,-10); 
        // }

        // if(midtermPlayerScriptOld.transform.position.y - transform.position.y < -1)
        // {
        //     CameraPosition = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y + 1f,-10); 
        // }

    }
}
