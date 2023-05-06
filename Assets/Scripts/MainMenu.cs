using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneAsset[] scenes;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame(Dropdown menu)
    {
        if (menu.value > scenes.Length)
        {
            Debug.LogError("UI �������� �������! �������� Dropdown �� ������������� ����������� ������� ����!");
            Application.Quit(1);
            return;
        }

        SceneManager.LoadScene(scenes[menu.value].name);
    }
}
