using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinScreen : MonoBehaviour
{

    public GameObject rematchButton_Win;


    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(rematchButton_Win);
    }
}
