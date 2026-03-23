using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{

    public Image Healthbar;
    public float HealthRemaining;

    public MidtermPlayerScript MidtermPlayerScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthRemaining = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(MidtermPlayerScript.isDamaged == true)
        // {
        //     HealthRemaining--;
        // }

        Healthbar.fillAmount = MidtermPlayerScript.HealthRemaining/MidtermPlayerScript.PlayerTotalHealth;
    }
}
