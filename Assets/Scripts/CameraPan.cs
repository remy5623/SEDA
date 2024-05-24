using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraPan : MonoBehaviour
{
    // The input action asset containing all actions related to camera movement
    [SerializeField] InputActionAsset cameraActions;

    // The actions
    InputAction possessAction;
    InputAction rotateAction;
    InputAction unpossessAction;
    InputAction mouseWheelAction;

    bool isCursorPosInitialised = false;    // Initialises when the player clicks on the screen
        Camera orthoCam;
    float initialOrthoSize;
    Vector2 prevPos;                // Used to determine the direction of the camera's movement
    Vector2 panDistance;


    [Header("Camera Movement Speed")]

    [SerializeField]
    [Tooltip("Controls the camera's pan speed.")]
    float panSpeed = 0.025f;

    [SerializeField]
    [Tooltip("Controls the camera's zoom speed.")]
    float zoomSpeed = 0.5f;


    [Header("Camera Limits")]

    [SerializeField]
    [Tooltip("The distance the camera is allowed to pan.")]
    Vector2 panLimit = new Vector2(10, 10);

    [SerializeField]
    [Tooltip("The distance the camera is allowed to zoom in.")]
    float minZoomDistance = 3.5f;

    [SerializeField]
    [Tooltip("The distance the camera is allowed to zoom out.")]
    float maxZoomDistance = 10f;

    /** Set all initial variables and required callbacks */
    void Start()
    {
        if (cameraActions)
        {
            possessAction = cameraActions.FindAction("PossessCamera");
            rotateAction = cameraActions.FindAction("RotateCamera");
            unpossessAction = cameraActions.FindAction("UnpossessCamera");
            mouseWheelAction = cameraActions.FindAction("MouseWheelZoom");
        }

        if (possessAction != null)
        {
            possessAction.performed += ctx => PossessCamera();
        }

        if (unpossessAction != null)
        {
            unpossessAction.performed += ctx => UnpossessCamera();
        }

        if (mouseWheelAction != null)
        {
            mouseWheelAction.performed += MouseWheelZoom;
        }

        if (orthoCam = FindAnyObjectByType<Camera>())
        {
            initialOrthoSize = orthoCam.orthographicSize;
        }
    }

    /** While the player is touching the screen, they can rotate the camera */
    void PossessCamera()
    {
        if (rotateAction != null)
        {
            rotateAction.performed += PanCamera;
        }
    }

    /** Pan the camera when the player taps and drags the screen */
    void PanCamera(InputAction.CallbackContext context)
    {
        Vector2 currentPos = context.ReadValue<Vector2>();

        if (isCursorPosInitialised)
        {
            Vector3 deltaPos = currentPos - prevPos;
            // panning movement is scaled by a global speed as well as a ratio of the screen size
            deltaPos *= panSpeed * (orthoCam.orthographicSize / initialOrthoSize);
            deltaPos = ClampedPan(deltaPos);

            // Transform.Translate applies the tranformation to local space by default
            transform.Translate(deltaPos);
        }
        else
        {
            isCursorPosInitialised = true;
        }

        prevPos = currentPos;
    }

    /** Clamps the camera's panning movement and returns an adjusted deltaPos */
    Vector2 ClampedPan(Vector2 deltaPos)
    {
        panDistance += deltaPos;

        if (panDistance.x > panLimit.x)
        {
            deltaPos.x -= panDistance.x - panLimit.x;
            panDistance.x = panLimit.x;
        }
        else if (panDistance.x < -panLimit.x)
        {
            deltaPos.x += -panDistance.x - panLimit.x;
            panDistance.x = -panLimit.x;
        }
        
        if (panDistance.y > panLimit.y)
        {
            deltaPos.y -= panDistance.y - panLimit.y;
            panDistance.y = panLimit.y;
        }
        else if (panDistance.y < -panLimit.y)
        {
            deltaPos.y += -panDistance.y - panLimit.y;
            panDistance.y = -panLimit.y;
        }

        return deltaPos;
    }

    /** When the player lifts their finger from the screen, the camera stops moving */
    void UnpossessCamera()
    {
        if (rotateAction != null)
        {
            rotateAction.performed -= PanCamera;
            isCursorPosInitialised = false;
        }
    }

    /** Applies camera zoom based on input from the mouse wheel */
    void MouseWheelZoom(InputAction.CallbackContext context)
    {
        float mouseWheelDirection = context.ReadValue<float>();

        if (mouseWheelDirection > 0)
        {
            Zoom(true);
        }
        else if (mouseWheelDirection < 0)
        {
            Zoom(false);
        }
    }

    /** Zooms the camera in and out
     *  This is for an orthographic camera
     *  Changes the size of the orthographic viewport
     */
    void Zoom(bool isZoomForward)
    {
        Camera orthoCam;

        if (orthoCam = FindAnyObjectByType<Camera>())
        {
            if (isZoomForward)
            {
                orthoCam.orthographicSize -= zoomSpeed;
                
                // Clamped min zoom distance
                if (orthoCam.orthographicSize < minZoomDistance)
                {
                    orthoCam.orthographicSize += zoomSpeed;
                }
            }
            else
            {
                orthoCam.orthographicSize += zoomSpeed;

                // Clamped max zoom distance
                if (orthoCam.orthographicSize > maxZoomDistance)
                {
                    orthoCam.orthographicSize = maxZoomDistance;
                }
            }
        }
    }
}
