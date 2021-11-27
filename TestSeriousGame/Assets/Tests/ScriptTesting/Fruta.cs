using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    [SerializeField] float tiempoSpawn;
    [SerializeField] float velocidad;
    [SerializeField] Vector2 posMax;
    [SerializeField] Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Movimiento();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void Movimiento()
    {
        pos = Vector2.MoveTowards(pos, posMax, velocidad * Time.deltaTime);
        transform.position = pos;
        if(pos == posMax)
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(gameObject, tiempoSpawn);
    }
}
