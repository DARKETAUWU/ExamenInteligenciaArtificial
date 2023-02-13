using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public float speed = 5.0f; //se declara la velocidad

    private Vector3 target; //se pone el vector para poner la posicion

    NavMeshAgent agent;

    void Start()
    {
        target = transform.position; //se pone la posicion inicial para que no hayan problemas
        agent = GetComponent<NavMeshAgent>(); // Toma el agente desde los componentes para entender por donde se ira moviendo
        agent.updateRotation = false; // evita que se rote
        agent.updateUpAxis = false; // evita que se pierda en el espacio
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //al momento que se click izquierdo:
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //se localiza el lugar del click
            target.z = transform.position.z; //se deja la z en 0 para que no desaparezca
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); //se mueve hacia donde se hizo el click
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == ("Guardia")) //si se coliciona con guardia:
        {
            Respawn();
        }
    }
    void Respawn()
    {
        transform.position = new Vector3(-11, -5, 0); //se transportara hacia la esquina inferior derecha
    }

    //Para que se mueva en su entorno fue necesario crear un tilemap, pues la forma en la que estaba haciendo inicalmente de que unicamente detectara el piso 
    //no estaba funcionado, De igual manera consultamos diversos tutoriales de los cuales algunos ya no estaban actualizados a la forma en la que funciona unity
    // Cuando se ocupaba normal reinciaba su posicion en 0 en vez de buscar la solucion...
    // investigando descrubir que de igual manera que el 3d existia una version que se tenia que descargar como paquete para unity, con el cual me fue mas sencillo mover al personaje
}
