using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
[SerializeField] private int LixoReciclavelQTD = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LixoReciclavelTag") {
            LixoReciclavelQTD = LixoReciclavelQTD + 1;

            
        }
    }
   
}
