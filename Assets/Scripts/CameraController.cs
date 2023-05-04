using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float cameraSpeed;

    private Player player;
    private Spirit spirit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spirit = GameObject.FindGameObjectWithTag("Spirit").GetComponent<Spirit>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Transform current;
        if (player.Active) current = player.transform;
        else current = spirit.transform;

        Vector2 computedPosition = Vector2.Lerp(transform.position, current.position, cameraSpeed * Time.deltaTime);
        transform.position = new Vector3(computedPosition.x, computedPosition.y, transform.position.z);
    }
}
