using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GoToForest()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
