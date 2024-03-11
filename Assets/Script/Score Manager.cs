using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score =0 ;
    public TextMeshProUGUI txt;

   public  void UpdateScore()
    {
        score += 1;
        txt.text = score.ToString();
    }
}
