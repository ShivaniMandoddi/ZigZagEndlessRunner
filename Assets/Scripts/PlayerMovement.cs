using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            //If player is moving foward , then make him to move left
            if(direction==Vector3.forward)
            {
                direction = Vector3.left;
      
            }
            else 
            {
                direction = Vector3.forward;
               
            }
            
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);


    }
    
}
