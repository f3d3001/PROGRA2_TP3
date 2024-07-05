using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisilazoComportamiento : MonoBehaviour
{
    private GameObject explosionMisilazoPrefab;
    private float radioExplosion;
    private LayerMask capasAfectadas;


    public void Inicializar(GameObject explosion, float radio, LayerMask capas)
    {
        explosionMisilazoPrefab = explosion;
        radioExplosion = radio;
        capasAfectadas = capas;
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        CrearExplosion();
        Destroy(gameObject);
    }

    private void CrearExplosion()
    {
        
        Instantiate(explosionMisilazoPrefab, transform.position, Quaternion.identity);

        Collider2D[] objetosAfectados = Physics2D.OverlapCircleAll(transform.position, radioExplosion, capasAfectadas);

        foreach (Collider2D objeto in objetosAfectados)
        {
            Destroy(objeto.gameObject);
        }
    }
}
