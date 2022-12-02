using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class ComportamientoObjeto : MonoBehaviour
{
    private bool videoBool = false;
    public void EmpezarJuego()
    {

    }

    public void EmpezarVideo()
    {

    }

    public void Controles()
    {

    }

    public void Salir()
    {

    }

    public void PonerVideoEnTele()
    {
        if (!videoBool)
        {
            Debug.Log("Entra");
            GameObject television = GameObject.FindGameObjectWithTag("video");
            VideoPlayer video = television.GetComponent<VideoPlayer>();
            video.Play();
            videoBool = true;
        }
    }

}
