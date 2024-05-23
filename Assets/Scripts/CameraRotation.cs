using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    // The input action asset containing all actions related to camera movement
    [SerializeField] InputActionAsset cameraActions;

    // The actions
    InputAction possessAction;
    InputAction rotateAction;
    InputAction unpossessAction;

    bool isCursorPosInitialised = false;
    [SerializeField] float cameraSpeed = 0.025f;
    Vector2 prevPos;

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
    void PossessCamera()
    {
        if (rotateAction != null)
        {
            rotateAction.performed += RotateCamera;
        }
    }

    void RotateCamera(InputAction.CallbackContext context)
    {
        Vector2 currentPos = context.ReadValue<Vector2>();

        if (isCursorPosInitialised)
        {
            Vector2 deltaPos = currentPos - prevPos;
            deltaPos *= cameraSpeed;

            gameObject.transform.RotateAround(Vector3.zero, gameObject.transform.right, -deltaPos.y);
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, deltaPos.x);
        }
        else
        {
            isCursorPosInitialised = true;
        }

        prevPos = currentPos;
    }

    /** When the player lifts their finger from the screen, the camera stops moving */
    void UnpossessCamera()
    { 
        if (rotateAction != null)
        {
            rotateAction.performed -= RotateCamera;
            isCursorPosInitialised = false;
        }
    }
}
