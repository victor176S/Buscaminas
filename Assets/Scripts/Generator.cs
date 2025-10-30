using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //Declaracion de variables
    [SerializeField] private GameObject piece;
    public int width, height, bombsNumber;
    [SerializeField] public GameObject[][] map;
    public static Generator Instance;
    public static Generator gen;
    public static int codigoError;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gen = this;
    }

    void Start()
    {
        

    }
    public void setWidth(int width)
    {
        this.width = width;
    }

    public void setHeight(int height)
    {
        this.height = height;
    }

    public void setBombsNumber(int bombsNumber)
    {
        this.bombsNumber = bombsNumber;
    }
    public void Generate()
    {
        gen = this;

        //Generacion del mapa
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        //Instanciacion de las piezas
        for (int j = 0; j < width; j++)
        {
            for (int i = 0; i < height; i++)
            {
                map[i][j] = Instantiate(piece, new Vector3(i, j, 0), Quaternion.identity);
                //array bug
                map[i][j].GetComponent<Piece>().setX(i);
                map[i][j].GetComponent<Piece>().setY(j);
            }
        }

        //Posicion de la camara
        Camera.main.transform.position = new Vector3((float)height / 2 - 0.5f, (float)width / 2 - 0.5f, -10);

        //Colocacion de bombas
        for (int i = 0; i < bombsNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            if (!map[x][y].GetComponent<Piece>().isBomb())
            {
                map[x][y].GetComponent<Piece>().setBomb(true);
            }
            else
            {
                i--;
            }

            //Cambio color a bomba
            //map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        }


    }

    public int getBombsAround(int x, int y)
    {
        int cont = 0;

        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().isBomb()) cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().isBomb()) cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().isBomb()) cont++;
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().isBomb()) cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().isBomb()) cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().isBomb()) cont++;
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().isBomb()) cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().isBomb()) cont++;

        return cont;
    }

    public void CheckPieceAround(int x, int y)
    {
        if (x > 0 && y < height - 1) map[x - 1][y + 1].GetComponent<Piece>().DrawBomb();
        if (y < height - 1) map[x][y + 1].GetComponent<Piece>().DrawBomb();
        if (x < width - 1 && y < height - 1) map[x + 1][y + 1].GetComponent<Piece>().DrawBomb();
        if (x > 0) map[x - 1][y].GetComponent<Piece>().DrawBomb();
        if (x < width - 1) map[x + 1][y].GetComponent<Piece>().DrawBomb();
        if (x > 0 && y > 0) map[x - 1][y - 1].GetComponent<Piece>().DrawBomb();
        if (y > 0) map[x][y - 1].GetComponent<Piece>().DrawBomb();
        if (x < width - 1 && y > 0) map[x + 1][y - 1].GetComponent<Piece>().DrawBomb();

    }

    

}
