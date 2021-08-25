using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupSimulationScreen : MonoBehaviour
{
    [SerializeField]
    private Slider fieldSizeSlider;

    [SerializeField]
    private TMP_Text fieldSizeValueText;

    [SerializeField]
    private Slider animalsCountSlider;

    [SerializeField]
    private TMP_Text animalsCountValueText;

    [SerializeField]
    private Slider animalSpeedSlider;

    [SerializeField]
    private TMP_Text animalSpeedValueText;

    private void Awake()
    {
        fieldSizeSlider.onValueChanged.AddListener(OnFieldSizeChanged);
        animalsCountSlider.onValueChanged.AddListener(OnAnimalsCountChanged);
        animalSpeedSlider.onValueChanged.AddListener(OnAnimalsSpeedChanged);

        fieldSizeValueText.SetText(fieldSizeSlider.value.ToString());
        animalsCountValueText.SetText(animalsCountSlider.value.ToString());
        animalSpeedValueText.SetText(animalSpeedSlider.value.ToString());
    }

    private void OnFieldSizeChanged(float value)
    {
        fieldSizeValueText.SetText(value.ToString());

        var fieldSize = Mathf.RoundToInt(value);

        animalsCountSlider.maxValue = Mathf.RoundToInt(fieldSize * fieldSize / 2f);
    }

    private void OnAnimalsCountChanged(float value)
    {
        animalsCountValueText.SetText(value.ToString());
    }

    private void OnAnimalsSpeedChanged(float value)
    {
        animalSpeedValueText.SetText(value.ToString());
    }

    public void OnSimulationStartClick()
    {
        
    }
}
