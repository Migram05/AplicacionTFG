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
        string processedInput = mainInputField.text;
        if (isGoodText) Manager.instance.setTodayGoodThings(processedInput);
        else Manager.instance.setTodayBadthings(processedInput);
    }
}
