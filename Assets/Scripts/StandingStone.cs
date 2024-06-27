using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StandingStone : MonoBehaviour
{
    [SerializeField]
    InputActionAsset actionAsset;

    [SerializeField] Kelpie kelpie;
    
    [SerializeField] Cailleach cailleach;

    InputAction placeAction;
    InputAction tapLocation;

    Terrainsystem TS1;

    // This function reference is necessary for callback registering/deregistering to work properly
    Action<InputAction.CallbackContext> click;

    private void Start()
    {
        //kelpie = FindFirstObjectByType<Kelpie>();
        //cailleach = FindFirstObjectByType<Cailleach>();
        kelpie.gameObject.SetActive(false);
        cailleach.gameObject.SetActive(false);

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
        if (cailleach != null)
            cailleach.StandingStoneCailleachImpact();
    }

}
