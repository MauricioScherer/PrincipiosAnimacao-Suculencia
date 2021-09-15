using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    private bool click = true;

    private Animator btn;
    [SerializeField] Animator cubin;
    [SerializeField] Texture2D[] cursors;
    [SerializeField] float timeReset;
    [SerializeField] bool comSuculencia;

    private void Start()
    {
        btn = GetComponent<Animator>();
    }

    public void ClickButton()
    {
        if(click)
        {
            btn.SetTrigger("click");
            if(comSuculencia)
                cubin.SetTrigger("Move");
            else
                cubin.SetTrigger("MoveSemSuculencia");
            click = false;
            Invoke("ResetClick", timeReset);

            GetComponent<AudioSource>().Play();
        }
    }

    private void ResetClick()
    {
        click = true;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursors[1], Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickButton();
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.Auto);
    }
}
