using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip hover;
    public AudioClip click;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        SoundManager.instance.ButtonPlay(hover);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        SoundManager.instance.ButtonStop();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SoundManager.instance.ButtonPlay(click);
    }
}
