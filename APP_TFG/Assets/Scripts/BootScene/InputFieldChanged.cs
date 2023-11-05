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
        //A�ade un callback para cuando se termina de editar el input field
        mainInputField.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    // Llamada cuando cambia el valor del input field.
    public void ValueChangeCheck()
    {
        string processedInput = mainInputField.text.ToLower();
        processedInput = processedInput.Trim(); //Le quitamos los espacios del principio y el final
        if (processedInput.Length == 0) //Comprobaci�n de que el nombre no es vac�o
        {
            if (valueChangedText)
            {
                valueChangedText.GetComponent<PresentationSpeechBubble>().textoBurguja("Escribe un nombre v�lido");
            }
            return;
        }
        mainInputField.enabled = false;//Desactivamos el input
       
        //Ajusta el nombre para que est� la primera letra en may�sculas y las dem�s en min�sculas
        processedInput = char.ToUpper(processedInput[0]) + processedInput.Remove(0, 1);
        
        if (valueChangedText)
        {
            valueChangedText.GetComponent<PresentationSpeechBubble>().textoBurguja("�Hola " + processedInput + "!");
        }
        Manager.instance.setUserName(processedInput); //Ajusta el nombre de usuario
        
    }
}
