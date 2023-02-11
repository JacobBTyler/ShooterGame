using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;

    public bool paused = false;

    void onPlayerDeath(Player player) {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);

        Invoke("restartGame", 3);
    }

    void restartGame() {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies) {
            Destroy(enemy);
        }

        var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        applySettings();
        var cameraRig = Camera.main.GetComponent<CameraRig>();
        cameraRig.target = playerObject;
        enemyProducer.SpawnEnemies(true);
        playerObject.GetComponent<Player>().onPlayerDeath += onPlayerDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        applySettings();
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += onPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("p"))
        {
            if(paused == false)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if(Input.GetKeyDown(KeyCode.Home))
        {
            SceneManager.LoadScene("Title");
        }
        

    }

    void applySettings() {
        GameObject playerLoader = GameObject.FindGameObjectWithTag("Player");
        Color ballColor = new Color();

        switch(sceneManager.ballColor)
        {

            case 1:
                ballColor = Color.red;
                break;
            case 2:
                ballColor = Color.green;
                break;
            case 3:
                ballColor = Color.blue;
                break;
            default:
                break;
        }
        playerLoader.GetComponent<Renderer>().material.color = ballColor;
        
        if(sceneManager.oversize == true) {
            playerLoader.GetComponent<Transform>().localScale = new Vector3(2,2,2);
        }

    }
}
