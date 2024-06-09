using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private TMP_Text killCountText;
    private int killCount;

    private void Awake() {
        if(instance == null)
            instance = this;
    }

    public void EnemyKilled()
    {
        killCount++;
        killCountText.text = "Kills : " + killCount;
    }

    public void RestartGame()
    {
        Invoke("Restart", 3f);
    }

    void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
