using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float timeLerp;

    void FixedUpdate()
    {
        //fixando camera sempre em z = -10
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);

        //altura da camera no eixo y (parte de baixo)
        newPosition.y = 0.1f; //mudar dps q montar o cenario

        //suavização da camera ( quanto menor mais lento )
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);

        transform.position = newPosition;

        //definindo os limites no eixo x
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}
