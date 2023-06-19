using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ingameButtons;
    public Animator anim;

    //Remember that DisableUI controls disabling of the firebutton on pause, and on change of phase

    void Update()
    {

    }
    public void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        anim.SetTrigger("Pausemenu");
        ingameButtons.SetActive(false);
    }
    public void Resume()
    {
        ingameButtons.SetActive(true);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
