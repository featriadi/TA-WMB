using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nama;
    public int jumlah;
    public GameObject onSlot;

    /*public void duplicate(GameObject barang, float x, float y, float alphaOrigin, bool blocksRaycastsOrigin)
    {
        
        GameObject item = Instantiate(barang);
        item.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        item.GetComponent<CanvasGroup>().alpha = alphaOrigin;
        item.GetComponent<CanvasGroup>().blocksRaycasts = blocksRaycastsOrigin;
        item.transform.SetParent(GameObject.Find("PilihBarang").GetComponent<Transform>());
        
    }*/
}
