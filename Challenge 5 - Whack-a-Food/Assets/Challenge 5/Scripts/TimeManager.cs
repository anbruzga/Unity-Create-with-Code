using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    private int timeLeft = 60;
    public TextMeshProUGUI timeLeftText;
    private GameManagerX gameManagerX;
    // Start is called before the first frame update

    void Start()
    {
        
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTimer()
    {
        timeLeft = 60;
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (gameManagerX.isGameActive)
        {

            yield return new WaitForSeconds(1);
            timeLeft -= 1;
            timeLeftText.text = "Time: " + timeLeft;
            if (timeLeft <= 0)
            {
                gameManagerX.GameOver();
            }
        }
    }

}
