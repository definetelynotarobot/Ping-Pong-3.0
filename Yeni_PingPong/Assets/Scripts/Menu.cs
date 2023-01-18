using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject _menuObject;

    public bool _menuOpen;

    void Start()
    {
        _menuOpen = true;
    }

   
    void Update()
    {
        float inputCancel = Input.GetAxis("Cancel");
        
        if (inputCancel == 1)
        {
            _menuOpen = !_menuOpen;
        } 
        
        if(_menuOpen == true)
        {
            _menuObject.SetActive(true);
            Time.timeScale = 0.02f;
        }
        else
        {
            _menuObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void onClickResume()
    {
        _menuOpen = false;
    }

    public void onClickStartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");   
    }
}
