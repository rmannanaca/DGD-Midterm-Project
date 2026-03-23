using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermGameManagerScript : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    public MidtermPlayerScriptOld midtermPlayerScriptOld;

    public GameObject Enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        

        //GAME OVER
        if(midtermPlayerScriptOld.HealthRemaining <= 0)
        {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        }
        // if(midtermPlayerScriptOld.HealthRemaining <= 0)
        // {
        //     SceneManager.LoadScene("Game Over");
        // }

        //WIN SCREEN
        if (midtermPlayerScriptOld.youWin == true)
        {
            Destroy(Enemies);
            winPanel.SetActive(true);
            Time.timeScale = 0f; 
        }


    }
}
