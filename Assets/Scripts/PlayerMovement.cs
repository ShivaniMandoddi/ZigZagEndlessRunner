using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    Rigidbody rb;
    Vector3 direction;
    float time;
    Scorecalculator scorecalculator;
    TIleSpawnManager tileSpawnManager;
    GameObject temp;
    bool IsGameOver = false;
    public Button quit;
    public Button restart;
    public GameObject gameOver;
    void Start()
    {
        //tileSpawnManager = GameObject.Find("TileSpawnManager").GetComponent<TIleSpawnManager>();
        /*for (int i = 0; i < 10; i++)
        {
            TIleSpawnManager.Instance.SpawnTile();
        }*/
        //TIleSpawnManager.Instance.SpawnTile();
        rb = GetComponent<Rigidbody>();
        quit.onClick.AddListener(Quitting);
        restart.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver == false) {

            if (Input.GetMouseButtonDown(0))
            {

                //If player is moving foward , then make him to move left
                if (direction == Vector3.forward)
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
        if(transform.position.y<-1f)        // Checking player is dead or not
        {
            IsGameOver = true;
            gameOver.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {

        //TIleSpawnManager.Instance.SpawnTile();
        //Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Coin")       //Score updating when triggered with coin 
        {
            
            other.gameObject.SetActive(false);
            scorecalculator = GameObject.Find("ScoreManager").GetComponent<Scorecalculator>();
            scorecalculator.Score();

        }
    }
    public void Quitting()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   /* private void OnCollisionExit(Collision collision)
    {
            
        
        
        if(collision.gameObject.tag=="ForwardTile")
        {
            temp = collision.gameObject;
            TIleSpawnManager.Instance.BackToForwardPool(collision.gameObject);
            //StartCoroutine("BackToForwardPool");
        }
        if (collision.gameObject.tag == "RightTile")
        {
            temp = collision.gameObject;
            TIleSpawnManager.Instance.BackToRightPool(collision.gameObject);
            //StartCoroutine("BackToRightPool");
        }
        //StartCoroutine("MakingObjInactive");
        //TIleSpawnManager.Instance.BackToRightPool(collision.gameObject);
       
        
    }
    
    IEnumerator BackToRightPool()
    {
        yield return (new WaitForSeconds(2));
        
        TIleSpawnManager.Instance.BackToRightPool(temp);
  
    }
    IEnumerator BackToForwardPool()
    {
        yield return (new WaitForSeconds(2));

        TIleSpawnManager.Instance.BackToForwardPool(temp);
    }*/
   
}
// Create an endless runner game where we need to spawn, at random positions ,at random interval,and spwaning the platform,enemy
// if your score > 100, then speed of your player should increase .try to make more enemies  

