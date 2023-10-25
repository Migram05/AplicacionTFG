using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonDateCheck : MonoBehaviour
{
    [SerializeField]
    private List<InputDateCheck> objectsToCheck;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        bool cont = true;
        while(i < objectsToCheck.Count && cont)
        {
            cont = objectsToCheck[i].getCorrectInfo();
            ++i;
        }
        gameObject.GetComponent<Button>().interactable = cont;
    }
    public void onClicked()
    {
        StartCoroutine(Manager.instance.LoadSceneDelayed(0,4));
    }
}
