using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNameInputField : MonoBehaviour
{
    private TMP_InputField mainInputField;
    public void Start()
    {
        mainInputField = gameObject.GetComponent<TMP_InputField>();
        //Añade un callback para cuando se termina de editar el input field
        mainInputField.onEndEdit.AddListener(delegate { ValueChangeCheck(); });
    }

    // Llamada cuando cambia el valor del input field.
    public void ValueChangeCheck()
    {
        mainInputField.enabled = false;//Desactivamos el input
        string processedInput = mainInputField.text.ToLower();
        //Ajusta el nombre para que esté la primera letra en mayúsculas y las demás en minúsculas
        processedInput = char.ToUpper(processedInput[0]) + processedInput.Remove(0, 1);
        Manager.instance.changeUserName(processedInput); //Ajusta el nombre de usuario
        mainInputField.text = "¡NOMBRE CAMBIADO!";
    }
}
