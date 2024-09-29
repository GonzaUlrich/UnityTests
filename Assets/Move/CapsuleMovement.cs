using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    // Esta variable controlar� la velocidad de movimiento lateral y frontal de la c�psula.
    public float moveSpeed = 5f;

    // Esta variable controla la fuerza con la que la c�psula va a saltar.
    public float jumpForce = 7f;

    // Esta variable indica la velocidad de rotaci�n de la c�psula.
    public float rotationSpeed = 100f;

    // Esta variable indica si la c�psula est� en el suelo o no.
    private bool isGrounded;

    // Referencia al componente Rigidbody para aplicar la f�sica (movimiento y salto).
    private Rigidbody rb;

    // Este m�todo se llama al iniciar el juego, inicializamos el Rigidbody aqu�.
    void Start()
    {
        // Obtenemos el componente Rigidbody de la c�psula para poder controlar la f�sica.
        rb = GetComponent<Rigidbody>();
    }

    // Este m�todo se llama una vez por cuadro (frame), se encarga del movimiento de la c�psula.
    void Update()
    {
        // Capturamos el input (entrada del jugador) para mover la c�psula hacia los lados (eje horizontal).
        float moveInputHorizontal = Input.GetAxis("Horizontal");

        // Capturamos el input para mover la c�psula hacia adelante y atr�s (eje vertical).
        float moveInputVertical = Input.GetAxis("Vertical");

        // Movemos la c�psula hacia los lados multiplicando el input horizontal por la velocidad y el tiempo.
        transform.Translate(Vector3.right * moveInputHorizontal * moveSpeed * Time.deltaTime);

        // Movemos la c�psula hacia adelante y atr�s multiplicando el input vertical por la velocidad y el tiempo.
        transform.Translate(Vector3.forward * moveInputVertical * moveSpeed * Time.deltaTime);

        // Capturamos el input para rotar la c�psula hacia la izquierda (Q) o hacia la derecha (E).
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotamos la c�psula hacia la izquierda sobre su eje Y (vertical).
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            // Rotamos la c�psula hacia la derecha sobre su eje Y (vertical).
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Si el jugador presiona la barra espaciadora y la c�psula est� en el suelo, entonces salta.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicamos una fuerza hacia arriba en el Rigidbody para que la c�psula salte.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Cambiamos la variable isGrounded a false porque ya no est� en el suelo.
            isGrounded = false;
        }
    }

    // Este m�todo se llama cuando la c�psula toca el suelo o cualquier otra superficie.
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si la c�psula toc� el suelo. Si es as�, volvemos a activar el salto.

        // Cuando toca el suelo, establecemos que la c�psula est� en el suelo.
        isGrounded = true;

    }
}
