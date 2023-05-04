using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Maze : InteractiveBase
{
    [Header("��������� �����������")]
    [SerializeField] int id;            // ID �������� ��� ��������

    protected override void Interact()
    {
        if (type == Type.PLAYER)
        {
            if (player.GetComponent<Inventory>().Remove(id))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (spirit.GetComponent<Inventory>().Remove(id))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
