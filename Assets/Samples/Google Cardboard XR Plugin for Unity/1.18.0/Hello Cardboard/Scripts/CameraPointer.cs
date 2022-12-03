//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    int layerMask;
    int suelo;
    [SerializeField]
    private GameObject mira;
    [SerializeField]
    private GameObject player;

    private RectTransform miraImagen;

    RaycastHit hitSuelo;

    private void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("interactuable");
        suelo = 1 << LayerMask.NameToLayer("suelo");
        miraImagen = mira.GetComponentInChildren<RectTransform>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.

        mira.transform.position = transform.position + transform.forward * _maxDistance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, layerMask))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExitObject");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterObject");
                Debug.Log(miraImagen.localScale);
                miraImagen.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExitObject");
            _gazedAtObject = null;
            miraImagen.localScale = new Vector3(1f, 1f, 1f);
            Vector3 posicion = player.transform.localPosition;
            posicion.y = 1.5f;
            if (Physics.Raycast(transform.position, transform.forward, out hitSuelo, _maxDistance, suelo))
            {
                player.GetComponent<LineRenderer>().SetPosition(0, posicion);
                player.GetComponent<LineRenderer>().SetPosition(1, hitSuelo.point);
            }
            else
            {
                player.GetComponent<LineRenderer>().SetPosition(1, posicion);
                player.GetComponent<LineRenderer>().SetPosition(1, posicion);
            }
        }

        // Checks for screen touches.
        if (Input.GetButton("R1"))
        {
            Debug.Log("R1 pulsado");
            _gazedAtObject?.SendMessage("OnPointerClickObject");
        }

        if (Input.GetButton("R2"))
        {
            
            if (Physics.Raycast(transform.position, transform.forward, out hitSuelo, _maxDistance, suelo))
            {
                player.GetComponent<Teletransporte>().ejecutaSalto(hitSuelo.point);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("R1 pulsado");
            _gazedAtObject?.SendMessage("OnPointerClickObject");
        }

        if (Input.GetMouseButtonDown(1))
        {

            if (Physics.Raycast(transform.position, transform.forward, out hitSuelo, _maxDistance, suelo))
            {
                player.GetComponent<Teletransporte>().ejecutaSalto(hitSuelo.point);
            }
        }
            /*
            if (Input.GetButtonDown("R1"))
            {
                Debug.Log("R1 pulsado");
            }
            */

            //Importante estos son los controles
            /*
            R1 B7
            R2 B6

            Eje y Axis0
            Eje x Axis1

            A B4
            B B0
            C B3
            D B1

            En android

            A b5
            B b1
            C b4
            D b2
            R1 9
            R2 7
            */

        }
}
