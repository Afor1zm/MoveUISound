using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadSoundVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public static Action<float> OnChangeVolume;

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey("volume"))
        {
            _slider.value = PlayerPrefs.GetFloat("volume");
        }
        _slider.onValueChanged.AddListener(SaveVolume);
    }

    private void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        PlayerPrefs.Save();
        OnChangeVolume?.Invoke(value);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }
}
