using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class DayPrefabScript : MonoBehaviour
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
        textChild.GetComponent<TextMeshProUGUI>().text = number.ToString(); //Se ajusta el nombre del texto al n�mero
        if (!Manager.instance.canInteractWithButton(number))
        {
            buttonChild.GetComponent<Image>().color = Color.gray; //Pone en gris los d�as que no sean el actual
            buttonChild.GetComponent<Button>().enabled = false;
        }
        else
        {
            if(Manager.instance.getCurrentDay() == number)
            {
                if(Manager.instance.todayInformationSaved()) buttonChild.GetComponent<Image>().color = Color.green; //Si hay informaci�n guardada del d�a de hy se marca de color diferente
                else buttonChild.GetComponent<Image>().color = Color.cyan; //El dia actual se marca con color cyan
            }
        }
    }
    public void clickedButton()
    {

        Manager.instance.callendarButtonClicked(buttonNumber);
    }
}
