using UnityEngine;
using TMPro;
public class LixoCounterControlOrg : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI OrganicoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TextUpdate(int Value)
    {
        OrganicoText.text = Value.ToString();
    }

}
