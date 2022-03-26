using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentTile;
    public GameObject[] tilesPrefab;
    
    Stack<GameObject> rightTile = new Stack<GameObject>();
    Stack<GameObject> forwardTile = new Stack<GameObject>();

    //Singleton means we can only create single object out of it. We can't create multiple objects from it.
    private static TIleSpawnManager instance;
    
   /* private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
     
       // static TIleSpawnManager Instance { get => instance; }
    }*/
    public static TIleSpawnManager Instance { 
                get { 
                if(instance==null)
                {
                instance = GameObject.FindObjectOfType<TIleSpawnManager>();
                }
               
                return instance; } 
                }

    void Start()
    {
        //Instantiate(rightTile,currentTile.transform.GetChild(1).position,Quaternion.identity);

        /*for (int i = 0; i < 10; i++)
        {
            //SpawnTile();
            CreateTile();
        }*/
        CreateTile(20);       // Creating a pool of 20 tiles

        for (int i = 0; i < 10; i++)       // Spawing 10 tiles and setting as inactive
        {
            SpawnTile();
        }
         
       
    }

    public void SpawnTile()
    {
       /* int k = Random.Range(0, 2);
        int index = Random.Range(0, 10);
        
        currentTile = Instantiate(tilesPrefab[k], currentTile.transform.GetChild(k).position, Quaternion.identity);
        if (index == 2)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }*/
       /*if(rightTile.Count==0 || forwardTile.Count==0)
        {
            CreateTile(2);

        }*/
        int k = Random.Range(0, 2);                            // Spawning a random tile 
        int index = Random.Range(0, 10);
        if (k == 0)
        {
            GameObject temporaryTile = forwardTile.Pop();
            temporaryTile.SetActive(true);
            temporaryTile.transform.position=currentTile.transform.GetChild(0).position;
            currentTile = temporaryTile;
        }
        else if(k==1)
        {
            GameObject temporaryTile = rightTile.Pop();
            temporaryTile.SetActive(true);
            temporaryTile.transform.position = currentTile.transform.GetChild(1).position;
            currentTile = temporaryTile;
        }
        if (index == 2)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        Debug.Log(index);



    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void CreateTile(int value)
    {
        
            for (int i = 0; i < value; i++)          // Creating Right and Forward TIles 
            {
                rightTile.Push(Instantiate(tilesPrefab[1]));
                tilesPrefab[1].SetActive(false);
                forwardTile.Push(Instantiate(tilesPrefab[0]));
                tilesPrefab[0].SetActive(false);
                rightTile.Peek().name = "RightTile";          // Changing names of Tile gameObjects
                forwardTile.Peek().name = "ForwardTile";
            }
        
       
    }

    public void BackToRightPool(GameObject obj)     // Sending back the tile into pool
    {
        //obj.GetComponent<Rigidbody>().isKinematic = true;
        
        rightTile.Push(obj);
        //Debug.Log(obj);
        rightTile.Peek().SetActive(false);
        
    }
    public void BackToForwardPool(GameObject obj)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = true;
        forwardTile.Push(obj);
        forwardTile.Peek().SetActive(false);
        
    }

}