using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Quit()
    {   
        Debug.Log("The game has stoped!");
        Application.Quit();
    }
}
