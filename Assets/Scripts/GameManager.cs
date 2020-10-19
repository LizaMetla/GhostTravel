using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverPanel;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CallGameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(GameOver());
        
    }

     IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
