using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{


    public static float gameSpeed;
    public static int ballColor;
    public static bool oversize;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 1.0f;

        ballColor = 0;

        oversize = false;
    }

    void Update()
    {
        Debug.Log(gameSpeed);
        Debug.Log(ballColor);
        Debug.Log(oversize);
    }

 


}
