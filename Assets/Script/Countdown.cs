using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] float setTime = 60.0f;
    [SerializeField] Text countdownText;

    bool gameIsOver = false;

    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject CursorDot;

    // Use this for initialization
    void Start()
    {
        countdownText.text = Mathf.Round(setTime).ToString();

        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            if (setTime > 0)
            {
                setTime -= Time.deltaTime;
                countdownText.text = Mathf.Round(setTime).ToString();
            }
            else
            {
                // 게임이 종료된 후의 동작 추가
                GameOver();
            }
        }
    }

    void GameOver()
    {
        // 게임이 종료되었음을 표시
        gameIsOver = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CursorDot.SetActive(false);
        
        if (GameManager.score >= 5) WinScreen.SetActive(true);
        else LoseScreen.SetActive(true);
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return");
            LoadScene.LoadScene0();
        }

    }
}
