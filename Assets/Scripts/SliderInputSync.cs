using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderInputSync : MonoBehaviour
{

    public Slider slider;
    public TMP_InputField inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        slider.onValueChanged.AddListener(OnSliderValueChanged);
        inputField.onEndEdit.AddListener(OnInputFieldValueChanged);

        inputField.text = slider.value.ToString();

    }

    private void OnSliderValueChanged(float value)
    {
        inputField.text = value.ToString();
    }

    private void OnInputFieldValueChanged(string value)
    {
        if (float.TryParse(value, out float result))
        {
            slider.value = result;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
