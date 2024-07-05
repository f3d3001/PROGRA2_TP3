using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{

    public float velocidad;
    public float distanciaMovimiento;
    public Collider2D paredIzquierda;
    public Collider2D paredDerecha;
    private Vector3 posicionActual;
    private bool haciaDerecha = true;

    private void Start()
    {
        posicionActual = transform.position;
    }

    private void Update()
    {
        MoverEnemigos();
    }

    private void MoverEnemigos()
    {
        if (haciaDerecha)
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
      
      if (colision == paredIzquierda || colision == paredDerecha)
        {
            CambiarDireccionAbajo();
        }
        
    }

    private void CambiarDireccionAbajo()
    {
        haciaDerecha = !haciaDerecha; // Cambia la dirección
        transform.position += Vector3.down * distanciaMovimiento; // Mueve una casilla hacia abajo
        posicionActual = transform.position; // Actualiza la posición inicial
    }

}
