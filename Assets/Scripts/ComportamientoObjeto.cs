using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class ComportamientoObjeto : MonoBehaviour
{
    private bool videoBool = false;
    private bool tarjeta = false;
    private Vector3 posicionControles;

    [SerializeField]
    private bool nave;

    public GameObject controlesCanvas;

    public AudioClipManager audioClipManager;

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


    public void Start(){
        if (nave)
        {
            materialRojo.color = Color.HSVToRGB(0, 1, 1);
            materialVerde.color = Color.HSVToRGB(0.35f, 1, 0.2f);
        }
        posicionControles = controlesCanvas.GetComponent<RectTransform>().localPosition;
        Debug.Log(posicionControles);
    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene("Nave", LoadSceneMode.Single);
    }

    public void EmpezarVideo()
    {
        SceneManager.LoadScene("Video360", LoadSceneMode.Single);
    }

    public void Controles(GameObject controles)
    {

        controles.GetComponent<RectTransform>().localPosition = posicionControles;
        //controles.SetActive(true);
    }
    public void CerrarControles(GameObject controles)
    {
        controles.GetComponent<RectTransform>().localPosition = new Vector3(-1000,-1000,-1000);
        //controles.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }




    public void RecogerTarjeta(GameObject tarjetaGO){
        tarjeta = true;
        tarjetaGO.SetActive(false);
        audioClipManager.SeleccionarAudio(5, 0.5f);

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
            audioClipManager.SeleccionarAudio(0, 0.5f);
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
        audioClipManager.SeleccionarAudio(6, 0.5f);
        //empezar animacion de la tarjeta
        yield return new WaitForSeconds(1f); // misma duracion que la animacion
        //empezar animacion de la puerta
        tarjetaAAnimar.SetActive(false);
        materialRojo.color =  Color.HSVToRGB(0,1,0.2f);
        materialVerde.color =  Color.HSVToRGB(0.35f,1,1f);
        
        puerta.GetComponent<Animator>().Play("Puerta");
        audioClipManager.SeleccionarAudio(7, 0.5f);
        yield return new WaitForSeconds(1f);
        puerta.GetComponent<Animator>().enabled = false; // parar animacion

    }

    IEnumerator IEActivarBoton(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Boton");
        botonBool = true;
        audioClipManager.SeleccionarAudio(2, 0.5f);
        yield return new WaitForSeconds(1f);
        botonNumero++;
        botonBool = false;
        ComprobarEasterEgg();
    }

    IEnumerator IEActivarMando(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Mando");
        //audioClipManager.SeleccionarAudio(4, 0.5f);
        yield return new WaitForSeconds(1f);
        mandoNumero++;
        mandoBool = false;
        ComprobarEasterEgg();
    }

    IEnumerator IEActivarPalanca(GameObject objeto)
    {
        objeto.GetComponent<Animator>().Play("Palanca");
        audioClipManager.SeleccionarAudio(3, 0.5f);
        yield return new WaitForSeconds(1f);
        palancaNumero++;
        palancaBool = false;
        ComprobarEasterEgg();
    }

    public void ComprobarEasterEgg()
    {
        Debug.Log("Hola");
        if(botonNumero == 2 && palancaNumero == 2 && mandoNumero == 2)
        {
            // Aqui se playea el easter egg
            videoControl.SetActive(true);
            videoControl.GetComponent<VideoPlayer>().Play();
        }
    }
}
