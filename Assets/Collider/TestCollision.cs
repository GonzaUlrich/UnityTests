using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Material que se va a asignar cuando ocurra una colisión.
    public Material Color;

    // Este método se ejecuta automáticamente cuando el objeto choca con otro objeto.
    // "collision" es la información de esa colisión (como qué objeto fue golpeado).
    private void OnCollisionEnter(Collision collision)
    {
        // Cambia el material (color o textura) del objeto que chocó por el material especificado en "Color".
        gameObject.GetComponent<Renderer>().material = Color;
    }

    // Este método se ejecuta automáticamente cuando otro objeto entra en el "trigger" del objeto actual.
    // "other" es el objeto que entró en el área de activación del "trigger".
    private void OnTriggerEnter(Collider other)
    {
        // Destruye el objeto al que está unido este script cuando otro objeto entra en su área de activación.
        Destroy(gameObject);
    }
}