using UnityEngine;

public class EndMenu : MonoBehaviour
{

    public static EndMenu endMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //esto es para hacer que se cargue bien y luego lo oculte
    void Start()
    {
        
        gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
