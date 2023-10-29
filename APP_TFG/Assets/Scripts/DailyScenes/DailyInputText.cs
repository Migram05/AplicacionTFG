using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DailyInputText : MonoBehaviour
{
    private TMP_InputField mainInputField;
    [SerializeField]
    bool isGoodText = false;
    void Start()
    {
        mainInputField = gameObject.GetComponentInChildren<TMP_InputField>();
        //Añade un callback para cuando se termina de editar el input field
        mainInputField.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        mainInputField.enabled = false;//Desactivamos el input
        string processedInput = mainInputField.text.ToLower();
        //Ajusta el texto para que esté la primera letra en mayúsculas y las demás en minúsculas
        processedInput = char.ToUpper(processedInput[0]) + processedInput.Remove(0, 1);
        if (isGoodText) Manager.instance.setTodayGoodThings(processedInput);
        else Manager.instance.setTodayBadthings(processedInput);
    }
}
