using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    [SerializeField] private int GrabTrash = 0;
    [SerializeField] private int LixoReciclavelQTD = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 0 || collision.gameObject.tag == "LixoReciclavelTag" && GrabTrash == 1)
        {
            LixoReciclavelQTD = LixoReciclavelQTD + 1;
            Destroy(collision.gameObject);
            GrabTrash = 1;
            
        }
    }

}
