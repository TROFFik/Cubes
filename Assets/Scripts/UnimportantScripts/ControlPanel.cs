using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : ButtonController
{
    private void Start()
    {
        inputManager = InputManager.Singletone;
    }
    public override void Press()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 TempVector;
            float TempFloat;

            TempVector = movmentCore.TargetPosValue;
            TempFloat = movmentCore.Value;
            inputManager.StartInput(TempFloat, TempVector, this);
        }
    }

    public void ReturnValue(Vector3 NewValue, float variableAffectingMovement)
    {
        movmentCore.TargetPosValue = NewValue;
        movmentCore.Value = variableAffectingMovement;
    }

    public override void PressButton()
    {
        Vector3 TempVector;
        float TempFloat;

        TempVector = movmentCore.TargetPosValue;
        TempFloat = movmentCore.Value;
        inputManager.StartInput(TempFloat, TempVector, this);
    }
}
