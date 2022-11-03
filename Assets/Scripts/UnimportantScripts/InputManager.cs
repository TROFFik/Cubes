using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static InputManager Singletone { get; private set; }
    [SerializeField] private PlayerRay playerRay;

    [SerializeField] private GameObject controlButtons;
    [SerializeField] private Button pressE;
    [SerializeField] private GameObject contaner;
    
    [SerializeField] private TMP_InputField currentX;
    [SerializeField] private TMP_InputField currentY;
    [SerializeField] private TMP_InputField currentZ;
    [SerializeField] private TMP_InputField currentVariableAffectingMovement;

    [SerializeField] private TextMeshProUGUI placeholderX;
    [SerializeField] private TextMeshProUGUI placeholderY;
    [SerializeField] private TextMeshProUGUI placeholderZ;
    [SerializeField] private TextMeshProUGUI placeholderVariableAffectingMovement;

    private Vector3 inputData;
    private float inputVariableAffectingMovement;
    private ControlPanel controlPanel;
    private ButtonController buttonController;
    private void Awake()
    {
        Singletone = this;
    }
    public void EndInput()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controlPanel.ReturnValue(inputData, inputVariableAffectingMovement);
        contaner.SetActive(false);
        controlButtons.SetActive(true);
        playerRay.ChangeRay = true;
    }

    public void InputX()
    {
        inputData.x = Convert.ToSingle(currentX.text);
    }

    public void InputY()
    {
        inputData.y = Convert.ToSingle(currentY.text);
    }

    public void InputZ()
    {
        inputData.z = Convert.ToSingle(currentZ.text);
    }

    public void InputVariableAffectingMovement()
    {
        inputVariableAffectingMovement = Convert.ToInt32(currentVariableAffectingMovement.text);
    }
    public void StartInput(float VariableAffectingMovement, Vector3 CurrentValue, ControlPanel ControlPanel)
    {
        Cursor.lockState = CursorLockMode.Confined;
        controlPanel = ControlPanel;

        contaner.SetActive(true);
        controlButtons.SetActive(false);
        playerRay.ChangeRay = false;
        DontShowButton();
        placeholderVariableAffectingMovement.text = VariableAffectingMovement.ToString();
        placeholderX.text = CurrentValue.x.ToString();
        placeholderY.text = CurrentValue.y.ToString();
        placeholderZ.text = CurrentValue.z.ToString();
    }

    public void ShowKeyboard()
    {
        TouchScreenKeyboard.Open("");
    }

    public void ShowButtonPressE(ButtonController ButtonController)
    {
        buttonController = ButtonController;

        pressE.gameObject.SetActive(true);
    }

    public void DontShowButton()
    {
        pressE.gameObject.SetActive(false);
    }
    
    public void Press()
    {
        buttonController.PressButton();
    }
}
