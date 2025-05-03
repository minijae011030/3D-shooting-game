using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 최종 스코어
    public static int score = 0;
    public Text TotalScore;

    
    public GameObject ControlScene;
    public GameObject CursorDot;

    public Text startMent;
    private bool isBlinking = false;

    public GameObject ExitScreen;
    public static bool isExitScreenActive;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    // Use this for initialization
    void Start()
    {
        TotalScore.text = "Kill " + score.ToString() + " / 5";

        ControlScene.SetActive(true);
        CursorDot.SetActive(false);
        ExitScreen.SetActive(false);
        isExitScreenActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore.text = "Kill " + score.ToString() + " / 5";

        if (Input.GetKeyDown(KeyCode.M))
        {
            ControlScene.SetActive(true);
            CursorDot.SetActive(false);

            // 코루틴 시작
            if (!isBlinking)
                StartCoroutine(BlinkText(startMent, 0.5f));
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ControlScene.SetActive(false);
            CursorDot.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            CursorDot.SetActive(false);
            ControlScene.SetActive(false);
            WinScreen.SetActive(false);
            LoseScreen.SetActive(false);

            ExitScreen.SetActive(true);
            isExitScreenActive = true;
        }

    }

    // 텍스트 깜빡이기 코루틴
    IEnumerator BlinkText(Text text, float blinkInterval)
    {
        isBlinking = true;

        while (true)
        {
            text.enabled = !text.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void onClickExitBtn()
    {
        Debug.Log("Exit");
        isExitScreenActive = false;
        //SceneManager.LoadScene("StartScene");
        LoadScene.LoadScene0();
    }

    public void onClickNoBtn()
    {
        Debug.Log("No");
        CursorDot.SetActive(true);
        ExitScreen.SetActive(false);
        isExitScreenActive = false;
    }

    public void LoadScene0()
    {
        LoadScene.LoadScene0();
    }

    public void LoadScene1()
    {
        LoadScene.LoadScene1();
    }
}