using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    private static GameController instance;

    
    public bool boom;

    [SerializeField] private GameObject fermer;

    public GameObject player;

    private Animator animDamage;

   private void Start()
    {
        instance = this;
        animDamage = GameObject.FindGameObjectWithTag("DamageUI").GetComponent<Animator>();
        
    }
    public void BombAtttack(Vector2 posBomb)
    {
        float  distanceByXFermer = Mathf.Abs(posBomb.x - fermer.transform.position.x);
        float distanceByYFermer = Mathf.Abs(posBomb.y - fermer.transform.position.y);

        float distanceByXPlayer = Mathf.Abs(posBomb.x - player.transform.position.x);
        float distanceByYPlayer = Mathf.Abs (posBomb.y - player.transform.position.y);
        Debug.Log(distanceByXPlayer);
        Debug.Log(distanceByYPlayer);
        if (distanceByXPlayer < 2 && distanceByYPlayer < 0.3 || distanceByYPlayer < 2 && distanceByXPlayer < 0.3)
            animDamage.SetInteger("Damage", 1);
        if (distanceByXFermer < 3 && distanceByYFermer < 1 || distanceByYFermer < 3 && distanceByXFermer < 1)
        {
            Debug.Log("Die Fermer");
            boom = true;
        }
    }
}
