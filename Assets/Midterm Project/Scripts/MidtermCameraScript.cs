using UnityEngine;

public class MidtermCameraScript : MonoBehaviour
{
    
    public MidtermPlayerScriptOld midtermPlayerScriptOld;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(midtermPlayerScriptOld.transform.position.x, transform.position.y,-10);


        if(midtermPlayerScriptOld.transform.position.y - transform.position.y > 5)
        {
            transform.position = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y - 5f,-10); 
        }

        if(midtermPlayerScriptOld.transform.position.y - transform.position.y < -1)
        {
            transform.position = new Vector3(midtermPlayerScriptOld.transform.position.x, midtermPlayerScriptOld.transform.position.y + 1f,-10); 
        }

    }
}
