using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField]
    private float velDisparo = 5.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * velDisparo * Time.deltaTime); 

        //Destruccion de objetos
        if(transform.position.y>=6.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
