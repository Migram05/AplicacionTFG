using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    float delayTime = 0;
    [SerializeField]
    int sceneNum = 0;
    public void onClicked()
    {
        StartCoroutine(Manager.instance.LoadSceneDelayed(delayTime, sceneNum));
    } 
}
