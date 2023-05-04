using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] images = new Image[3];
    public List<Pickable> items = new List<Pickable>();
    public List<Pickable> Items { get { return items; } }
    public bool Add(Pickable item)
    {
        Debug.Log(items.Count);
        if (items.Count == 3) return false;

        items.Add(item);
        images[items.Count - 1].enabled = true;
        images[items.Count - 1].sprite = item.GetComponent<SpriteRenderer>().sprite;

        return true;
    }

    public bool Remove(int id)
    {
        int counter = 0;
        foreach (Pickable item in items)
        {
            if (item.ID == id)
            {
                items.Remove(item);
                for (int i = counter; i < images.Length - 1 && images[i + 1].enabled; i++)
                {
                    images[i].sprite = images[i + 1].sprite;
                }
                images[items.Count].enabled = false;
                return true;
            }
            counter++;
        }
        return false;
    }
}
