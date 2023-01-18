using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{

    Rigidbody _rb;

    public bool _ballControl;
    public bool _collisionControl;

    public int _scorePlayer1 = 0;
    public int _scorePlayer2 = 0;
    private bool _scoreControl = true;

    public AudioSource voice;

    Scene _scene;

    
    

    private void OnCollisionEnter(Collision collision)
    {

        if(_collisionControl == true)
        {
            if(collision.collider.tag == "Player2")
            {
                voice.Play();
                
                _rb.velocity = new Vector3(-1f * _rb.velocity.x - 8f, (_rb.velocity.y) >= 0 ? _rb.velocity.y + 3f : _rb.velocity.y - 3f, 0);
                
                _collisionControl = false;
     
            }
            if(collision.collider.tag == "Player1")
            {
                voice.Play();
                
                _rb.velocity = new Vector3(-1f * _rb.velocity.x + 8f, (_rb.velocity.y) >= 0 ? _rb.velocity.y + 3f : _rb.velocity.y - 3f, 0);
                
                _collisionControl = false;

            }   
        
        }

        if(collision.collider.tag == "Obstacle")
        { 
            Debug.Log("Top Engele Çarptı");
            _rb.velocity = new Vector3(-1f * (_rb.velocity.x + 8f), (_rb.velocity.y) >= 0 ? _rb.velocity.y + 3f : _rb.velocity.y - 3f, 0);
        }

        if(collision.collider.tag == "BonusTag")
        {
            voice.Play();

            _rb.velocity = new Vector3(-1f * _rb.velocity.x - 8f, (_rb.velocity.y) >= 0 ? _rb.velocity.y + 3f : _rb.velocity.y - 3f, 0);
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MoreFast")
        {
            _rb.velocity = new Vector3((_rb.velocity.x) >= 0 ? _rb.velocity.x + 8f : _rb.velocity.x - 8f , (_rb.velocity.y) >= 0 ? _rb.velocity.y + 4f : _rb.velocity.y - 4f, 0);
        }
    }

    

    
    void Start()
    {
        _ballControl = true;
        _collisionControl = true;
        voice = GetComponent<AudioSource>();
        

        transform.position = new Vector3(0f, 0f, -.67f);

        _rb = GetComponent<Rigidbody>();
        if(_rb)
        {
            _rb.velocity = new Vector3(8f, 8f, 0);
        }

        _scorePlayer1 = PlayerPrefs.GetInt("SavedPlayer1");
        _scorePlayer2 = PlayerPrefs.GetInt("SavedPlayer2");

        // Scene scene = SceneManager.GetActiveScene();
        // Debug.Log("Active Scene is '" + scene.name+ "'.");
        // SceneManager.LoadScene ("BonusGame");

    }

    
    void Update()
    {
        if(_ballControl == true){
            if (transform.position.y >= 4.9f)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, -1f *_rb.velocity.y, 0);
                _ballControl = false;
            }
            else if (transform.position.y <= -4.9f)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, -1f *_rb.velocity.y, 0);        
                _ballControl = false;
            }
            
        }
        if((transform.position.y <4.9f) && (transform.position.y > -4.9f))
        {
            _ballControl = true;
        }

        if((transform.position.x < 8f) && (transform.position.x > -8f))
        {
            _collisionControl = true;
            _scoreControl = true;
        }

        if(_scoreControl == true){
            if(transform.position.x > 9.5f)
            {
                _scorePlayer1++;
                PlayerPrefs.SetInt("SavedPlayer1", _scorePlayer1);
                _scoreControl = false;
                Start();
            }
            if(transform.position.x < -9.5f)
            {
                _scorePlayer2++;
                PlayerPrefs.SetInt("SavedPlayer2", _scorePlayer2);
                _scoreControl = false;
                Start();
            }
        }

        
    }

    private void OnGUI()
    {
        string scoreText = "Score: " + _scorePlayer1 + " - " + _scorePlayer2;

        GUI.color = Color.black;
        GUI.Box(new Rect(20,20,100,25), scoreText);

        _scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("SavedScene", _scene.name);


        
    }
}
