using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [SerializeField] 
    public List<Combos> avilableMoves; //All the Avilable Moves
    public PlayerBehaviour playerController;
    ControlManager controlManager;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerBehaviour>();
        controlManager = FindObjectOfType<ControlManager>();

        avilableMoves.Sort(Compare); //Sort all the moves based on thier prioraty
    }

    public bool CanMove(List<KeyCode> keycodes) //return true if the list contain a move
    {
        foreach (Combos combo in avilableMoves)
        {
            if (combo.isComboAvailable(keycodes))
                return true;
        }
        return false;
    }

    public void PlayMove(List<KeyCode> keycodes) //Send the moves to the player starting from the highest priorty
    {
        foreach (Combos combo in avilableMoves)
        {
            if (combo.isComboAvailable(keycodes))
            {
                playerController.PlayMove(combo.GetMove(), combo.GetComboPriorty());
                break;
            }
        }
    }



    public int Compare(Combos combo1, Combos combo2)
    {
        return Comparer<int>.Default.Compare(combo1.GetComboPriorty(), combo2.GetComboPriorty());
    }
}
