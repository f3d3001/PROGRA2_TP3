using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMisilazo : MonoBehaviour
{
    public GameObject misilPrefab; 
    public GameObject explosionMisilazoPrefab;
    public float velocidadMisil = 2f;
    public float intervaloMisilazo = 5f; 
    public float radioExplosion = 2f; 
    public LayerMask capasAfectadas; 
    private float tiempoRestanteMisilazo = 5f; 
    private bool puedeDisparar = false;
    public TMPro.TMP_Text textoContadorMisilazo;
    MisilazoComportamiento misilComportamiento;


    
    void Update()
    {
        
        if (tiempoRestanteMisilazo > 0)
        {
            tiempoRestanteMisilazo -= Time.deltaTime;
            textoContadorMisilazo.text = "Misilazo: " + Mathf.CeilToInt(tiempoRestanteMisilazo);
        }
        else
        {
            puedeDisparar = true;
            textoContadorMisilazo.text = "Misilazo: ¡Listo!";
        }

    
        if (puedeDisparar && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector3 direccion = (mousePos - transform.position).normalized;
            DispararMisilazo(direccion);

            tiempoRestanteMisilazo = intervaloMisilazo;
            puedeDisparar = false;
        }
    }

    void DispararMisilazo(Vector3 direccion)
    {
        GameObject misil = Instantiate(misilPrefab, transform.position, Quaternion.identity);
        misil.GetComponent<Rigidbody2D>().velocity = direccion * velocidadMisil;
        
        MisilazoComportamiento misilComportamiento = misil.AddComponent<MisilazoComportamiento>();
        misilComportamiento.Inicializar(explosionMisilazoPrefab, radioExplosion, capasAfectadas);
    }

    public float GetTiempoRestanteMisilazo()
    {
        return tiempoRestanteMisilazo;
    }

}