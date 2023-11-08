using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDataButton : MonoBehaviour
{
    [SerializeField]
    private GameObject deleteWarning;
    public void OnCLicked_Warning()
    {
        deleteWarning.SetActive(true);
    }

    public void OnCLicked_Delete()
    {
        deleteWarning.SetActive(false);
        Manager.instance.deleteData();
    }
    public void OnClicked_Return()
    {
        deleteWarning.SetActive(false);
    }
}
