using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class ComportamientoObjeto : MonoBehaviour
{
    private bool videoBool = false;
    private bool tarjeta = false;


    // Evento Pasar Tarjeta Lector -----------
    [SerializeField]
    private GameObject tarjetaAAnimar; 
    [SerializeField]
    private GameObject puerta; 
    [SerializeField]
    private Material materialRojo; 
    [SerializeField]
    private Material materialVerde;
    // Evento Pasar Tarjeta Lector ------------

    // Easter egg -----------
    [SerializeField]
    private int botonNumero;
    [SerializeField]
    private int mandoNumero;
    [SerializeField]
    private int palancaNumero;
    bool botonBool = false;
    bool mandoBool = false;
    bool palancaBool = false;
    [SerializeField]
    GameObject videoControl;
    // Easter egg -----------


    void Start(){
        materialRojo.color =  Color.HSVToRGB(0,1,1);
        materialVerde.color =  Color.HSVToRGB(0.35f,1,0.2f);
    }

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


    public void RecogerTarjeta(GameObject tarjetaGO){
        tarjeta = true;
        tarjetaGO.SetActive(false);

    }

    public void PasarTarjetaLector(){
        if(tarjeta){ 
            tarjeta = false; 
            StartCoroutine(IEPasarTarjetaLector()); 
            
        }

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

    public void ActivarBoton(GameObject boton)
    {
        if (!botonBool)
        {
            StartCoroutine(IEActivarBoton(boton));
        }
    }

    public void ActivarMando(GameObject mandos)
    {
        if (!mandoBool)
        {
            StartCoroutine(IEActivarMando(mandos));
        }
    }

    public void ActivarPalanca(GameObject palanca)
    {
        if (!palancaBool) 
        {
            StartCoroutine(IEActivarPalanca(palanca));
        }
    }


    IEnumerator IEPasarTarjetaLector(){
        
        tarjetaAAnimar.SetActive(true);
        tarjetaAAnimar.GetComponent<Animator>().Play("Tarjeta");
        //empezar animacion de la tarjeta
        yield return new WaitForSeconds(1f); // misma duracion que la animacion
        //empezar animacion de la puerta
        tarjetaAAnimar.SetActive(false);
        materialRojo.color =  Color.HSVToRGB(0,1,0.2f);
        materialVerde.color =  Color.HSVToRGB(0.35f,1,1f);
        
        puerta.GetComponent<Animator>().Play("Puerta");
        yield return new WaitForSeconds(1f);
        puerta.GetComponent<Animator>().enabled = false; // parar animacion
    }

    IEnumerator IEActivarBoton(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Boton");
        botonBool = true;
        yield return new WaitForSeconds(1f);
        botonNumero++;
        botonBool = false;
    }

    IEnumerator IEActivarMando(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Mando");
        yield return new WaitForSeconds(1f);
        mandoNumero++;
        mandoBool = false;
    }

    IEnumerator IEActivarPalanca(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Palanca");
        yield return new WaitForSeconds(1f);
        palancaNumero++;
        palancaBool = false;
        ComprobarEasterEgg();
    }

    public void ComprobarEasterEgg()
    {
        if(botonNumero == 2 && palancaNumero == 2 && mandoNumero == 2)
        {
            // Aqui se playea el easter egg
            videoControl.SetActive(true);
            videoControl.GetComponent<VideoPlayer>().Play();
        }
    }
}
