using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Material que se va a asignar cuando ocurra una colisi�n.
    public Material Color;

    // Este m�todo se ejecuta autom�ticamente cuando el objeto choca con otro objeto.
    // "collision" es la informaci�n de esa colisi�n (como qu� objeto fue golpeado).
    private void OnCollisionEnter(Collision collision)
    {
        // Cambia el material (color o textura) del objeto que choc� por el material especificado en "Color".
        gameObject.GetComponent<Renderer>().material = Color;
    }

    // Este m�todo se ejecuta autom�ticamente cuando otro objeto entra en el "trigger" del objeto actual.
    // "other" es el objeto que entr� en el �rea de activaci�n del "trigger".
    private void OnTriggerEnter(Collider other)
    {
        // Destruye el objeto al que est� unido este script cuando otro objeto entra en su �rea de activaci�n.
        Destroy(gameObject);
    }
}