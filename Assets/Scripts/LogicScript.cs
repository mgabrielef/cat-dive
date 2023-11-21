using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore+=1;
        scoreText.text = playerScore.ToString();
    }

    public int returnScore()
    {
        if (playerScore != 0){
            return playerScore;
        }else{
            return 0;
        }
        
    }
}
