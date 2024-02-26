using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private float transitionSpeed;

    public bool _fadeFromBlack;
    public bool _fadeToBlack;

    public void FadeToBlack()
    {
        
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
            Mathf.MoveTowards(blackScreen.color.a, 1f, transitionSpeed * Time.deltaTime));
        if (Math.Abs(blackScreen.color.a - 1.0f) < .0001f)
        {
            _fadeToBlack = false;
        }
    }

    public void FadeFromBlack()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
            Mathf.MoveTowards(blackScreen.color.a, 0f, transitionSpeed * Time.deltaTime));
        if (blackScreen.color.a == 0f)
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
