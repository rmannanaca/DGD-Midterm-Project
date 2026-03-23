using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermGameManagerScript : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    public MidtermPlayerScript MidtermPlayerScript;

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
        if(MidtermPlayerScript.HealthRemaining <= 0)
        {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        }
        // if(MidtermPlayerScript.HealthRemaining <= 0)
        // {
        //     SceneManager.LoadScene("Game Over");
        // }

        //WIN SCREEN
        if (MidtermPlayerScript.youWin == true)
        {
            Destroy(Enemies);
            winPanel.SetActive(true);
            Time.timeScale = 0f; 
        }


    }
}
