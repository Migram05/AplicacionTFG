using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfUser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Manager.instance.hasUser) gameObject.SetActive(false); //Se desativan los objetos si ya hay un usuario registrado
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
