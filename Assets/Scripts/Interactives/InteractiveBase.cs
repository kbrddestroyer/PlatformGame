using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractiveBase : MonoBehaviour
{
    protected enum Type { SPIRIT, PLAYER }
    [SerializeField, Header("Настройки взаимодействия")] protected Type type;
    [SerializeField, Range(0f, 10f)] protected float interactDistance;
    [SerializeField] private Color activeColor;
    protected Player player;
    protected Spirit spirit;

    private void OnDrawGizmos()
    {
        Gizmos.color = activeColor;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }

    protected abstract void Interact();

    // Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spirit = GameObject.FindGameObjectWithTag("Spirit").GetComponent<Spirit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == Type.PLAYER)
        {
            if (player.Active && Vector2.Distance(transform.position, player.transform.position) < interactDistance)
            {
                GetComponent<SpriteRenderer>().color = activeColor;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
            else GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            if (spirit.Active && Vector2.Distance(transform.position, spirit.transform.position) < interactDistance)
            {
                GetComponent<SpriteRenderer>().color = activeColor;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
            else GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
