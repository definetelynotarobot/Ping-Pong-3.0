using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{

    //PLAYER 1 CONTROLS

    public float _speed = 9.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
        float verticalInput = Input.GetAxis("Player1KeyControl");
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * _speed * verticalInput);
    
        if (transform.position.y >= 3.882432f)
        {
            transform.position = new Vector3(transform.position.x, 3.882432f, -.59f);
        }
        else if (transform.position.y <= -3.882432f)
        {
            transform.position = new Vector3(transform.position.x, -3.882432f, -.59f);
        }
    }
}
