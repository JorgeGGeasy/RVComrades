using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public void ejecutaSalto(Vector3 salto)
    {
        transform.position = new Vector3(salto.x, 1.6f, salto.z);
    }
}
