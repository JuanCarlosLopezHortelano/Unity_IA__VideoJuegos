using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Walker_leader_red : MonoBehaviour
{
 private Rigidbody rb; 

 private int count;
 private int vidascount = 3;

 private float movementX;
 private float movementY;

 public float speed = 0;

 public TextMeshProUGUI countText;
 public TextMeshProUGUI vidascountText;

 public GameObject winTextObject;
 public GameObject loseTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        SetVidasCountText();

        winTextObject.SetActive(false);
        
        StartCoroutine(RandomMovement());

    }
 

 
    IEnumerator RandomMovement()
    {
        while (true)
        {
            // Genera valores aleatorios para las coordenadas X y Z
            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);

            // Crea un vector de movimiento con las coordenadas aleatorias
            Vector3 movement = new Vector3(randomX, 0.0f, randomZ);

            // Aplica la velocidad y actualiza la posición
            rb.velocity = movement * speed;

            // Espera un momento antes de generar otro movimiento
            yield return new WaitForSeconds(Random.Range(1f, 3f));
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
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        rb.AddForce(movement * speed); 
    }

 
 void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
             other.gameObject.SetActive(false);

             count = count + 1;

             SetCountText();
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Walker_Blue"))
        {
            if (vidascount > 0)
            {
                vidascount = vidascount - 1;
            }
            SetVidasCountText();
        }
    }

    void SetCountText() 
        {
            countText.text = "Red: " + count.ToString();

        if (count >= 12)
        {
            // Display the win text.
            winTextObject.SetActive(true);
        }
    }

    void SetVidasCountText()
    {
        vidascountText.text = "Vidas Red: " + vidascount.ToString();

        if (vidascount == 0)
        {
            // Display the lose text.
            loseTextObject.SetActive(true);
        }
    }
}