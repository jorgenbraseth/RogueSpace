using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModalWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject window;

    private OnClickCallback onclick;

    public delegate void OnClickCallback();

    public void Open(OnClickCallback whenClicked)
    {
        onclick = whenClicked;
        Time.timeScale = 0;
        window.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        window.SetActive(false);
        Time.timeScale = 1;
        onclick();
    }
}
