using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?


//MOD 2////////////
public float speed;

    void Start()
        {
            speed = 5f;
        }

    void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
//MOD 2////////////

        public void GetBumped()
        {
            //This destroys the coin
            Destroy(gameObject);
        }
}
