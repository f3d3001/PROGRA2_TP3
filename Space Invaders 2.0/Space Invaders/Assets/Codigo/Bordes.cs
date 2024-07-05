using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("DisparoJugador"))
        {
            Destroy(colision.gameObject);
        }
        else if (colision.gameObject.CompareTag("DisparoEnemigo"))
        {
            Destroy(colision.gameObject);
        }
    }
}
