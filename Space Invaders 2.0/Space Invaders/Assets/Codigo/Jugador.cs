using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    public GameObject disparoJugador;
    public Transform posicionDisparo;
    public float velocidad = 10f;
    private Camera mainCamera;
    

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movimiento = new Vector3(moveHorizontal, 0f) * velocidad * Time.deltaTime;

        Vector3 minViewportBordes = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 maxViewportBordes = mainCamera.ViewportToWorldPoint(new Vector3(1, 1));

        Vector3 newPosition = transform.position + movimiento;
        newPosition.x = Mathf.Clamp(newPosition.x, minViewportBordes.x, maxViewportBordes.x);

        transform.position = newPosition;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }

    }

    private void Disparar()
    {
        Vector3 posicionDisparo = transform.position;
        GameObject disparo = Instantiate(disparoJugador, posicionDisparo, Quaternion.identity);
        disparo.GetComponent<DisparoJugador>().Inicializar(Vector2.up);
    }

    private void OnCollisionEnter2D(Collision2D colision)   
    {
        if (colision.gameObject.CompareTag("DisparoEnemigo"))
        {
            Destroy(colision.gameObject);
            Destroy(gameObject);

            SceneManager.LoadScene("Perder");
        }
    }   

}
