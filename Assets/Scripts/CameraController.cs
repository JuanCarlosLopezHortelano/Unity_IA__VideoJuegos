using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referencia al objeto jugador
    public GameObject player;

    // Offset(diferencia entre la camara y el jugador) inicial entre la cámara y el jugador
    private Vector3 offset; 

    void Start()
    {
        // Calcula el offset inicial restando la posición de la cámara con la del jugador
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate()
    {
        // Actualiza la posición de la cámara sumando la posición del jugador y el offset
        transform.position = player.transform.position + offset;  
    }
}
