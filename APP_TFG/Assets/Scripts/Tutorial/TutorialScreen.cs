using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialScreen : MonoBehaviour
{
    private void Start()
    {
        if (!Manager.instance.getShowTutorial())
        {
            gameObject.SetActive(false);
        }
    }
    public void clickedTutorial()
    {
        gameObject.SetActive(false);
    }
}
