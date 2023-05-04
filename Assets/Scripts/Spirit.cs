using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float speed;
    [SerializeField, Range(0f, 2f)] private float chaseDistance;
    private Player player;
    private bool active = false;
    public bool Active { get { return active; } }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Debug.Log("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            active = !active;
        }

        if (active)
        {
            float axisX = Input.GetAxis("Horizontal");  // Ось Х (в WASD - AD). Юзаем ее для перемещения персонажа
            float axisY = Input.GetAxis("Vertical");    // Ось Y (в WASD - WS). Используем для прыжков/crouch-состояния

            Vector2 movement = new Vector2(axisX, axisY) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(chaseDistance * player.Direction * -1, 0, 0), speed / 2f * Time.deltaTime);
        }
    }
}
