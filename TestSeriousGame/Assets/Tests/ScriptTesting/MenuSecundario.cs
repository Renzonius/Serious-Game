using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundario : MonoBehaviour
{
    [SerializeField] Saltar playerScpt;
    [SerializeField] GameObject menuSecundarioExito;
    [SerializeField] GameObject menuSecundarioFallo;
    [SerializeField] Barra barraScpt;
    void Start()
    {

    }

    void Update()
    {
        if (barraScpt.pararEfecto)
        {
            if(playerScpt.alcanzoFruta)
            {
                StartCoroutine(ActivarMenuResultado(true));
            }
            else
            {
                StartCoroutine(ActivarMenuResultado(false));
            }
        }
    }
    IEnumerator ActivarMenuResultado(bool resul)
    {
        if (resul)
        {
            yield return new WaitForSeconds(5.5f);
            menuSecundarioExito.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(5.5f);
            menuSecundarioFallo.SetActive(true);
        }
    }
    public void Resetear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SiguenteNivel()
    {
        SceneManager.LoadScene("");
    }
}
