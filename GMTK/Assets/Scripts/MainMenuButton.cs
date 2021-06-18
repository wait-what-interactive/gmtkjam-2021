using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        SoundManager.instance.HoverButtonPlay();
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        SoundManager.instance.HoverButtonStop();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SoundManager.instance.HoverButtonStop();
    }
}
