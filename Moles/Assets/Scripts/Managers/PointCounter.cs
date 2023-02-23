using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public static PointCounter instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;

    int points = 0;

    int timer = 20;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        text.text = "Puntos: " + points;
    }

    private void Start()
    {
        timerText.text = timer.ToString();
        StartCoroutine(TimerDown());
    }

    public void Score()
    {
        points++;
        text.text = "Puntos: " + points;
    }

    IEnumerator TimerDown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            timerText.text = timer.ToString();
        }
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Enhorabuena, has hecho " + points + " puntos";
        Time.timeScale = 0;
    }
}
