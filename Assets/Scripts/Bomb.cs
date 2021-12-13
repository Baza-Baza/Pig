using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private Animator animDamageUI;

    private float countdown = 2f;


    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            GameController.Instance.BombAtttack(transform.position);
            Destroy(gameObject);
        }
    }
}
