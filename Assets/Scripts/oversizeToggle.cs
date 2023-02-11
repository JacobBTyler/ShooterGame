using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oversizeToggle : MonoBehaviour
{
    public void setOversize() {
        if(sceneManager.oversize == true){
            sceneManager.oversize = false;
        }
        if(sceneManager.oversize == false){
            sceneManager.oversize = true;
        }
    }
}
