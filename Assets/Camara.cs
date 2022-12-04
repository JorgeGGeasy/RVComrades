using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] 
    GameObject personaje;
    [SerializeField] 
    float speed = 100f;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            personaje.transform.eulerAngles += Vector3.up * speed * Time.deltaTime;
            //personaje.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            personaje.transform.eulerAngles += -Vector3.up * speed * Time.deltaTime;
            //personaje.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            personaje.transform.eulerAngles += Vector3.right * speed * Time.deltaTime;
            //personaje.transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            personaje.transform.eulerAngles += -Vector3.right * speed * Time.deltaTime;
            //personaje.transform.Rotate(-Vector3.right * speed * Time.deltaTime);
        }
    }
}
