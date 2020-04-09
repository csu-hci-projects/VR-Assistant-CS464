using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void startPractice()
    {
        SceneManager.LoadScene(1);
    }

    public void startDoorUIPractice()
    {
        SceneManager.LoadScene(2);
    }

    public void startDoorTabletPractice()
    {
        SceneManager.LoadScene(4);
    }

    public void startBlockUIPractice()
    {
        SceneManager.LoadScene(6);
    }

    public void startBlockTabletPractice()
    {
        SceneManager.LoadScene(8);
    }

    public void startBlock()
    {
        SceneManager.LoadScene(2);
    }

    


    public void quitGame()
    {
        Application.Quit();
    }
}
