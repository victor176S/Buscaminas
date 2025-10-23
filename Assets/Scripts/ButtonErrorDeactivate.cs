using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ButtonErrorDeactivate : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void Pulsar()
    {
        ErrorWindow.Pulsado = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
