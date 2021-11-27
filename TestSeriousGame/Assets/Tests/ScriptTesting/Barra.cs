using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{

    Slider valorBarra;
    [SerializeField] float valorMaximoBarra;
    [SerializeField] float valorMinimoBarra;
    [SerializeField] float valorSeleccionado;
    [SerializeField] int velocidadFlecha;
    Vector3 disFrutaPlayer = new Vector3(0f, 1f, 0f);
    [SerializeField] Saltar playerStp;

    [SerializeField] Transform frutaPos;
    bool maxValor;
    bool _pararEfecto;
    public bool pararEfecto { get { return _pararEfecto; } set { _pararEfecto = value; } }

    void Start()
    {
        
        valorBarra = GetComponent<Slider>();
        valorMaximoBarra = valorBarra.maxValue;
        valorMinimoBarra = valorBarra.minValue;

        playerStp = GameObject.FindGameObjectWithTag("Player").GetComponent<Saltar>();
        frutaPos = GameObject.FindGameObjectWithTag("Fruta").transform;

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _pararEfecto = true;
            valorSeleccionado = valorBarra.value;
            if(valorSeleccionado >= 40f && valorSeleccionado <= 60f)
            {
                 //playerStp.posFruta =  frutaPos.position;
                playerStp.alcanzoFruta = true;
            }
            else
            {
                //playerStp.posFruta = frutaPos.position - disFrutaPlayer;
                playerStp.alcanzoFruta = false;

            }
            playerStp.saltar = true;

        }

        if (!_pararEfecto)
        {
            EfectoBarra();
        }
    }

    void EfectoBarra()
    {
        if(valorBarra.value <= valorMaximoBarra && !maxValor)
        {
            valorBarra.value -= velocidadFlecha * Time.deltaTime;
            if(valorBarra.value == valorMinimoBarra)
            {
                maxValor = true;
            }
        }
        else 
        if(valorBarra.value >= valorMinimoBarra && maxValor)
        {
            valorBarra.value += velocidadFlecha * Time.deltaTime;
            if (valorBarra.value == valorMaximoBarra)
            {
                maxValor = false;
            }
        }
    }
}
