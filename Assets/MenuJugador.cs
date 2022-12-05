using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJugador : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    bool menuBool = false;
    bool esperar = false;

    public void Update()
    {
        
        if (Input.GetMouseButtonDown(2))
        {
            if (esperar == false)
            {
                StartCoroutine(Activar());
            }
        }
        
        if (Input.GetButton("A"))
        {
            if(esperar == false){
                StartCoroutine(Activar());
            }   
            
        }

        /*
        if (Input.GetButton("AM"))
        {
            menuBool = !menuBool;
            menu.SetActive(menuBool);
        }
        */
    }

    IEnumerator Activar()
    {
        menuBool = !menuBool;
        esperar = true;
        menu.SetActive(menuBool);
        yield return new WaitForSeconds(.3f);
        esperar = false;
    }
}
