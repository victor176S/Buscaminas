using System;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindow : MonoBehaviour
{

    [SerializeField] public static TextMeshProUGUI ErrorMessageTextMesh;
    
    public static int codigoError = 0;
    public static string ErrorMessage;
    public static ErrorWindow errorWindow;

    public static bool Pulsado;


    void Awake()
    {
        //instanciar correctamente
        if (errorWindow == null)
        {
            errorWindow = this;
        }
        //para que un objeto pueda actuar en unity, al empezar el programa, siempre tiene que estar activo, luego se puede desactivar
        gameObject.SetActive(false);

        if (Pulsado == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void Start()
    {

    }

    public void MostrarError()
    {

        Debug.Log("MostrarError ErrorWindow");
            Debug.Log(codigoError);
            gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = ErrorMessage;
            
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int CodigoError(int height, int width, int bombsNumber)
    {

        if (height <= 2)
        {



            codigoError += 1;

        }

        if (width <= 2)
        {



            codigoError += 2;

        }

        if (bombsNumber <= 0)
        {



            codigoError += 4;

        }

        return codigoError;
    }

    public void pulsar()
    {
        gameObject.SetActive(false);
    }

    public static string MensajeError()
    {

        switch (codigoError)
        {

            case 1:

                ErrorMessage = "Has elegido un valor muy pequeño para el alto, elige 3 o más ";
                break;

            case 2:

                ErrorMessage = "Has elegido un valor muy pequeño para el ancho, elige 3 o más";

                break;

            case 3:

                ErrorMessage = "Has elegido un valor muy pequeño para la anchura y altura, elige 3 o más para ambos";

                break;


            case 4:

                ErrorMessage = "Has elegido un valor muy pequeño para las bombas, elige 1 o más";

                break;

            case 5:

                ErrorMessage = "Has elegido un valor muy pequeño para la altura, elige 3 o más, además para las bombas tienes que elegir 1 o más";

                break;

            case 6:

                ErrorMessage = "Has elegido un valor muy pequeño para el ancho, elige 3 o más, además para las bombas elige de 1 a más";

                break;

            case 7:

                ErrorMessage = "Has elegido un valor muy pequeño para la altura y ancho, elige 3 o más, además para las bombas elige 1 o más";

                break;


            default:

                ErrorMessage = "No se que has hecho pero creo que no deberias hacer eso";

                break;
        }

        return ErrorMessage;

    }




    


}

