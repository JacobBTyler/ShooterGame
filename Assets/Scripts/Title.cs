using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public GameObject titleUI;
    public GameObject settingsUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void settingsClick()
    {
        titleUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void backClick()
    {
        settingsUI.SetActive(false);
        titleUI.SetActive(true);
    }
}
