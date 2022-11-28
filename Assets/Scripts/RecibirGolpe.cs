using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RecibirGolpe : MonoBehaviour
{
    public UnityEvent myEvent;

    private bool entrarBool = true;

    private bool pulsarBool = true;

    [SerializeField]
    private Objeto objeto;

    public void OnPointerEnterObject()
    {
        if (entrarBool)
        {
            StartCoroutine(Entrar());
        }
    }
    public void OnPointerExitObject()
    {
        // Aqui sacamos el tipo de objeto y ejecutamos su interacción.
        if (objeto.boton)
        {
            this.GetComponent<Animator>().SetTrigger("Normal");
        }
        else
        {
            this.GetComponent<Renderer>().material.renderQueue = 2001;
        }
    }
    public void OnPointerClickObject()
    {
        if (pulsarBool)
        {
            StartCoroutine(Pulsar());
        }
    }

    IEnumerator Entrar()
    {
        entrarBool = false;
        // Aqui sacamos el tipo de objeto y ejecutamos su interacción.

        if (objeto.boton)
        {
            this.GetComponent<Animator>().SetTrigger("Highlighted");
        }
        else
        {
            this.GetComponent<Renderer>().material.renderQueue = 1999;
        }
        yield return new WaitForSeconds(.1f);
        entrarBool = true;
    }

    IEnumerator Pulsar()
    {
        pulsarBool = false;
        myEvent.Invoke();
        // Aqui sacamos el tipo de objeto y ejecutamos su interacción.

        if (objeto.boton)
        {
            this.GetComponent<Animator>().SetTrigger("Pressed");
        }


        yield return new WaitForSeconds(1f);
        pulsarBool = true;
    }
}