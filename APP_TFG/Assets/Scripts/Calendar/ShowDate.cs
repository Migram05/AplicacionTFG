using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    bool showDay = true;
    [SerializeField]
    bool showDayName = false;
    [SerializeField]
    bool showMonth = true;
    [SerializeField]
    bool showYear = true;
    void Start()
    {
        if (!showDay) showDayName = false; //No muestra el nombre del día si no se muestra el propio día
        string displayText="";
        if (showDay)
        {
            if(showDayName) displayText += Manager.instance.getCurrentDayName() + " "; //Escribe el nombre del día
            displayText += Manager.instance.getCurrentDay() + " ";
        }
        if (showMonth) displayText += Manager.instance.getCurrentMonth() + " ";
        if (showYear) displayText += Manager.instance.getCurrentYearString() + " ";
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = displayText; //Ajusta el texto
    }
}
