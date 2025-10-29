using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject startMenu;
    public GameObject endMenu;
    public static GameManager instance;

    public static bool ErrorDetectado;

    public bool endgame;

    public bool hasLost;

    private void Awake()
    {
        if (instance == null)
        {

            DontDestroyOnLoad(gameObject);
            instance = this;

        }

        else if (instance != this)
        {

            Destroy(gameObject);

        }

    }

    public void Start()
    {
        if (ErrorWindow.codigoError == 0)
        {
            startMenu.SetActive(true);
        }

        if (endgame)
        {
            PantallaFinal();
        }
       
    }

    public void StartGame()
    {

        Generator.codigoError = ErrorWindow.CodigoError(
        int.Parse(StartMenu.instance.heightInput.GetComponentInChildren<TMP_InputField>().text.ToString()),
        int.Parse(StartMenu.instance.widthInput.GetComponentInChildren<TMP_InputField>().text.ToString()),
        int.Parse(StartMenu.instance.bombsInput.GetComponentInChildren<TMP_InputField>().text.ToString())
        );


        if (Generator.codigoError == 0)
        {

            Debug.Log("Generar");

            Generator.gen.setHeight(int.Parse(StartMenu.instance.heightInput.GetComponentInChildren<TMP_InputField>().text.ToString()));
            Generator.gen.setWidth(int.Parse(StartMenu.instance.widthInput.GetComponentInChildren<TMP_InputField>().text.ToString()));
            Generator.gen.setBombsNumber(int.Parse(StartMenu.instance.bombsInput.GetComponentInChildren<TMP_InputField>().text.ToString()));
            Generator.gen.Generate();

            startMenu.SetActive(false);

        }
        else
        {
            Debug.Log("Else de startgame");
            ErrorWindow.ErrorMessage = ErrorWindow.MensajeError();
            ErrorWindow.errorWindow.MostrarError();
            ErrorWindow.codigoError = 0;

        }
    }

    public void PantallaFinal()
    {
        {
            gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        /*else
        {
            
            gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);

        }*/
    }

}
