using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoveFermer : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private List<Sprite> spriteSideFermer;
    [SerializeField] private Animator animDamage;


    private SpriteRenderer imageFermer;
    private List<float> distance;
    private Transform lastPoints;
    private Vector3 lastSide;
    private bool visible;


    private void Awake()
    {
        imageFermer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        lastSide = transform.position;
        transform.DOMove(new Vector3(points[0].position.x, points[0].position.y, 0), 5);
        lastPoints = points[0];
    }

    private void Update()
    {
        СheckToVisibilityPlayer();
        FermerMove();
        CheckSide();
    }
    private void FermerMove()
    {
        if (!GameController.Instance.boom && !visible)
        {
            
            DOTween.Play(transform);
            animDamage.SetInteger("Damage", 0);
            int rand = Random.Range(0, points.Count);
            if (transform.position == lastPoints.position)
            {
                float x = Mathf.Abs(transform.position.x - points[rand].position.x);
                float y = Mathf.Abs(transform.position.y - points[rand].position.y);

                if (x < 0.41 && y > 0 || x > 0 && y == 0)
                {
                    transform.DOMove(new Vector3(points[rand].position.x, points[rand].position.y, 0), 5);
                    lastPoints = points[rand];
                }
                else
                {
                    lastPoints = transform;
                }

                lastSide = transform.position;
                Debug.Log(points[rand].name);
            }
        }
        else if (GameController.Instance.boom)
            StartCoroutine(StopMovement());
        else if (visible)
        {
            DOTween.Pause(transform);
            animDamage.SetInteger("Damage", 1);           
        }


    }
    private void CheckSide()
    {
        if (!GameController.Instance.boom && !visible)
        {
            if (lastSide.x - transform.position.x > 0.41f)
                imageFermer.sprite = spriteSideFermer[1];
            if (lastSide.x - transform.position.x < -0.41f)
                imageFermer.sprite = spriteSideFermer[0];
            if (lastSide.y > transform.position.y)
                imageFermer.sprite = spriteSideFermer[3];
            if (lastSide.y < transform.position.y)
                imageFermer.sprite = spriteSideFermer[2];
        }
        else if (GameController.Instance.boom)
        {
            if (lastSide.x - transform.position.x > 0.41f)
                imageFermer.sprite = spriteSideFermer[5];
            if (lastSide.x - transform.position.x < -0.41f)
                imageFermer.sprite = spriteSideFermer[4];
            if (lastSide.y > transform.position.y)
                imageFermer.sprite = spriteSideFermer[6];
            if (lastSide.y < transform.position.y)
                imageFermer.sprite = spriteSideFermer[7];
        }
        else if (visible)
        {
            if (GameController.Instance.player.transform.position.x > transform.position.x && GameController.Instance.player.transform.position.y - transform.position.y < 0.55f)
                imageFermer.sprite = spriteSideFermer[8];
            if (GameController.Instance.player.transform.position.x < transform.position.x)
                imageFermer.sprite = spriteSideFermer[9];
            if (GameController.Instance.player.transform.position.y - transform.position.y > 0.55f)
                imageFermer.sprite = spriteSideFermer[11];
            if (GameController.Instance.player.transform.position.y - transform.position.y < -0.55f)
                imageFermer.sprite = spriteSideFermer[10];
        }


    }
    IEnumerator StopMovement()
    {
        DOTween.Pause(transform);
        yield return new WaitForSeconds(2.5f);
        DOTween.Play(transform);
        GameController.Instance.boom = false;   
    }

    private void СheckToVisibilityPlayer()
    {
        float disToPLayerByX = Mathf.Abs(transform.position.x - GameController.Instance.player.transform.position.x);
        float disToPLayerByY = Mathf.Abs(transform.position.y - GameController.Instance.player.transform.position.y);

        if (disToPLayerByX < 1.5f && disToPLayerByY < 0.6f)
        {
            Debug.Log("See");
            visible = true;
            
        }
        else if (disToPLayerByY < 1.5f && disToPLayerByX < 0.4f)
        {
            visible = true;
            
        }
        else
            visible = false;
    }

}
