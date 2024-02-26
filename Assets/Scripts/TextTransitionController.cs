using System;
using UnityEngine;
using UnityEngine.UI;

public class TextTransitionController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float transitionSpeed;

    private bool _fadeToBlack;
    private bool _fadeFromBlack;

    private void FadeToBlack()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b,
            Mathf.MoveTowards(text.color.a, 1f, transitionSpeed * Time.deltaTime));
        if (Math.Abs(text.color.a - 1.0f) < .0001f)
        {
            _fadeToBlack = false;
        }
    }
    public void FadeFromBlack()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b,
            Mathf.MoveTowards(text.color.a, 0f, transitionSpeed * Time.deltaTime));
        if (text.color.a == 0f)
        {
            _fadeFromBlack = false;
        }
    }
    private void Update()
    {
        if (_fadeFromBlack)
        {
            FadeFromBlack();
        }
        else if (_fadeToBlack)
        {
            FadeToBlack();
        }
    }
    private void Start()
    {
        _fadeFromBlack = true;
    }
}
