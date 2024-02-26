using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private List<Text> menuOptions;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private TransitionController transitionController;

    [SerializeField] private int positionIndex;
    [SerializeField] private Text selection;
    //Menu is complete and if cleaned up a little bit it can be reused for the whole game OR OTHER games.
    //Selection is here to see which option is the cursor on and with a simple check for the selection and the enter,
    //the game can then transition to whatever the next scene is, in the case start the game, or go to last checkpoint
    private float _horizontalInput;
    private float _verticalInput;
    private bool _confirm;
    private bool _changedOption;

    private void Start()
    {
        //EventManager.EnterEvent+=
        audioManager = FindObjectOfType<AudioManager>();
        transitionController = FindObjectOfType<TransitionController>();
        menuManager = GetComponentInParent<MenuManager>();
        menuOptions = menuManager.GetMenuList();
        transform.position = new Vector3(
            menuOptions.ElementAt(0).transform.position.x - 96.5f,
            menuOptions.ElementAt(0).transform.position.y - 6f, menuOptions.ElementAt(0).transform.position.z);
        positionIndex = 0;
        selection = menuOptions.ElementAt(0);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _confirm = Input.GetKey(KeyCode.Return);
        if (_confirm && selection.text == "New Game")
        {
            _changedOption = true;
            audioManager.PlayLoadSound();
            transitionController._fadeToBlack = true;
        }
        switch (_verticalInput)
        {
            case 0 when _horizontalInput == 0:
                _changedOption = false;
                return;
            case > 0 when !_changedOption:
                positionIndex++;
                _changedOption = true;
                audioManager.PlayNavSound();
                break;
            case < 0 when !_changedOption:
                positionIndex--;
                _changedOption = true;
                audioManager.PlayNavSound();
                break;
        }

        if (positionIndex < 0)
        {
            positionIndex = menuOptions.Count - 1;
            _changedOption = true;
        }
        else if (positionIndex > menuOptions.Count - 1)
        {
            positionIndex = 0;
            _changedOption = true;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            menuOptions.ElementAt(positionIndex).transform.position.x - 96.5f,
            menuOptions.ElementAt(positionIndex).transform.position.y - 6f, 
            menuOptions.ElementAt(positionIndex).transform.position.z);
        selection = menuOptions.ElementAt(positionIndex);
    }
}
