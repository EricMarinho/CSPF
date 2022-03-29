using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("isSelected",true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("isSelected",false);
    }

}