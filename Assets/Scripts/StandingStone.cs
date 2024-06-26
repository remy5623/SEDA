using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StandingStone : MonoBehaviour
{
    [SerializeField]
    InputActionAsset actionAsset;

    Kelpie kelpie;
    Cailleach cailleach;

    InputAction placeAction;
    InputAction tapLocation;

    Terrainsystem TS1;

    // This function reference is necessary for callback registering/deregistering to work properly
    Action<InputAction.CallbackContext> click;

    private void Start()
    {
        kelpie = GetComponent<Kelpie>();
        cailleach = GetComponent<Cailleach>();

        placeAction = actionAsset.FindAction("click");
        click = ctx => Interact();
        placeAction.performed += click;

        tapLocation = actionAsset.FindAction("PanCamera");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            //Debug.DrawLine(transform.position, transform.position + Vector3.down * 100, Color.red, 500);
            TS1 = hit.transform.gameObject.GetComponent<Terrainsystem>();
        }
    }

    void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(tapLocation.ReadValue<UnityEngine.Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "StandingStone")
        {
            Debug.Log("Standngstone");
            VeilSwitch();
        }
    }

    void VeilSwitch()
    {
        if(kelpie != null)
            kelpie.StandingStoneKelpieImpact();
        else if (cailleach != null)
            cailleach.StandingStoneCailleachImpact();

    }

}
