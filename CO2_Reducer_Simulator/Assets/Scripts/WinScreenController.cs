using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    //UI stuff
    public GameObject redWin;
    public GameObject blueWin;

    // Start is called before the first frame update
    void Start()
    {
        redWin.SetActive(false);
        blueWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            if (GameManager.player1Win)
            {
                redWin.SetActive(true);
            }
            else
            {
                blueWin.SetActive(true);
            }

            Time.timeScale = 0;
        }
    }
}
