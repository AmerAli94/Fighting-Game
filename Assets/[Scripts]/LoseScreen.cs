using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoseScreen : MonoBehaviour
{
    public GameObject rematchButton_Lose;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(rematchButton_Lose);
    }
}
