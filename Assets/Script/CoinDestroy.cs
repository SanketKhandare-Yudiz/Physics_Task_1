using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    private Spawn_Building building;
    private int CoinCount = 0;
    //public TextMeshProUGUI ScoreValue;
    public ScoreManager SM;


    private void Awake()
    {
        SM = FindObjectOfType<ScoreManager>();
    }
    public void SetBuilding(Spawn_Buildi)
    {
        this.building = building;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            SM.UpdateScore();
            
            Destroy(gameObject); // Destroy the coin when collected by the player
          
            Debug.Log("Coins :" + CoinCount);
        
            //ScoreValue.text = CoinCount.ToString();
        }
    }
}
