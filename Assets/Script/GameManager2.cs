using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public GameObject Menu;
    public GameObject GameDescription;

    // Start is called before the first frame update
    void Start()
    {
        GameDescription.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void onClickGameStartBtn()
    {
        Debug.Log("game start");
        LoadScene.LoadScene1();
    }

    public void onClickGameDescriptionBtn()
    {
        Debug.Log("game descripton");
        Menu.SetActive(false);
        GameDescription.SetActive(true);
    }

    public void onClickBackBtn()
    {
        Menu.SetActive(true);
        GameDescription.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
