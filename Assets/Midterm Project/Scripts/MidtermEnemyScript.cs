using UnityEngine;

public class MidtermEnemyScript : MonoBehaviour
{

    public MidtermPlayerScriptOld midtermPlayerScriptOld;
    public Vector2 enemyPath;
    public float trackingTime;
    public float trackingDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackingTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {

        trackingDuration = 2500f;

        trackingTime += Time.deltaTime;
        enemyPath = midtermPlayerScriptOld.transform.position - transform.position;

        transform.position = Vector2.Lerp(transform.position, midtermPlayerScriptOld.transform.position, trackingTime/trackingDuration);
    }
}
