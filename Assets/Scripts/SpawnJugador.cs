using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJugador : NetworkBehaviour
{
    [SerializeField]
    private float cameraYOffset = 0.4f;
    [SerializeField]
    private Camera playerCamera;
    public override void OnStartClient()
    {
        base.OnStartClient();
        SpawnCliente();
    }

    public void SpawnCliente()
    {
        Debug.Log("Jugador Spawneado");
        if (base.IsOwner)
        {
            Debug.Log("Soy tuyo");
            GameObject controlador = GameObject.Find("Controlador");
            gameObject.GetComponent<Teletransporte>().audioClipManager = controlador.GetComponent<AudioClipManager>();
            Canvas[] canvasHijos = gameObject.GetComponentsInChildren<Canvas>();
            controlador.GetComponent<ComportamientoObjeto>().controlesCanvas = canvasHijos[3].gameObject;
            canvasHijos[3].gameObject.GetComponentInChildren<RecibirGolpe>().myEvent.AddListener(delegate { controlador.GetComponent<ComportamientoObjeto>().CerrarControles(canvasHijos[3].gameObject); });
        }
        else
        {
            Debug.Log("No sos el dueño master");
            gameObject.GetComponent<SpawnJugador>().enabled = false;
            gameObject.GetComponent<LineRenderer>().enabled = false;
            gameObject.GetComponent<Teletransporte>().enabled = false;
            gameObject.GetComponentInChildren<CameraPointer>().enabled = false;
            gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            gameObject.GetComponentsInChildren<Canvas>()[0].gameObject.SetActive(false);
            gameObject.GetComponentsInChildren<Canvas>()[1].gameObject.SetActive(false);
            gameObject.GetComponentsInChildren<Canvas>()[2].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
