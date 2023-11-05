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

    // Llamada cuando cambia el valor del input field.
    public void ValueChangeCheck()
    {
        string processedInput = mainInputField.text.ToLower();
        processedInput = processedInput.Trim(); //Le quitamos los espacios del principio y el final
        if (processedInput.Length == 0) //Comprobación de que el nombre no es vacío
        {
            if (valueChangedText)
            {
                valueChangedText.GetComponent<PresentationSpeechBubble>().textoBurguja("Escribe un nombre válido");
            }
            return;
        }
        mainInputField.enabled = false;//Desactivamos el input
       
        //Ajusta el nombre para que esté la primera letra en mayúsculas y las demás en minúsculas
        processedInput = char.ToUpper(processedInput[0]) + processedInput.Remove(0, 1);
        
        if (valueChangedText)
        {
            valueChangedText.GetComponent<PresentationSpeechBubble>().textoBurguja("¡Hola " + processedInput + "!");
        }
        Manager.instance.setUserName(processedInput); //Ajusta el nombre de usuario
        
    }
}
