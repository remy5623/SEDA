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

    bool isCursorPosInitialised = false;            // Initialises when the player clicks on the screen
    
    [SerializeField]
    [Tooltip("Controls the speed of the camera's rotation.")]
    float cameraSpeed = 0.025f;

    
    [Header("Camera Angle Limits")]

    [SerializeField]
    [Tooltip("The lowest angle the camera's X rotation can reach.")]
    float pitchLowerLimit = 0f;

    [SerializeField]
    [Tooltip("The highest angle the camera's X rotation can reach.")]
    float pitchUpperLimit = 55f;
    
    Vector2 prevPos;    // Used to determine the direction of the camera's rotation

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

    /** Rotates the camera when the player taps and drags the screen */
    void RotateCamera(InputAction.CallbackContext context)
    {
        Vector2 currentPos = context.ReadValue<Vector2>();

        if (isCursorPosInitialised)
        {
            Vector2 deltaPos = currentPos - prevPos;
            deltaPos *= cameraSpeed;

            // Rotate around the centre of the world
            gameObject.transform.RotateAround(Vector3.zero, gameObject.transform.right, -deltaPos.y);
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, deltaPos.x);
            ClampRotation(deltaPos);
        }
        else
        {
            isCursorPosInitialised = true;
        }

        prevPos = currentPos;
    }

    /** Clamps the camera's rotation to keep the camera from being turned upside down or moving underground */
    void ClampRotation(Vector2 delta)
    {
        float rotX = gameObject.transform.rotation.eulerAngles.x;

        if (rotX < pitchLowerLimit || rotX > pitchUpperLimit)
        {
            gameObject.transform.RotateAround(Vector3.zero, gameObject.transform.right, delta.y);
        }
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
