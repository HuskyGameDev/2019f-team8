using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_MainController : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("menu_Options");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("menu_Main");
    }

    public void GoToFirstCutscene()
    {
        SceneManager.LoadScene("FirstCutScene");
    }

    public void GoToCutsceneTemplate()
    {
        SceneManager.LoadScene("cutSceneTemplate");
    }

    public void QutiGame()
    {
        Application.Quit();
    }
}
