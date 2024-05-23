using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    // The input action asset containing all actions related to camera movement
    [SerializeField]
    InputActionAsset cameraActions;

    // The actions
    InputAction possessAction;
    InputAction rotateAction;
    InputAction unpossessAction;

    /** Set all action variables and required callbacks */
    void Start()
    {
        if (cameraActions)
        {
            possessAction = cameraActions.FindAction("PossessCamera");
            rotateAction = cameraActions.FindAction("RotateCamera");
            unpossessAction = cameraActions.FindAction("UnpossessCamera");
        }

        if (possessAction != null)
        {
            possessAction.performed += ctx => PossessCamera();
        }

        if (unpossessAction != null)
        {
            unpossessAction.performed += ctx => UnpossessCamera();
        }
    }

    /** While the player is touching the screen, they can rotate the camera */
    public void PossessCamera()
    {
        if (rotateAction != null)
        {
            rotateAction.performed += RotateCamera;
        }
    }

    public void RotateCamera(InputAction.CallbackContext ctx)
    {

    }

    /** When the player lifts their finger from the screen, the camera stops moving */
    public void UnpossessCamera()
    { 
        if (rotateAction != null)
        {
            rotateAction.performed -= RotateCamera;
        }
    }
}
