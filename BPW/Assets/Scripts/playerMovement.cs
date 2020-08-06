using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject LeftOverlay;
    public GameObject RightOverlay;

    public GameObject PlayerRight;
    public Transform PlayerRightMovepoint;
    public bool PlayerScreen; // Als true = Left view    False = right view

    public float moveSpeed = 5f;
    public Transform movePoint;

    private Rigidbody2D rb;
    public LayerMask whatStopsMovement;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScreen = true;
        rb = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        PlayerRightMovepoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerScreen)
            {
                PlayerScreen = false;
            }
            else
            {
                PlayerScreen = true;
            }
        }
        if (PlayerScreen)
        {
             LeftOverlay.SetActive(false);
             RightOverlay.SetActive(true);
        }
        else
        {
            LeftOverlay.SetActive(true);
            RightOverlay.SetActive(false);
        }

        this.transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        PlayerRight.transform.position = Vector3.MoveTowards(PlayerRight.transform.position, PlayerRightMovepoint.position, moveSpeed * Time.deltaTime);


        //movement - checken welk scherm en movement samen
        if (!PlayerScreen)
        {
            if (Vector3.Distance(PlayerRight.transform.position, PlayerRightMovepoint.position) <= 0.1f)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3((Input.GetAxisRaw("Horizontal") - 0.2f), 0f, 0f), .2f, whatStopsMovement))
                    {
                        PlayerRightMovepoint.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") + -0.2f, 0f, 0f);
                    }
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3(Input.GetAxisRaw("Horizontal") + 0.2f, 0f, 0f), .2f, whatStopsMovement))
                    {
                        PlayerRightMovepoint.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") + 0.2f, 0f, 0f);
                    }
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f), .2f, whatStopsMovement))
                    {
                        PlayerRightMovepoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f);
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Vertical") + 0.2f), 0f, 0f), .2f, whatStopsMovement))
                        {
                            movePoint.transform.position += new Vector3(Input.GetAxisRaw("Vertical") + 0.2f, 0f, 0f);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f), .2f, whatStopsMovement))
                    {
                        PlayerRightMovepoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") + -0.2f, 0f);

                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Vertical") + 0.2f), 0f, 0f), .2f, whatStopsMovement))
                        {
                            movePoint.transform.position += new Vector3(Input.GetAxisRaw("Vertical") + -0.2f, 0f, 0f);
                        }
                    }
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") - 0.2f), 0f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") + -0.2f, 0f, 0f);
                        if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3(0f, Input.GetAxisRaw("Horizontal") + -0.2f, 0f), .2f, whatStopsMovement))
                        {
                            PlayerRightMovepoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Horizontal") + -0.2f, 0f);
                        }
                    }
                }
                else
            if (Input.GetKeyDown(KeyCode.D))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") + 0.2f, 0f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") + 0.2f, 0f, 0f);
                        if (!Physics2D.OverlapCircle(PlayerRightMovepoint.position + new Vector3(0f, Input.GetAxisRaw("Horizontal") + 0.2f, 0f), .2f, whatStopsMovement))
                        {
                            PlayerRightMovepoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Horizontal") + 0.2f, 0f);
                        }
                    }
                }
                else
            if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f);
                    }
                }
                else
            if (Input.GetKeyDown(KeyCode.S))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") + 0.2f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") + -0.2f, 0f);
                    }
                }
            }
        }        
    }
}
