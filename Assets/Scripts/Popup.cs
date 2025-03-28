using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private TextMeshProUGUI _valueLabel;
    private float _currentLifetime = 0;

    private void Update()
    {
        _currentLifetime += Time.deltaTime;
        if (_currentLifetime >= _lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetValue(int value)
    {
        _valueLabel.text = value.ToString();
    }
}