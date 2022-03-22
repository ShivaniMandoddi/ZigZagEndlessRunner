using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorecalculator : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score()
    {
        score = score + 5;
        scoreText.text = "Score : " + score;
        Debug.Log(score);

    }
    
}
