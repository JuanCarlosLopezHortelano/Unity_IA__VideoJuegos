using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Walker_agresive_red : MonoBehaviour
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

            // Aplica la velocidad y actualiza la posición
            rb.velocity = direction * speed;

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

