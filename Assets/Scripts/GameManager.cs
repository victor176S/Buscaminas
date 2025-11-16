using System.Data;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Canvas BotCanvas;
    [SerializeField] GameObject startMenu;
    public GameObject endMenu;
    public static GameManager instance;

    public GameObject bot, prefabBot;

    public static bool ErrorDetectado;

    public bool endgame;

    public bool hasLost;

    public bool hasWon;

    public int counter;

    public bool botWasInitiated;

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

    public void StartBot()
    {

        if (!botWasInitiated){

        AIController.instance.Start();

        botWasInitiated = true;
        
        }

        else
        {
            StartCoroutine(AIController.instance.Play());
        }
    }

    public void StopBot()
    {
        AIController.instance.StopBot();
    }

    public void Start()
    {
        if (ErrorWindow.codigoError == 0)
        {
            startMenu.SetActive(true);
        }
    }

    public void Update()
    {
        if (endgame)
        {
            Debug.Log("entrada al if de endgame");
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


        BotCanvas.gameObject.SetActive(true);
        BotCanvas.transform.GetChild(0).gameObject.SetActive(true);
        BotCanvas.transform.GetChild(1).gameObject.SetActive(false);

        bot = Instantiate(prefabBot, new Vector3(0, 0, 0), Quaternion.identity);

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
        if (hasLost)
        {

            Debug.Log("entrada a la funcion PantallaFinal (hasLost)");
            endMenu.transform.gameObject.SetActive(true);
            endMenu.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (hasWon)
        {

            Debug.Log("entrada a la funcion PantallaFinal (hasWon)");
            endMenu.gameObject.SetActive(true);
            endMenu.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
        
        public void MakeVisible()
    {

        if (BotCanvas.transform.GetChild(0).gameObject.activeInHierarchy == false)
        {

            BotCanvas.transform.GetChild(0).gameObject.SetActive(true);
            BotCanvas.transform.GetChild(1).gameObject.SetActive(false);

        }

        else
        {

            BotCanvas.transform.GetChild(0).gameObject.SetActive(false);
            BotCanvas.transform.GetChild(1).gameObject.SetActive(true);

        }
        
        }
    }

