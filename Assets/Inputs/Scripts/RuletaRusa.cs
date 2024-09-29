/*
Estas líneas son como un aviso al programa de que va a usar ciertas funciones y herramientas que vienen de Unity. 
Es como decirle al código: "quiero usar los bloques básicos para construir este juego
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Aquí se está creando una "clase", que es como un plano para construir el objeto del juego llamado RuletaRusa. 
Todo lo que pongamos dentro de esta clase definirá cómo funciona nuestro juego. MonoBehaviour es una parte especial 
de Unity que le dice al programa que este objeto va a tener algunas funciones que se ejecutan en el juego.
 */
public class RuletaRusa : MonoBehaviour
{


    /*
     Material Die: Este es el material (o color/imagen) que se mostrará cuando "mueras".
     Material YouAreOk: Este es el material que se mostrará cuando estés "a salvo".
    int Chances: Este es un número que representa cuántas probabilidades tienes en el juego (por ejemplo,
    si este número es 6, tienes 1 de 6 chances de "morir").
     */
    public Material Die;
    public Material YouAreOk;
    public int Chances;

    //Aquí estamos creando una variable llamada actualNumber, que va a guardar un número aleatorio cada vez que juegues.
    private int actualNumber;


    /*
     Esta es una función especial que Unity ejecuta constantemente, una y otra vez. Todo lo que pongamos aquí se 
    va a comprobar todo el tiempo mientras el juego esté corriendo.
    */
    void Update()
    {
        /*
         Esto le dice al juego: "si el jugador presiona la tecla Espacio en el teclado, haz lo siguiente...". 
        Entonces, cada vez que se presiona esa tecla, se ejecutará el resto del código dentro de este bloque.
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
             Aquí el juego elige un número al azar entre 0 y la cantidad de "Chances" que definimos antes. Este número 
            va a decidir si "mueres" o no. Debug.Log es como un mensaje que se muestra en la pantalla de desarrollo para que los
            creadores del juego puedan ver qué número salió.
             */
            actualNumber = Random.Range(0, Chances);
            Debug.Log("El numero que salio es: " + actualNumber);
            /*
             Si el número aleatorio que salió es 0, eso significa que "mueres".
            Entonces se mostrará el mensaje "Moriste" en la consola, y el objeto en el juego cambiará su 
            color o apariencia al material que elegimos como Die (por ejemplo, podría volverse rojo
             */
            if (actualNumber == 0)
            {
                Debug.Log("Moriste");
                gameObject.GetComponent<Renderer>().material = Die;
            }
            /*
             Si el número no es 0, el jugador está "a salvo".
            Entonces se muestra el mensaje "Safaste" en la consola, y el objeto cambia su color o 
            apariencia al material YouAreOk (por ejemplo, podría volverse verde).
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
