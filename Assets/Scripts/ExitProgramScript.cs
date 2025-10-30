using UnityEngine;

public class ExitProgramScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    public void Exit()
    {
        Application.Quit();

        Debug.Log("Se ha salido el juego");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
