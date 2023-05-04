using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class Talking : InteractiveBase
{
    [Header("Настройки диалогов!")]
    [SerializeField] private Text textField;
    [SerializeField, Range(0f, 1f)] private float speed;
    [SerializeField, Range(0f, 1f)] private float randomAspect;
    [SerializeField] private string text;
    private bool isTalking = false;
    private new AudioSource audio;

    private void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
    }

    private IEnumerator _talk(string _str)
    {
        isTalking = true;
        foreach (char _ch in _str)
        {
            yield return new WaitForSeconds(speed + Random.Range(-randomAspect, randomAspect));
            textField.text += _ch;
            audio.Play();
        }
        yield return new WaitForSeconds(2f);
        textField.text = "";
        isTalking = false;
    }

    private void Talk(string text)
    {
        if (!isTalking)
        {
            StartCoroutine(_talk(text));
        }
    }

    protected override void Interact()
    {
        Talk(text);
    }
}
