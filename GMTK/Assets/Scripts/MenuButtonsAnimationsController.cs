using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;

public class MenuButtonsAnimationsController : MonoBehaviour
{ 
    public GameObject animatedObject;

    private Animator _anim;

    void Start()
    {
        _anim = animatedObject.GetComponent<Animator>();

        if (_anim == null)
            Debug.LogError("Animator was not loaded");

        //StartCoroutine(ButtonAnimationsHandler());
    }

    IEnumerator ButtonAnimationsHandler()
    {
        while (true)
        {

            yield return .3f;
        }
    }
}
