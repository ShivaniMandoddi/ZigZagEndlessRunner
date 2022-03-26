using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
     Rigidbody rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        
    
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            TIleSpawnManager.Instance.SpawnTile();
            rb.isKinematic = false;
            StartCoroutine("FallDown");
        }
    }
    IEnumerator FallDown()
    {
        //yield return (new WaitForSeconds(1f));
        //Debug.Log("Falling Down");
        //rb.isKinematic = false;
        yield return (new WaitForSeconds(2f));

        rb.isKinematic = true;
        //Debug.Log("Stop Falling");
        //Debug.Log(gameObject);
        //Debug.Log(gameObject.transform.parent.name);
        //Debug.Log(TIleSpawnManager.Instance.name);
       
        GameObject parentgameObject = this.transform.parent.gameObject;           
        if (gameObject.transform.parent.name == "RightTile")
            TIleSpawnManager.Instance.BackToRightPool(parentgameObject);      // Calling the method to send back the tile to pool
        if (gameObject.transform.parent.name == "ForwardTile")
            TIleSpawnManager.Instance.BackToForwardPool(parentgameObject);
        /*
        if (TIleSpawnManager.Instance.name == "RightTile")
            TIleSpawnManager.Instance.BackToRightPool(gameObject);
        if (TIleSpawnManager.Instance.name == "ForwardTile")
            TIleSpawnManager.Instance.BackToForwardPool(gameObject);*/
    }

}
