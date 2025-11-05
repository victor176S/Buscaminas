using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AIController : MonoBehaviour
{
    public bool botIsStopped;
    // Declaración de variables (necesitarás algunas más)
    public float turnTime = 0.5f;

    bool[] nonCheckedPieces;

    private int k;

    private List<GameObject> lista;
    // El Bot comienza a Jugar. Este Código no hay que cambiarlo
    void Start()
    {

        if (!botIsStopped)
        {
            StartCoroutine(Play());
        }
    }

    public void StopBot()
    {

        botIsStopped = true;

    }

    public void StartBot()
    {

        botIsStopped = false;

    }


    System.Collections.IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);

        while (!GameManager.instance.endgame)
        {
            bool actionDone = LogicPlay();
            if (!actionDone)
            {
                // Si no hay lógica aplicable, jugar aleatoriamente
                RandomPlay();
            }

            yield return new WaitForSeconds(turnTime);
        }
    }


    // Lógica general del bot

    bool LogicPlay()
    {
        bool action = false;


        // Buscamos todas las casilla comprobadas con bombas alrededor (check == true)

        // Para cada casilla comprobada   

        // Regla 1: todas ocultas son minas: click_derecho (Flag) 


        // Regla 2: todas ocultas son seguras: clic_izquierdo (Flag)

        return action;
    }

    void RandomPlay()
    {
        for (int j = 0; j < Generator.Instance.width; j++)
        {
            for (int i = 0; i < Generator.Instance.height; i++)
            {
                //Los <> de GetComponent te dejan acceder a los componentes de un objeto, (en la parte derecha del editor de unity)
                //los nombres de componentes de unity por lo general son iguales que en el editor pero todo junto (Sprite Renderer -> SpriteRenderer)
                //Si se quiere agarrar el valor de una funcion de un script de un objeto, seria poniendo el nombre del script en los <>, despues
                //(), y luego .NombreFuncion
                if (!Generator.Instance.map[i][j].GetComponent<Piece>().isCheck())
                
                    lista.Add(Generator.Instance.map[i][j]);
                }
            }
        }
    }    


