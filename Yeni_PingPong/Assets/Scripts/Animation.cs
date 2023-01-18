using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    Animator _reduction;
    
    void Start()
    {
        _reduction = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            _reduction.SetBool("Next", true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
