using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{ 
    private int rayLength = 10;
    private ButtonController currentButton;

    private bool useRay = true;

    public bool ChangeRay
    {
        set
        {
            useRay = value;
        }
    }
    private void Update()
    {
        if (useRay)
        {
            Ray ray = new Ray(transform.position, transform.forward * rayLength);
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                ButtonController button = raycastHit.collider.gameObject.GetComponent<ButtonController>();
                if (button)
                {
                    if (currentButton && currentButton != button)
                    {
                        currentButton.Deselect();
                    }
                    currentButton = button;
                    button.Select();
                }
                else if (currentButton)
                {
                    currentButton.Deselect();
                }
            }
        }
    }
}
