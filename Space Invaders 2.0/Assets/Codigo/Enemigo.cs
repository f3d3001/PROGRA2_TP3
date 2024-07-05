using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Enemigo : MonoBehaviour
{
    public GameObject disparoEnemigo;
    public Transform puntoDisparo;
    public float intervaloMinDisparo = 1f;
    public float intervaloMaxDisparo = 5f;
    private float proximoDisparo;
    ContadorEnemigos contadorEnemigos;
    private AudioSource audioSource;
    public GameObject explosionPrefab; 



    private void Start()
    {
        ReiniciarTiempo();
        contadorEnemigos = GameObject.FindObjectOfType<ContadorEnemigos>();
        audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        proximoDisparo -= Time.deltaTime;

        if (proximoDisparo <= 0f)
        {
            DispararMisil();
            audioSource.Play();
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
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(colision.gameObject);
            Destroy(gameObject);
            contadorEnemigos.EnemigoDestruido();
        }
        else if (colision.gameObject.CompareTag("Misilazo"))
        {
            Destroy(gameObject);
            contadorEnemigos.EnemigoDestruido();
        }

    }

}
