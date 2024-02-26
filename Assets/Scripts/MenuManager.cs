using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<Text> listOfMenuOptions;

    [SerializeField] private MenuNavigation menuNavigation;

    public MenuManager(List<Text> listOfMenuOptions)
    {
        this.listOfMenuOptions = listOfMenuOptions;
    }

    private const string TagForMenuItems = "menuItem";

    private void Start()
    {
        menuNavigation = GetComponentInChildren<MenuNavigation>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag(TagForMenuItems))
            {
                listOfMenuOptions.Add(child.GetComponent<Text>());
                if (child.GetComponent<Text>().text == "Continue?")
                {
                    //here I will check for save files and if there are none...
                    //have the text color be greyed out and and blocked
                }
            }
        }
    }

    public List<Text> GetMenuList()
    {
        return listOfMenuOptions;
    }
}
