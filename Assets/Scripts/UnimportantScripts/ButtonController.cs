using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonController : MonoBehaviour
{
    [SerializeField] protected MovmentCore movmentCore;
    [SerializeField] protected GameObject text;

    protected Color currentColor = Color.red;

    protected InputManager inputManager;
    private void Start()
    {
        inputManager = InputManager.Singletone;
    }
    public void Select()
    {
        text.SetActive(true);
        inputManager.ShowButtonPressE(this);
        Press();
    }

    public void Deselect()
    {
        text.SetActive(false);
        inputManager.DontShowButton();
    }
    public virtual void Press()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentColor == Color.red)
            {
                movmentCore.ChangeCreate = true;
                currentColor = Color.green;
            }
            else
            {
                movmentCore.ChangeCreate = false;
                currentColor = Color.red;
            }
        }
    }
    public virtual void PressButton()
    {
        movmentCore.ChangeCreate = !movmentCore.ChangeCreate;
    }
}
