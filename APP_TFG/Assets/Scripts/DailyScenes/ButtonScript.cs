using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private void Start()
    {
        gameObject.GetComponent<Button>().interactable = false; //Para evitar un click sin querer
        StartCoroutine(enableButton());
    }

    public IEnumerator enableButton() 
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Button>().interactable = true;
    }

}
