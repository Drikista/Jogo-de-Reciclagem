using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    private int GrabTrash = 0;
    [SerializeField] private int LixoReciclavelQTD = 0;
    private LixoCounterControl ReciclavelCounter;

    private void Awake()
    {
        ReciclavelCounter = FindFirstObjectByType<LixoCounterControl>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LataLixoReciclavel")
        {
        LixoReciclavelQTD = LixoReciclavelQTD - 1;
            ReciclavelCounter.TextUpdate(LixoReciclavelQTD);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 0 || collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 1)
        {
            LixoReciclavelQTD = LixoReciclavelQTD + 1;
            ReciclavelCounter.TextUpdate(LixoReciclavelQTD);
            Destroy(collision.gameObject);
            GrabTrash = 1;
            
        }
    }

}
