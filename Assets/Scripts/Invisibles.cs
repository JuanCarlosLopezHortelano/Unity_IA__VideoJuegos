
using UnityEngine;

public class ActivarDesactivarObjeto : MonoBehaviour
{
    private bool activado = false;
    private float tiempoEspera = 45f; // 60 segundos

    private void Start()
    {
        gameObject.SetActive(false);
        Invoke("ActivarObjeto", tiempoEspera);
    }

    private void ActivarObjeto()
    {
        gameObject.SetActive(true);
        activado = true;
    }

    private void Update()
    {
        if (activado)
        {
           
        }
    }
}