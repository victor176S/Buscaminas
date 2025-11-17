using UnityEngine;

public class BackToMenu : MonoBehaviour
{

    public static BackToMenu backToMenu;

    public GameObject UIMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AbrirMenu()
    {

        UIMenu.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
