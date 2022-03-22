using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button start;
    public Button instructions;
    public Button settings;
    public Button back;
    public GameObject instructionsPanel;
    public GameObject homePanel;
    public GameObject settingsPanel;
    void Start()
    {
        start.onClick.AddListener(Starts);
        instructions.onClick.AddListener(Instructions);
        settings.onClick.AddListener(Settings);
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
   
    public void Starts()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Instructions()
    {
        instructionsPanel.SetActive(true);
        homePanel.SetActive(false);
        back.gameObject.SetActive(true);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
        homePanel.SetActive(false);
        back.gameObject.SetActive(true);
    }
    public void Back()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        homePanel.SetActive(true);
        back.gameObject.SetActive(false);

    }
}
