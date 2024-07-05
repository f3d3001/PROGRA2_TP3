using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public float velocidad = 10f;
    private Vector2 direccion;

    public void Inicializar(Vector2 direccionInicial)
    {
        direccion = direccionInicial;
    }

    private void FixedUpdate()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

}
