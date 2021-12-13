using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private  int startX = -1123;
    [SerializeField] private int startY= -49;
    [SerializeField] private List<GameObject> side;
    private int maxX = 1025;
    private int maxY = 471;
    private int minX = -1107;
    private int minY = -569;
    private Rigidbody2D rb2D;
    private Joystick joystick;
    private Vector2 movement;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }
    private void Start()
    {
        transform.localPosition = new Vector2(startX, startY);
        side[0].SetActive(true);
    }

    private void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }
    private void FixedUpdate()
    {
        CheckSidePLayer();
        // rb2D.MovePosition(rb2D.position + movement * 5 * Time.fixedDeltaTime);
        
        rb2D.MovePosition(rb2D.position + movement * 4* Time.fixedDeltaTime);
        Debug.Log("X" +movement.x);
        Debug.Log("Y"+movement.y);
        CheckMaxAndMinPos();
    }
    private void CheckMaxAndMinPos()
    {
        if (transform.localPosition.x > maxX)
            transform.localPosition = new Vector2(maxX, transform.localPosition.y);
        else if (transform.localPosition.x < minX)
            transform.localPosition = new Vector2(minX, transform.localPosition.y);
        else if (transform.localPosition.y > maxY)
            transform.localPosition = new Vector2(transform.localPosition.x, maxY);
        else if (transform.localPosition.y < minY)
            transform.localPosition = new Vector2(transform.localPosition.x, minY);
    }
    private void CheckSidePLayer()
    {
                
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            foreach (GameObject go in side)
                go.SetActive(false);
            if (movement.x > 0)
                side[0].SetActive(true);
            else if (movement.x < 0)
                side[1].SetActive(true);
        }
        else if(Mathf.Abs(movement.x) < Mathf.Abs(movement.y))
        {
            foreach (GameObject go in side)
                go.SetActive(false);
            if (movement.y > 0)
                side[2].SetActive(true);
            else if(movement.y < 0)
                side[3].SetActive(true);
        }
    }
}
