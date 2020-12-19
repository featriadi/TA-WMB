using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    public static DragDrop Instance { get; private set; }

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector2 startPosition;
    public float startX;
    public float startY;
    public bool isRight;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        isRight = false;

        startX = rectTransform.position.x;
        startY = rectTransform.position.y;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (isRight == false)
        {
            transform.position = startPosition;
        }
        else
        {
            isRight = false;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop 2");
    }
}
