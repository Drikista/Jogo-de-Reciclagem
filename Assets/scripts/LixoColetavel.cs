using UnityEngine;

public class LixoColetavel : MonoBehaviour
{
    private bool jogadorNaArea = false;
    private PlayerMovement2D playerScript; // Mudança aqui: referência ao PlayerMovement2D

    private void Update()
    {
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.Z) && playerScript != null)
        {
            TentarColetar();
        }
    }

    private void TentarColetar()
    {
        string minhaTag = gameObject.tag;

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