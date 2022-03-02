using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField]
    public float ComboResetTime = 0.5f; //The Time to reset the Combo Time

    [SerializeField] 
    public List<KeyCode> KeysPressed; //List of all the Keys Pressed so far

    ComboManager comboManager;

    void Awake()
    {
        if (comboManager == null)
            comboManager = FindObjectOfType<ComboManager>();
    }

     void Update()
    {
        DetectPressedKey();
    }

    public void DetectPressedKey()
    {
        //Go through all the Keys
        //To make it faster we can attach a class and put all the keys that are allowed to be pressed
        //This will make the process a bit faster rather than moving through all keys
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                KeysPressed.Add(kcode); //Add the Key to the List

                if (!comboManager.CanMove(KeysPressed)) //if there is no avilable Moves reset the list
                    StopAllCoroutines();

                StartCoroutine(ResetComboTimer()); //Start the Reseting process
            }
        }
    }

    public void ResetCombo() //Called to Reset the Combo after a move
    {
        KeysPressed.Clear();
    }

    IEnumerator ResetComboTimer()
    {
        yield return new WaitForSeconds(ComboResetTime);

        comboManager.PlayMove(KeysPressed); //Run the move from the list
        KeysPressed.Clear(); //Empty the list
    }
}
