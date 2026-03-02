using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    [SerializeField] private int GrabTrash = 0; // variavel q diz qual lixo o player pode pegar
    [SerializeField] private int LixoReciclavelQTD = 0;
    [SerializeField] private int LixoOrganicoQTD = 0;
    private LixoCounterControl ReciclavelCounter;
    private LixoCounterControlOrg OrganicoCounter;


    private void Awake()
    {
        ReciclavelCounter = FindFirstObjectByType<LixoCounterControl>();
        OrganicoCounter = FindFirstObjectByType<LixoCounterControlOrg>();
    }

    private void OnCollisionStay2D(Collision2D collision) // joga o lixo fora quando encosta na lata de lixo (Reciclavel)
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

        // joga o lixo fora quando encosta na lata de lixo (Organico)
        if (collision.gameObject.tag == "LataLixoOrganico")
        {
            LixoOrganicoQTD = LixoOrganicoQTD - 1;
            OrganicoCounter.TextUpdate(LixoOrganicoQTD);
        }
        if (LixoOrganicoQTD < 0)
        {
            LixoOrganicoQTD = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // coleta os lixos reciclaveis
    {
        if (collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 0 || collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 1)
        {
            LixoReciclavelQTD = LixoReciclavelQTD + 1;
            ReciclavelCounter.TextUpdate(LixoReciclavelQTD);
            Destroy(collision.gameObject);
            GrabTrash = 1;
            
        }
        // coleta os lixos organicos
        if (collision.gameObject.tag == "LixoOrganicoTag" && GrabTrash == 0 || collision.gameObject.tag == "LixoOrganicoTag" && GrabTrash == -1)
        {
            LixoOrganicoQTD = LixoOrganicoQTD + 1;
            OrganicoCounter.TextUpdate(LixoOrganicoQTD);
            Destroy(collision.gameObject);
            GrabTrash = -1;
            
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
