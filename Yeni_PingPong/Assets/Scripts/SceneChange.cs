using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    
    
    

    public void LastGame()
    {
        if(PlayerPrefs.HasKey("SavedScene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("SavedScene"));   
        }
        else
        {
            Debug.Log("Gdsadsad");
        }
    }

    public void NormalGame()
    {
        SceneManager.LoadScene("SampleScene");   
        PlayerPrefs.SetInt("SavedPlayer1", 0);
        PlayerPrefs.SetInt("SavedPlayer2", 0);
    }
    public void BonusGame()
    {
        SceneManager.LoadScene("BonusGame"); 
        PlayerPrefs.SetInt("SavedPlayer1", 0);
        PlayerPrefs.SetInt("SavedPlayer2", 0);  
    }
    public void ObstatleGame()
    {
        SceneManager.LoadScene("ObstacleGame"); 
        PlayerPrefs.SetInt("SavedPlayer1", 0);
        PlayerPrefs.SetInt("SavedPlayer2", 0);  
    }

    public void QuitButton()
    {
        Application.Quit();
    }


}
