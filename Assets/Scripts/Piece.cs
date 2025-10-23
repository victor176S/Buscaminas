using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private bool bomb, check;

    public void setX(int x) { this.x = x; }
    public void setY(int y) { this.y = y; }
    public void setBomb(bool bomb) { this.bomb = bomb; }
    public int getX() { return x; }
    public int getY() { return y; }
    public bool isBomb() { return bomb; }

    public void setCheck(bool v)
    {
        this.check = v;
    }

    public bool isCheck()
    {
        return check;
    }

    public void DrawBomb()
    {

        if (!isCheck())
        {
            setCheck(true);

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
        }
    }    

}
