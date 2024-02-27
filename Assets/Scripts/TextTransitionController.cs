using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextTransitionController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float transitionSpeed;

    public bool fadeToBlack;
    public bool fadeFromBlack;
    private bool _transition;

    private void FadeToBlack()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b,
            Mathf.MoveTowards(text.color.a, 0f, transitionSpeed * Time.deltaTime));
        if (text.color.a == 0f)
        {
            fadeToBlack = false;
        }
    }

    private void FadeFromBlack()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b,
            Mathf.MoveTowards(text.color.a, 1f, transitionSpeed * Time.deltaTime));
        if (Math.Abs(text.color.a - 1.0f) < .0001f)
        {
            fadeFromBlack = false;
        }
    }
    private void Update()
    {
        if (fadeFromBlack)
        {
            FadeFromBlack();
        }
        if (fadeToBlack)
        {
            FadeToBlack();
        }

        if (Input.GetKey(KeyCode.Return) && !fadeFromBlack)
        {
            fadeToBlack = true;
            _transition = true;
        }
    }

    private void LateUpdate()
    {
        if (_transition && !fadeToBlack)
            LoadNightmare();
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        fadeFromBlack = true;
    }

    private static void LoadNightmare()
    {
        SceneManager.LoadScene("Nightmare_Start", LoadSceneMode.Single);
    }
}
