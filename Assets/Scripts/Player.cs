using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0f, 25f)] private float speed;
    [SerializeField, Range(0f, 25f)] private float crouchSpeed;
    [SerializeField, Range(0f, 25f)] private float sprintSpeed;
    [SerializeField, Range(0f, 10f)] private float jumpForce;
    [SerializeField, Range(0f, 2f)] private float crouchHeight;
    
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    private float basicHeight;

    public bool isOnGround = false;
    private bool active = true;
    public bool Active { get { return active; } }

    private int direction = 1;
    public int Direction { get { return direction; } }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();

        basicHeight = collider.size.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            active = !active;
        }

        /* ÁËÎÊ ÊÎÄÀ ÄËß ÏÅÐÅÌÅÙÅÍÈß ÎÑÍÎÂÍÎÃÎ ÏÅÐÑÎÍÀÆÀ */
        if (active)
        {
            float axisX = Input.GetAxis("Horizontal");  // Îñü Õ (â WASD - AD). Þçàåì åå äëÿ ïåðåìåùåíèÿ ïåðñîíàæà
            float axisY = Input.GetAxis("Vertical");    // Îñü Y (â WASD - WS). Èñïîëüçóåì äëÿ ïðûæêîâ/crouch-ñîñòîÿíèÿ
            bool crouch = Input.GetKey(KeyCode.LeftControl);

            if (axisX != 0)
                direction = (int) (axisX / Mathf.Abs(axisX));

            float resultSpeed;
            if (!crouch)
            {
                resultSpeed = ((Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed));

                collider.size = new Vector2(collider.size.x, basicHeight);
                collider.offset = new Vector2(collider.offset.x, basicHeight / 2.0f - 1);
            }
            else
            {
                resultSpeed = crouchSpeed;
                collider.size = new Vector2(collider.size.x, crouchHeight);
                collider.offset = new Vector2(collider.offset.x, crouchHeight / 2.0f - 1);
            }
            Vector2 movement = new Vector2(axisX, 0) * resultSpeed * Time.deltaTime;
            transform.Translate(movement);

            if ((axisY > 0f || Input.GetKeyDown(KeyCode.Space)) && isOnGround)
            {
                rb.AddForce(Vector2.up * jumpForce * 100f);
                isOnGround = false;
            }
        }
    }
}
