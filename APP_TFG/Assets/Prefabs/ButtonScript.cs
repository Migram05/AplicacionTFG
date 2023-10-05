using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    GameObject canvasChild;
    GameObject buttonChild;
    GameObject textChild;

    public void setNumber(int number)
    {
        canvasChild = transform.GetChild(0).gameObject;
        buttonChild = canvasChild.transform.GetChild(0).gameObject;
        textChild = buttonChild.transform.GetChild(0).gameObject;
        textChild.GetComponent<TextMeshProUGUI>().text = number.ToString();
        if(Manager.instance.getCurrentDay() != number)
        {
            buttonChild.GetComponent<Image>().color = Color.gray; //Pone en gris los d�as que no sean el actual
            buttonChild.GetComponent<Button>().enabled = false;
        }
    }
}
