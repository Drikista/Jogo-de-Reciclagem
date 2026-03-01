using UnityEngine;

public class LixoColetavel : MonoBehaviour
{
    private bool jogadorNaArea = false;
    private PlayerMovement2D playerScript; // Mudança aqui: referência ao PlayerMovement2D

    private void Update()
    {
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.Z))
        {
            if (playerScript != null)
            {
                TentarColetar();
            }
            else
            {
                Debug.LogError("ERRO: Você apertou Z, mas o script 'PlayerMovement2D' não foi encontrado no Player!");
            }
        }
    }

    private void TentarColetar()
    {
        string minhaTag = gameObject.tag;

        if (minhaTag == "Untagged")
        {
            Debug.LogWarning($"ATENÇÃO: O lixo '{gameObject.name}' está sem Tag! Defina a Tag como 'lixo organico' ou 'lixo nao organico' no Inspector.");
            return;
        }

        if (playerScript.PodeColetar(minhaTag)) // Chama método no PlayerMovement2D
        {
            playerScript.ColetarItem(minhaTag); // Chama método no PlayerMovement2D
            Debug.Log($"Coletado: {minhaTag}");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Você não pode misturar tipos de lixo diferentes!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorNaArea = true;
            // Busca o script PlayerMovement2D no objeto do Player
            playerScript = collision.GetComponent<PlayerMovement2D>();
            if (playerScript == null)
            {
                Debug.LogError("ERRO CRÍTICO: O objeto colidido tem a tag 'Player', mas não tem o componente 'PlayerMovement2D' anexado! Verifique o Inspector do Player.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorNaArea = false;
            playerScript = null;
        }
    }
}