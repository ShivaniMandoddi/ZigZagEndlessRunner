using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentTile;
    public GameObject[] tilesPrefab;
    float time;
   
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

        for (int i = 0; i < 10; i++)
        {
            SpawnTile();

        }

    }

    public void SpawnTile()
    {
        int k = Random.Range(0, 2);
        int index = Random.Range(0, 10);
        
        currentTile = Instantiate(tilesPrefab[k], currentTile.transform.GetChild(k).position, Quaternion.identity);
        if (index == 2)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime + time;
        if(time>8f)
        {
            Destroy(GameObject.FindGameObjectWithTag("Platform"));
            time = 0f;
        }
        
    }
    
  
}