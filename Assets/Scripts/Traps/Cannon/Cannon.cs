using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform firepoint;
    public Ball ball;
    float timeBetween;
    public float StartTimeBetween;

    void Start()
    {
        timeBetween = StartTimeBetween;
    }

    void Update()
    {
        if (timeBetween <= 0)
        {
            Ball newBall = Instantiate(ball, firepoint.position, firepoint.rotation);

            // Verifica a escala do canhão
            if (transform.localScale.x < 0)
            {
                // Se o canhão estiver virado para a esquerda, inverte a escala da bola
                newBall.transform.localScale = new Vector3(-1, 1, 1);
            }

            timeBetween = StartTimeBetween;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
