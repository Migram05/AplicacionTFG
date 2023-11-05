using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputDateCheck : MonoBehaviour
{
    public enum check{ inputDayCheck, inputMonthCheck, inputYearCheck }
    [SerializeField]
    private check mInputDateCheck;
    private TMP_InputField mainInputField;
    private bool correctInfo = false;
    public bool getCorrectInfo() { return correctInfo; }
    // Start is called before the first frame update
    void Start()
    {
        mainInputField = gameObject.GetComponentInChildren<TMP_InputField>();
        //Añade un callback para cuando se termina de editar el input field
        mainInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        //mainInputField.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    // Llamada cuando cambia el valor del input field.
    public void ValueChangeCheck()
    {
        string processedInput = mainInputField.text;
        switch (mInputDateCheck)
        {
            case check.inputDayCheck:
                correctInfo = (processedInput == Manager.instance.getCurrentDay().ToString());
                break; 
            case check.inputMonthCheck:
                processedInput = processedInput.ToUpper();
                correctInfo = ( processedInput == Manager.instance.getCurrentMonth().ToUpper());
                break; 
            case check.inputYearCheck:
                correctInfo = (processedInput == Manager.instance.getCurrentYearString());
                break; 
            default:
                Debug.Log("No se ha asignado un check a un input field");
                break;
        }
    }
}
