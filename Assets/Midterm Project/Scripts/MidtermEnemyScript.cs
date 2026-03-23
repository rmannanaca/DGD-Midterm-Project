using UnityEngine;

public class MidtermEnemyScript : MonoBehaviour
{

    public MidtermEnemySpawnerScript midtermEnemySpawnerScript;
    public MidtermPlayerScriptOld midtermPlayerScriptOld;
    public Vector2 enemyPath;
    public float trackingTime;
    public float trackingDuration;


    public void Initialize(MidtermEnemySpawnerScript spawner, MidtermPlayerScriptOld player)
    {
        midtermEnemySpawnerScript = spawner;
        midtermPlayerScriptOld = player;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackingTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.parent = spawner.EnemiesParent;

        trackingDuration = 500f;

        trackingTime += Time.deltaTime;
        enemyPath = midtermPlayerScriptOld.transform.position - transform.position;

        transform.position = Vector2.Lerp(transform.position, midtermPlayerScriptOld.transform.position, trackingTime/trackingDuration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            midtermEnemySpawnerScript.EnemiesLeft--;
            Destroy(gameObject);
        }

        if(midtermPlayerScriptOld.youWin == true)
        {
            Destroy(gameObject);
        }
    }
}
