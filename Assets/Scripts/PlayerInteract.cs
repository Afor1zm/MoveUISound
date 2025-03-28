using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _brickValueLable;
    [SerializeField] private TextMeshProUGUI _waterValueLabel;
    [SerializeField] private TextMeshProUGUI _goldValueLabel;
    [SerializeField] private TextMeshProUGUI _woodValueLabel;
    [SerializeField] private TextMeshProUGUI _energyValueLabel;
    private int _brick;
    private int _water;
    private int _gold;
    private int _wood;   
    private int _energy;
    
    public void RecieveResources(Interactable.GameResources resources, int value)
    {
        Debug.Log($"Received ({resources} with avlue {value})");
        switch (resources)
        {
            case Interactable.GameResources.Brick:
                _brick += value;
                _brickValueLable.text = _brick.ToString();
                break;
            case Interactable.GameResources.Water:
                _water += value;
                _waterValueLabel.text = _water.ToString();
                break;
            case Interactable.GameResources.Wood:
                _wood += value;
                _woodValueLabel.text = _wood.ToString();
                break;
            case Interactable.GameResources.Gold:
                _gold += value;
                _goldValueLabel.text = _gold.ToString();
                break;
            case Interactable.GameResources.Energy:
                _energy += value;
                _energyValueLabel.text = _energy.ToString();
                break;
        }
    }
}