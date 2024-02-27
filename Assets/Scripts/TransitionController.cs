using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private float transitionSpeed;

    public bool fadeFromBlack;
    public bool fadeToBlack;

    public void FadeToBlack()
    {
        
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
            Mathf.MoveTowards(blackScreen.color.a, 1f, transitionSpeed * Time.deltaTime));
        if (Math.Abs(blackScreen.color.a - 1.0f) < .0001f)
        {
            fadeToBlack = false;
        }
    }

    public void FadeFromBlack()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
            Mathf.MoveTowards(blackScreen.color.a, 0f, transitionSpeed * Time.deltaTime));
        if (blackScreen.color.a == 0f)
        {
            fadeFromBlack = false;
        }
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    private void Update()
    {
        if (fadeFromBlack)
        {
            FadeFromBlack();
        }
        else if (fadeToBlack)
        {
            FadeToBlack();
        }
    }

    private void Start()
    {
        fadeFromBlack = true;
    }
}
