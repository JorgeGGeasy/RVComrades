using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RecibirGolpe : NetworkBehaviour
{
    public UnityEvent myEvent;

    private bool entrarBool = true;

    private bool pulsarBool = true;

    [SerializeField]
    private Objeto objeto;

    private bool pulsarIndex;

    private void OnEnable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.RegisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.UnregisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.UnregisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }

    public struct PositionIndex : IBroadcast
    {
        public bool pIndex;
    }

    private void OnPositionBroadcast(PositionIndex indexStruct)
    {
        pulsarIndex = indexStruct.pIndex;
    }

    private void OnClientPositionBroadcast(NetworkConnection networkConnection, PositionIndex indexStruct)
    {
        InstanceFinder.ServerManager.Broadcast(indexStruct);
    }

    public void OnPointerEnterObject()
    {
        if (entrarBool)
        {
            if (InstanceFinder.IsServer)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            else if (InstanceFinder.IsClient)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            EntrarServer();
        }
    }
    public void OnPointerExitObject()
    {
        if (InstanceFinder.IsServer)
        {
            InstanceFinder.ServerManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
        }
        else if (InstanceFinder.IsClient)
        {
            InstanceFinder.ClientManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
        }
        SalirServer();
    }
    public void OnPointerClickObject()
    {
        if (pulsarBool)
        {
            if (InstanceFinder.IsServer)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            else if (InstanceFinder.IsClient)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { pIndex = pulsarBool });
            }
            PulsarServer();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void EntrarServer()
    {
        EntrarObserver();
    }

    [ObserversRpc]
    void EntrarObserver()
    {
        StartCoroutine(Entrar());
    }

    [ServerRpc(RequireOwnership = false)]
    void SalirServer()
    {
        SalirObserver();
    }

    [ObserversRpc]
    void SalirObserver()
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

    [ServerRpc(RequireOwnership = false)]
    void PulsarServer()
    {
        PulsarObserver();
    }

    [ObserversRpc]
    void PulsarObserver()
    {
        StartCoroutine(Pulsar());
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