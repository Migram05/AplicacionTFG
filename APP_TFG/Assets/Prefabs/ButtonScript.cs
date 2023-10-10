using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class ButtonScript : MonoBehaviour
{
    GameObject canvasChild;
    GameObject buttonChild;
    GameObject textChild;
    int buttonNumber;

    public void setNumber(int number)
    {
        buttonNumber = number;
        canvasChild = transform.GetChild(0).gameObject;
        buttonChild = canvasChild.transform.GetChild(0).gameObject;
        textChild = buttonChild.transform.GetChild(0).gameObject;
        textChild.GetComponent<TextMeshProUGUI>().text = number.ToString(); //Se ajusta el nombre del texto al número
        if(Manager.instance.getCurrentDay() != number)
        {
            buttonChild.GetComponent<Image>().color = Color.gray; //Pone en gris los días que no sean el actual
            buttonChild.GetComponent<Button>().enabled = false;
        }
    }
    public void onClicked()
    {
        int sceneToLoad = 3;
        if (Manager.instance.getCurrentDay() != buttonNumber) sceneToLoad = 2; //Si no es el día actual, carga la escena de resumen del día
            StartCoroutine(Manager.instance.LoadSceneDelayed(0, sceneToLoad)); //Carga la escena de 
    }
}
