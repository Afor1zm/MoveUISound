using System;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameResources Resources => _resources;
    public int Value => _value;
    [SerializeField] private GameResources _resources = GameResources.Brick;
    [SerializeField] private int _value;
    [SerializeField] private float _spawnResourceSeconds;
    [SerializeField] private float _currentSecondsAfterSpawn = 0;
    [SerializeField] private int _resourceIncome;
    [SerializeField] private TextMeshPro _nameLabel;
    [SerializeField] private TextMeshPro _labelValue;
    [SerializeField] private Popup _popupPrefab;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    private void Start()
    {
        if(PlayerPrefs.HasKey("volume"))
        {
            _source.volume = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            _source.volume = 1f;
        }
        SaveLoadSoundVolume.OnChangeVolume += SetVolume;
        _labelValue.text = _value.ToString();
    }

    private void SetVolume(float value)
    {
        _source.volume =value;
    }

    private void Update()
    {
        if (_currentSecondsAfterSpawn >= _spawnResourceSeconds)
        {
            _value += _resourceIncome;
            _currentSecondsAfterSpawn = 0;
            _labelValue.text = _value.ToString();
        }
        _currentSecondsAfterSpawn += Time.deltaTime;
    }

    public void TakeResources()
    {
        _source.PlayOneShot(_clip);
        SpawnPopupPrefab();
        _value = 0;
        _labelValue.text = _value.ToString();        
    }

    private void SpawnPopupPrefab()
    {
        Popup newPopup = Instantiate(_popupPrefab, transform);
        newPopup.SetValue(_value);
    }

    private void OnDisable()
    {
        SaveLoadSoundVolume.OnChangeVolume -= SetVolume;
    }

    public enum GameResources
    {
        Gold,
        Brick,
        Wood,
        Water,
        Energy
    }
}


