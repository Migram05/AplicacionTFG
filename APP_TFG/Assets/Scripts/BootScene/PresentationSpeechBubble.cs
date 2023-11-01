using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentationSpeechBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cambia el texto del inicio 
        if (Manager.instance.hasUser) gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "¡Hola " + Manager.instance.getUsername() + " !";
        else gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Hola creo que no nos conocemos ¿cómo te llamas?";
    }

    public void nuevoUsuario(string nombre)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Hola " + nombre + " !";
    }
}
