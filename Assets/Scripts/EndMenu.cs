using UnityEngine;

public class EndMenu : MonoBehaviour
{

    public static EndMenu endMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
