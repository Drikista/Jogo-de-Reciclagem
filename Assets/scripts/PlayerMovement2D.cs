using UnityEngine;
using UnityEngine;
using TMPro; // Importante para usar TextMeshPro. Se usar Texto Legacy, mude para UnityEngine.UI

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movimentação")]
    [SerializeField]
    private float moveSpeed = 5f;

    [Header("Configuração da UI")]
    [SerializeField] private TextMeshProUGUI textoOrganico;
    [SerializeField] private TextMeshProUGUI textoReciclavel;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    // Estado interno de coleta
    private int qtdOrganico = 0;
    private int qtdReciclavel = 0;
    private string tipoAtual = ""; // Guarda a tag do tipo que está sendo carregado
    private const int MAX_ITENS = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }

    // --- Lógica do Gerenciador de Coleta ---

    // Verifica se o jogador pode coletar este tipo de lixo
    public bool PodeColetar(string tagDoItem)
    {
        // Se não está carregando nada, pode coletar qualquer um
        if (string.IsNullOrEmpty(tipoAtual)) return true;

        // Se já está carregando algo, só pode coletar se for da mesma tag
        if (tipoAtual == tagDoItem)
        {
            return true;
        }

        return false;
    }

    public void ColetarItem(string tagDoItem)
    {
        // Define o tipo atual se for o primeiro item
        if (string.IsNullOrEmpty(tipoAtual))
        {
            tipoAtual = tagDoItem;
        }

        // Incrementa a pontuação baseada na tag
        if (tagDoItem == "lixo organico")
        {
            qtdOrganico++;
        }
        else if (tagDoItem == "lixo nao organico")
        {
            qtdReciclavel++;
        }

        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (textoOrganico != null)
            textoOrganico.text = $"Lixo organico {qtdOrganico}/{MAX_ITENS}";
        
        if (textoReciclavel != null)
            textoReciclavel.text = $"Lixo Reciclável {qtdReciclavel}/{MAX_ITENS}";
    }
}