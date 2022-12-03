using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJugador : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    bool menuBool = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            menuBool = !menuBool;
            menu.SetActive(menuBool);
        }
    }
}
