
using UnityEngine;

public class ActivarDesactivarObjeto : MonoBehaviour
{
    private bool activado = false;
    private float tiempoEspera = 10f; // 60 segundos

    private void Start()
    {
        // Desactiva el objeto al principio
        gameObject.SetActive(false);
        // Inicia la cuenta regresiva para activarlo
        Invoke("ActivarObjeto", tiempoEspera);
    }

    private void ActivarObjeto()
    {
        // Activa el objeto después del tiempo de espera
        gameObject.SetActive(true);
        activado = true;
    }

    private void Update()
    {
        // Opcional: Puedes agregar lógica adicional aquí si lo necesitas
        if (activado)
        {
            // El objeto ya está activado
            // Puedes realizar acciones adicionales si es necesario
        }
    }
}