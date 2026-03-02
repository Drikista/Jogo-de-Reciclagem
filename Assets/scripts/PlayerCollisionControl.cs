using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    [SerializeField] private int GrabTrash = 0;
    [SerializeField] private int LixoReciclavelQTD = 0;
    private LixoCounterControl ReciclavelCounter;

    private void Awake()
    {
        ReciclavelCounter = FindFirstObjectByType<LixoCounterControl>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LataLixoReciclavel")
        {
            LixoReciclavelQTD = LixoReciclavelQTD - 1;
            ReciclavelCounter.TextUpdate(LixoReciclavelQTD);
        }
        if (LixoReciclavelQTD < 0)
        {
            LixoReciclavelQTD = 0;
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

    private void Update()
    {
        if (LixoReciclavelQTD < 0)
        {
            LixoReciclavelQTD = 0;
        }

        if (LixoReciclavelQTD == 0)
        {
            GrabTrash = 0;
        }
    }
}
