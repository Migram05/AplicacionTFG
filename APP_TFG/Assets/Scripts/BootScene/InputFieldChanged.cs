using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldChanged : MonoBehaviour
{
    private TMP_InputField mainInputField;

    [SerializeField]
    private GameObject valueChangedText;
    public void Start()
    {
        if (Manager.instance.hasUser) return;
        mainInputField = gameObject.GetComponentInChildren<TMP_InputField>();
        //Añade un callback para cuando se termina de editar el input field
        mainInputField.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        mainInputField.enabled = false;//Desactivamos el input
        string processedInput = mainInputField.text.ToLower();
        //Ajusta el nombre para que esté la primera letra en mayúsculas y las demás en minúsculas
        processedInput = char.ToUpper(processedInput[0]) + processedInput.Remove(0, 1);
        if (valueChangedText)
        {
            valueChangedText.GetComponent<PresentationSpeechBubble>().nuevoUsuario(processedInput);
        }
        Manager.instance.setUserName(processedInput); //Ajusta el nombre de usuario
    }
}
