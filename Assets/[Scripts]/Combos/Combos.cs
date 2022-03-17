using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combo", menuName = "New Combo")]
public class Combos : ScriptableObject
{
    [SerializeField] 
    public List<KeyCode> comboKeyCodes; //the List and order of the Moves

    [SerializeField] 
    public combosList comboType; //The kind of the move

    [SerializeField] 
    public int ComboPriorty = 0; //the more complicated the move the higher the Priorty

    public bool isComboAvailable(List<KeyCode> playerKeyCodes) //Check if we can perform this move from the entered keys
    {
        int comboIndex = 0;

        for (int i = 0; i < playerKeyCodes.Count; i++)
        {
            if (playerKeyCodes[i] == comboKeyCodes[comboIndex])
            {
                comboIndex++;
                if (comboIndex == comboKeyCodes.Count) //The end of the Combo List
                    return true;
            }
            else
                comboIndex = 0;
        }
        return false;
    }

    //Getters
    public int GetComboCount()
    {
        return comboKeyCodes.Count;
    }
    public int GetComboPriorty()
    {
        return ComboPriorty;
    }
    public combosList GetMove()
    {
        return comboType;
    }
}
