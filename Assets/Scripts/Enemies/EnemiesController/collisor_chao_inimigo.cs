using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisor_chao_inimigo : MonoBehaviour
{
    public Enemy inimigo;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Ground"))
            {
                inimigo.Flip();
            }
        }
    }
}
