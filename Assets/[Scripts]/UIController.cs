using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public PlayerBehaviour player;
    public Scrollbar playerHealthBar;

    // Update is called once per frame
    void Update()
    {
        if(playerHealthBar.size > player.healthPercent)
        {
            playerHealthBar.size -= 0.01f;
        }
        
    }
}
