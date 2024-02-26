using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //event handling inputs and actions in menu
    public static event Action EnterEvent;
    
    //game state variables
    private static bool _loadNightmare;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
            EnterEvent?.Invoke();
        if (Input.GetAxis("Horizontal") != 0)
        {
            
        }
    }

    public static void SetLoadNightmare(bool value)
    {
        _loadNightmare = value;
    }
}