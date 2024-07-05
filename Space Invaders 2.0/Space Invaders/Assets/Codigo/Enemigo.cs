using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject disparoEnemigo;
    public Transform puntoDisparo;
    public float intervaloMinDisparo = 1f;
    public float intervaloMaxDisparo = 5f;
    private float proximoDisparo;
    ContadorEnemigos contadorEnemigos;



    private void Start()
    {
        ReiniciarTiempo();
        contadorEnemigos = GameObject.FindObjectOfType<ContadorEnemigos>();

    }

    private void FixedUpdate()
    {
        proximoDisparo -= Time.deltaTime;

        if (proximoDisparo <= 0f)
        {
            DispararMisil();
            ReiniciarTiempo();
        }
    }

    private void ReiniciarTiempo()
    {
        proximoDisparo = Random.Range(intervaloMinDisparo, intervaloMaxDisparo);
    }

    private void DispararMisil()
    {
        Vector3 puntoDisparo = transform.position;
        GameObject disparo = Instantiate(disparoEnemigo, puntoDisparo, Quaternion.identity);
        disparo.GetComponent<DisparoEnemigo>().Inicializar(Vector2.down); 
    }
  
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("DisparoJugador"))
        {
            Destroy(colision.gameObject);
            Destroy(gameObject);
            contadorEnemigos.EnemigoDestruido();
        }
    }

}
