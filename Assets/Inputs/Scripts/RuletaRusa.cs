/*
Estas l�neas son como un aviso al programa de que va a usar ciertas funciones y herramientas que vienen de Unity. 
Es como decirle al c�digo: "quiero usar los bloques b�sicos para construir este juego
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Aqu� se est� creando una "clase", que es como un plano para construir el objeto del juego llamado RuletaRusa. 
Todo lo que pongamos dentro de esta clase definir� c�mo funciona nuestro juego. MonoBehaviour es una parte especial 
de Unity que le dice al programa que este objeto va a tener algunas funciones que se ejecutan en el juego.
 */
public class RuletaRusa : MonoBehaviour
{


    /*
     Material Die: Este es el material (o color/imagen) que se mostrar� cuando "mueras".
     Material YouAreOk: Este es el material que se mostrar� cuando est�s "a salvo".
    int Chances: Este es un n�mero que representa cu�ntas probabilidades tienes en el juego (por ejemplo,
    si este n�mero es 6, tienes 1 de 6 chances de "morir").
     */
    public Material Die;
    public Material YouAreOk;
    public int Chances;

    //Aqu� estamos creando una variable llamada actualNumber, que va a guardar un n�mero aleatorio cada vez que juegues.
    private int actualNumber;


    /*
     Esta es una funci�n especial que Unity ejecuta constantemente, una y otra vez. Todo lo que pongamos aqu� se 
    va a comprobar todo el tiempo mientras el juego est� corriendo.
    */
    void Update()
    {
        /*
         Esto le dice al juego: "si el jugador presiona la tecla Espacio en el teclado, haz lo siguiente...". 
        Entonces, cada vez que se presiona esa tecla, se ejecutar� el resto del c�digo dentro de este bloque.
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
             Aqu� el juego elige un n�mero al azar entre 0 y la cantidad de "Chances" que definimos antes. Este n�mero 
            va a decidir si "mueres" o no. Debug.Log es como un mensaje que se muestra en la pantalla de desarrollo para que los
            creadores del juego puedan ver qu� n�mero sali�.
             */
            actualNumber = Random.Range(0, Chances);
            Debug.Log("El numero que salio es: " + actualNumber);
            /*
             Si el n�mero aleatorio que sali� es 0, eso significa que "mueres".
            Entonces se mostrar� el mensaje "Moriste" en la consola, y el objeto en el juego cambiar� su 
            color o apariencia al material que elegimos como Die (por ejemplo, podr�a volverse rojo
             */
            if (actualNumber == 0)
            {
                Debug.Log("Moriste");
                gameObject.GetComponent<Renderer>().material = Die;
            }
            /*
             Si el n�mero no es 0, el jugador est� "a salvo".
            Entonces se muestra el mensaje "Safaste" en la consola, y el objeto cambia su color o 
            apariencia al material YouAreOk (por ejemplo, podr�a volverse verde).
             */
            else
            {
                Debug.Log("Safaste");
                gameObject.GetComponent<Renderer>().material = YouAreOk;
            }
            Debug.Log("--------------");
        }
    }
}
