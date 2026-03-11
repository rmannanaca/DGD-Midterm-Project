using UnityEngine;

public class HazardScript : MonoBehaviour
{

public float speed;


    void Start()
        {
            speed = 10f;
        }

    void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    public void GetBumped()
        {
            Destroy(gameObject);
        }

}
