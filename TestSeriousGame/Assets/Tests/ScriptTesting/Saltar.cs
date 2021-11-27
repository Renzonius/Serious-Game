using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    Vector2 pos;
    Vector2 posInicial;
    [SerializeField] float _fuerzaSalto;
    Vector2 _posFruta;
    public Vector2 posFruta { get { return _posFruta; } set { _posFruta = value; } }
    public float fuerza { get { return _fuerzaSalto; } set { _fuerzaSalto = value; } }
    bool _alcanzoFruta;
    public bool alcanzoFruta { get { return _alcanzoFruta; } set { _alcanzoFruta = value; } }
    bool _saltar;
    public bool saltar { get { return _saltar; } set { _saltar = value; } }

    Animator anim;
    void Start()
    {
        posInicial = transform.position;
        pos = posInicial;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_saltar)
        {
            MovimientoSalto();
            _saltar = false;
        }
    }

    void MovimientoSalto()
    {
        if (_alcanzoFruta)
        {
            //Animacion de celebracion 
            anim.Play("SaltoExito");

        }
        else
        {
            anim.Play("SaltoFallo");
            //Animacion de caer
        }
    }
}
