using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    Vector3 direction;
    float time;
    Scorecalculator scorecalculator;
    TIleSpawnManager tileSpawnManager;
    
    void Start()
    {
        //tileSpawnManager = GameObject.Find("TileSpawnManager").GetComponent<TIleSpawnManager>();
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
    private void OnTriggerExit(Collider other)
    {
        //if (gameObject.tag == "Player")
        
           TIleSpawnManager.Instance.SpawnTile();
            //tileSpawnManager.SpawnTile();
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            scorecalculator = GameObject.Find("ScoreManager").GetComponent<Scorecalculator>();
            scorecalculator.Score();

        }
    }
    
}
    

