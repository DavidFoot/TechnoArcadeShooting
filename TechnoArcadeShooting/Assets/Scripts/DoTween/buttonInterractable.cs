using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonInterractable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 m_size;
    private void Awake()
    {
        m_size = GetComponent<RectTransform>().sizeDelta;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOSizeDelta(m_size,3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOSizeDelta(m_size, .3f);
        GetComponent<Image>().DOColor(UnityEngine.Color.white, .3f);
    }
}
