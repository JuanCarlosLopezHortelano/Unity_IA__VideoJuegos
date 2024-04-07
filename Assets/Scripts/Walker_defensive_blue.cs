using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Walker_defensive_blue : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;
    private GameObject target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("walker_leader_blue");
        if(target == null)
        {
            Debug.LogError("No se encontró el objetivo con el tag 'walker_leader_blue'");
        }
        else
        {
            // Inicia el movimiento hacia el objetivo
            StartCoroutine(MoveTowardsTarget());
        }
    }



    IEnumerator MoveTowardsTarget()
{
    while (true)
    {
        // Calcula el vector dirección hacia el objetivo
        Vector3 direction = (target.transform.position - transform.position).normalized;

        // Verifica la distancia al objetivo
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        // Si está cerca, alejarse; de lo contrario, acercarse
        if (distanceToTarget < 2.0f) // Ajusta esta distancia según sea necesario
        {
            // Aplica el movimiento en sentido contrario
            rb.velocity = -direction * speed;
        }
        else
        {
            // Aplica el movimiento hacia el objetivo
            rb.velocity = direction * speed;
        }

        // Espera un momento antes de volver a calcular el movimiento
        yield return new WaitForSeconds(0.5f);
    }
}


    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


}
