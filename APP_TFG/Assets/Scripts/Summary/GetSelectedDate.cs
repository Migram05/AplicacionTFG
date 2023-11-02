using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetSelectedDate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string displayText = "";
        displayText += Manager.instance.getSelectedDay() + " "; //Escribe el nombre del día
        displayText += Manager.instance.getCurrentMonth() + " ";
        displayText += Manager.instance.getCurrentYearString() + " ";
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = displayText; //Ajusta el texto
    }
}
