using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverPanel;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        GameOverPanel.SetActive(true);
    }
}
