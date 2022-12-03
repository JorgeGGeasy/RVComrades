using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    private Coroutine tp;
    private bool tpBool = true;
    [SerializeField]
    private AudioClipManager audioClipManager;

    public void ejecutaSalto(Vector3 saltoPos)
    {
        if(tpBool == true)
        {
            tp = StartCoroutine(TP(saltoPos));
        }
    }

    IEnumerator TP(Vector3 salto)
    {
        tpBool = false;
        transform.position = new Vector3(salto.x, 1.6f, salto.z);
        audioClipManager.SeleccionarAudio(1, 0.5f);
        yield return new WaitForSeconds(.3f);
        tpBool = true;
    }
}
