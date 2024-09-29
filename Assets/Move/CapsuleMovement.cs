using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    // Esta variable controlará la velocidad de movimiento lateral y frontal de la cápsula.
    public float moveSpeed = 5f;

    // Esta variable controla la fuerza con la que la cápsula va a saltar.
    public float jumpForce = 7f;

    // Esta variable indica la velocidad de rotación de la cápsula.
    public float rotationSpeed = 100f;

    // Esta variable indica si la cápsula está en el suelo o no.
    private bool isGrounded;

    // Referencia al componente Rigidbody para aplicar la física (movimiento y salto).
    private Rigidbody rb;

    // Este método se llama al iniciar el juego, inicializamos el Rigidbody aquí.
    void Start()
    {
        // Obtenemos el componente Rigidbody de la cápsula para poder controlar la física.
        rb = GetComponent<Rigidbody>();
    }

    // Este método se llama una vez por cuadro (frame), se encarga del movimiento de la cápsula.
    void Update()
    {
        // Capturamos el input (entrada del jugador) para mover la cápsula hacia los lados (eje horizontal).
        float moveInputHorizontal = Input.GetAxis("Horizontal");

        // Capturamos el input para mover la cápsula hacia adelante y atrás (eje vertical).
        float moveInputVertical = Input.GetAxis("Vertical");

        // Movemos la cápsula hacia los lados multiplicando el input horizontal por la velocidad y el tiempo.
        transform.Translate(Vector3.right * moveInputHorizontal * moveSpeed * Time.deltaTime);

        // Movemos la cápsula hacia adelante y atrás multiplicando el input vertical por la velocidad y el tiempo.
        transform.Translate(Vector3.forward * moveInputVertical * moveSpeed * Time.deltaTime);

        // Capturamos el input para rotar la cápsula hacia la izquierda (Q) o hacia la derecha (E).
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotamos la cápsula hacia la izquierda sobre su eje Y (vertical).
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            // Rotamos la cápsula hacia la derecha sobre su eje Y (vertical).
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Si el jugador presiona la barra espaciadora y la cápsula está en el suelo, entonces salta.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicamos una fuerza hacia arriba en el Rigidbody para que la cápsula salte.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Cambiamos la variable isGrounded a false porque ya no está en el suelo.
            isGrounded = false;
        }
    }

    // Este método se llama cuando la cápsula toca el suelo o cualquier otra superficie.
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si la cápsula tocó el suelo. Si es así, volvemos a activar el salto.

        // Cuando toca el suelo, establecemos que la cápsula está en el suelo.
        isGrounded = true;

    }
}
