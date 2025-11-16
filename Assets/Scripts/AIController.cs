using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

public class AIController : MonoBehaviour
{

    public static AIController instance;
    public bool botIsStopped;
    // Declaración de variables (necesitarás algunas más)
    public float turnTime = 0.5f;

    bool[] nonCheckedPieces;

    private int k;

    private int l;

    private List<GameObject> lista;

    private List<GameObject> listaCheck;

    private List<int> listaAdyacentes;

    private int random;

    private int posiblesBombasAlrededor;

    private int piezaSeleccionada;

    private bool primerTurno;

    private int flags;

    // El Bot comienza a Jugar. Este Código no hay que cambiarlo
    public void Start()
    {

            StartCoroutine(Play());
    
    }

    public void StopBot()
    {

        botIsStopped = true;

    }

    public void StartBot()
    {

        botIsStopped = false;

    }

    public int Adyacentes()
    {

        listaAdyacentes = new List<int>();

        if (Piece.piece.getX() > 0 && Piece.piece.getY() < Generator.gen.height - 1 && Generator.gen.map[Piece.piece.getX() - 1][Piece.piece.getY() + 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getY() < Generator.gen.height - 1 && Generator.gen.map[Piece.piece.getX()][Piece.piece.getY() + 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getX() < Generator.gen.width - 1 && Piece.piece.getY() < Generator.gen.height - 1 && Generator.gen.map[Piece.piece.getX() + 1][Piece.piece.getY() + 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getX() > 0 && Generator.gen.map[Piece.piece.getX() - 1][Piece.piece.getX()].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getX() < Generator.gen.width - 1 && Generator.gen.map[Piece.piece.getX() + 1][Piece.piece.getY()].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getX() > 0 && Piece.piece.getY() > 0 && Generator.gen.map[Piece.piece.getX() - 1][Piece.piece.getY() - 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getY() > 0 && Generator.gen.map[Piece.piece.getX()][Piece.piece.getY() - 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);
        if (Piece.piece.getX() < Generator.gen.width - 1 && Piece.piece.getY() > 0 && Generator.gen.map[Piece.piece.getX() + 1][Piece.piece.getY() - 1].GetComponent<Piece>().isCheck()) listaAdyacentes.Add(1);

        return listaAdyacentes.Count;
        
    }


    public System.Collections.IEnumerator Play()
    {

        if (botIsStopped)
        {
            
        }

        else
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

        RandomPlay();

        yield return new WaitForSeconds(turnTime);
        }

        botIsStopped = true;

    }


    // Lógica general del bot

    bool LogicPlay()
    {
        bool action = false;

            if (!botIsStopped)
            {     // Buscamos todas las casilla comprobadas con bombas alrededor (check == true)

            listaCheck = new List<GameObject>();
            flags = 0;

            for (int j = 0; j < Generator.gen.map.Length; j++)
            {
                for (int i = 0; i < Generator.gen.map[j].Length; i++)
                {

                    if (Generator.gen.map[j][i].GetComponent<Piece>().isCheck() && Generator.gen.map[j][i].GetComponent<Piece>().bombsAround > 0)
                    {
                        listaCheck.Add(Generator.gen.map[j][i]);
                    }

                }
            }

            //Los <> de GetComponent te dejan acceder a los componentes de un objeto, (en la parte derecha del editor de unity al seleccionar un objeto)
            //los nombres de componentes de unity por lo general son iguales que en el editor pero todo junto (Sprite Renderer -> SpriteRenderer)
            //Si se quiere agarrar el valor de una funcion de un script de un objeto, seria poniendo el nombre del script en los <>, despues
            //(), y luego .NombreFuncion

            foreach (GameObject pieza in listaCheck)
            {
               
                listaAdyacentes.Add(Adyacentes());
             


                if (listaAdyacentes.Count > 0 && Adyacentes() == listaAdyacentes.Count + flags)
                {
                    for (int i = 0; i < listaAdyacentes.Count; i++)
                    {

                        Piece.piece.hasFlag = true;

                    }
                }
                
                if (listaAdyacentes.Count > 0 && Adyacentes() == flags)
                {
                    Piece.piece.OnMouseDown();
                }

            }
           
        }

        // Para cada casilla comprobada   

        // Regla 1: todas ocultas son minas: click_derecho (Flag) 

        // Regla 2: todas ocultas son seguras: clic_izquierdo (Flag)

        return action;
    }

    public void RandomPlay()
    {
        if (!botIsStopped)
        {
            Debug.Log("Random");

            lista = new List<GameObject>();

            for (int j = 0; j < Generator.gen.map.Length; j++)
            {
                for (int i = 0; i < Generator.gen.map[j].Length; i++)
                {
                    //Los <> de GetComponent te dejan acceder a los componentes de un objeto, (en la parte derecha del editor de unity)
                    //los nombres de componentes de unity por lo general son iguales que en el editor pero todo junto (Sprite Renderer -> SpriteRenderer)
                    //Si se quiere agarrar el valor de una funcion de un script de un objeto, seria poniendo el nombre del script en los <>, despues
                    //(), y luego .NombreFuncion
                    if (!Generator.gen.map[j][i].GetComponent<Piece>().isCheck())

                        lista.Add(Generator.gen.map[j][i]);
                }

                random = UnityEngine.Random.Range(0, lista.Count);

                lista[random].GetComponent<Piece>().OnMouseDown();

            }

        }

    }
}


