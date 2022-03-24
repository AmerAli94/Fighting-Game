using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public PlayerBehaviour player;
    public EnemyController enemy;
    public Scrollbar playerHealthBar;
    public Scrollbar enemyHealthBar;

    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealthBar.size > player.healthPercent)
        {
            playerHealthBar.size -= 0.01f;
        }
        if (enemyHealthBar.size > enemy.healthPercent)
        {
            enemyHealthBar.size -= 0.01f;
        }

        if(player.isDead)
        {
            loseScreen.SetActive(true);
        }

        if(enemy.currentState == States.DEAD)
        {
            winScreen.SetActive(true);
        }

    }

    public void OnRematchPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
