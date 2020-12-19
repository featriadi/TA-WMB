using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject namaBarang;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (GameObject.Find("Play").GetComponent<Play>().getStatus() == "pilihBarang")
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDrop>().isRight = true;
                namaBarang = eventData.pointerDrag;
                if (eventData.pointerDrag.GetComponent<Item>().onSlot == false)
                {
                    //duplikasi item
                    GameObject item = Instantiate(eventData.pointerDrag);
                    item.GetComponent<RectTransform>().anchoredPosition = new Vector2(eventData.pointerDrag.GetComponent<DragDrop>().startX, eventData.pointerDrag.GetComponent<DragDrop>().startY);
                    item.GetComponent<CanvasGroup>().alpha = 1f;
                    item.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    item.transform.SetParent(GameObject.Find("PilihBarang").GetComponent<Transform>());
                    //end
                    eventData.pointerDrag.GetComponent<Item>().onSlot = gameObject;
                }
                else
                {
                    namaBarang.GetComponent<Item>().onSlot.GetComponent<Slot>().namaBarang = null;
                }
            }
            else if (GameObject.Find("Play").GetComponent<Play>().getStatus() == "pilihHarga")
            {
                if (GameObject.Find("Order").GetComponent<NPCSlot>().cekJumlahHarga(eventData.pointerDrag.GetComponent<Item>().jumlah))
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<DragDrop>().isRight = true;
                    GameObject.Find("Play").GetComponent<Play>().ubahStatus("pilihKembalian");
                }
                else
                {
                    GameObject.Find("Player").GetComponent<Player>().kurangNyawa();
                }
            }
            else if (GameObject.Find("Play").GetComponent<Play>().getStatus() == "pilihKembalian")
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDrop>().isRight = true;
            }
        }
    }
}
