using UnityEngine;
using TMPro;
public class LixoCounterControl : MonoBehaviour
{

    
    [SerializeField] public TextMeshProUGUI ReciclavelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TextUpdate(int Value)
    {
        ReciclavelText.text = Value.ToString();
    }

}
