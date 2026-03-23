using UnityEngine;

public class MidtermEnemySpawnerScript : MonoBehaviour
{
    public MidtermPlayerScript player;

    public Transform EnemiesParent;
    public GameObject NewEnemy;

    public GameObject Enemy;
    public Vector3 SpawnPosition;
    public int TotalEnemies;
    public int EnemiesLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TotalEnemies = 10;
        EnemiesLeft = 10;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.15f, 1.3f, 0f));
        if(EnemiesLeft < TotalEnemies)
        {
            TotalEnemies = EnemiesLeft;
            NewEnemy = Instantiate(Enemy, SpawnPosition, Quaternion.identity);
            NewEnemy.transform.parent = EnemiesParent;

        MidtermEnemyScript enemyScript = Enemy.GetComponent<MidtermEnemyScript>();
        enemyScript.midtermEnemySpawnerScript = this;
        enemyScript.MidtermPlayerScript = player;
        }
        
    }
}
