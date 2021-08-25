using System.Collections;
using System.Collections.Generic;
using AnimalsDemo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScreen : MonoBehaviour, IScreen
{
    public ScreenType ScreenType => ScreenType.Main;

    [SerializeField]
    private Slider simulationSpeedSlider;

    [SerializeField]
    private TMP_Text simulationSpeedValueText;

    [Inject]
    private SimulationManager simulationManager;

    private void Awake()
    {
        simulationSpeedSlider.onValueChanged.AddListener(OnSimulationSpeedChanged);
    }

    private void OnSimulationSpeedChanged(float value)
    {
        simulationSpeedValueText.SetText(value.ToString());

        simulationManager.SetSimulationSpeed(value);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
