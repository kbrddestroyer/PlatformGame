using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pickable : InteractiveBase
{
    [Header("��������� ����������")]
    [SerializeField] private int id;    // ����� ��������
    public int ID { get { return id; } }

    protected override void Interact()
    {
        if (type == Type.PLAYER)
        {
            if (player.GetComponent<Inventory>().Add(this))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (spirit.GetComponent<Inventory>().Add(this))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
