using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void InstatiateBomb()
    {
        Vector2 posInstatiate = player.transform.position;
        Instantiate(bombPrefab, posInstatiate, Quaternion.identity);
    }
}
