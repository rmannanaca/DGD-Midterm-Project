using UnityEngine;

public class MidtermCameraScript : MonoBehaviour
{
    
    public MidtermPlayerScript midtermPlayerScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(midtermPlayerScript.transform.position.x, transform.position.y,-10);
    }
}
