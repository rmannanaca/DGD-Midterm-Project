using UnityEngine;

public class MidtermEnemyScript : MonoBehaviour
{

    public MidtermEnemySpawnerScript midtermEnemySpawnerScript;
    public MidtermPlayerScript MidtermPlayerScript;
    public Vector2 enemyPath;
    public float trackingTime;
    public float trackingDuration;


    public void Initialize(MidtermEnemySpawnerScript spawner, MidtermPlayerScript player)
    {
        midtermEnemySpawnerScript = spawner;
        MidtermPlayerScript = player;
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
        enemyPath = MidtermPlayerScript.transform.position - transform.position;

        transform.position = Vector2.Lerp(transform.position, MidtermPlayerScript.transform.position, trackingTime/trackingDuration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            midtermEnemySpawnerScript.EnemiesLeft--;
            Destroy(gameObject);
        }

        if(MidtermPlayerScript.youWin == true)
        {
            Destroy(gameObject);
        }
    }
}
