using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Door : InteractiveBase
{
    [Header("Настройка перехода")]
    [SerializeField] private SceneAsset nextScene;

    protected override void Interact()
    {
        SceneManager.LoadScene(nextScene.name);
    }
}
