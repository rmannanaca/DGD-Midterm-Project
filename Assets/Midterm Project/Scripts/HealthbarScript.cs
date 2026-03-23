using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{

    public Image Healthbar;
    public float HealthRemaining;

    public MidtermPlayerScriptOld midtermPlayerScriptOld;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthRemaining = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(midtermPlayerScriptOld.isDamaged == true)
        // {
        //     HealthRemaining--;
        // }

        Healthbar.fillAmount = midtermPlayerScriptOld.HealthRemaining/midtermPlayerScriptOld.PlayerTotalHealth;
    }
}
