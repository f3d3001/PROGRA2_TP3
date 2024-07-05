using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExplosionMisilazo : MonoBehaviour
{
    public float tiempo;

    private void Start()
    {
        GetComponent<SpriteRenderer>()
            .DOFade(0f, tiempo)
            .OnComplete(() => Destroy(gameObject));
    
        Camara.Instancia.ScreenShake();
    }

}
