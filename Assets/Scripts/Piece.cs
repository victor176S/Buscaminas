using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Piece : MonoBehaviour
{

    public static Piece piece;

    [SerializeField] private int x, y;
    [SerializeField] public bool bomb, check;

    public void setX(int x) { this.x = x; }
    public void setY(int y) { this.y = y; }
    public void setBomb(bool bomb) { this.bomb = bomb; }
    public int getX() { return x; }
    public int getY() { return y; }
    public bool isBomb() { return bomb; }

    public bool hasFlag;

    public void setCheck(bool v)
    {
        this.check = v;
    }

    public bool isCheck()
    {
        return check;
    }

    public bool hasLost;

    private void DrawFlag()
    {
        if (!hasFlag) {

            Debug.Log("Se detecta que no tiene bandera");
            hasFlag = true;
            GetComponent<SpriteRenderer>().material.color = Color.yellow;
            transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }

        else
        {

            Debug.Log("Se detecta que tiene bandera");
            hasFlag = false;
            GetComponent<SpriteRenderer>().material.color = Color.white;
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
    }

    public void DrawBomb()
    {

        if (!isCheck())
        {
            setCheck(true);

            GameManager.instance.counter++;

            if (isBomb())
            {
                GetComponent<SpriteRenderer>().material.color = Color.red;
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                //añadir sprite de bomba
                GameManager.instance.endgame = true;
                
                
                
            }
            else
            {

                GetComponent<SpriteRenderer>().material.color = Color.green;

                int bombsNumber = Generator.gen.getBombsAround(x, y);

                if (bombsNumber != 0)
                {

                    transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bombsNumber.ToString();

                }

                else
                {

                    Generator.gen.CheckPieceAround(x, y);

                }

            }
        }

    }


    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (!GameManager.instance.endgame)
        {

            DrawBomb();

            if (hasFlag && isCheck())
            {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            }

            if (GameManager.instance.counter == ((Generator.gen.width * Generator.gen.height) - Generator.gen.bombsNumber))
            {
                Debug.Log("Entrada al if que pone hasWon a true");
                GameManager.instance.hasWon = true;
                GameManager.instance.endgame = true;
            }

        }

        else
        {
            hasLost = true;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Click derecho");
            DrawFlag();

        }
    }   

}
