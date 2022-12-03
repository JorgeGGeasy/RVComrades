using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios;


    public AudioSource controlAudio;

    public void SeleccionarAudio(int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }

}
