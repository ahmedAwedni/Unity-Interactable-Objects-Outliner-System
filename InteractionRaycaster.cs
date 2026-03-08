using UnityEngine;

public class InteractionRaycaster : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float interactRange = 5f;
    [SerializeField] private LayerMask interactableLayer;

    private IInteractable _currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && _currentInteractable != null)
        {
            _currentInteractable.OnInteract();
        }
    }

    private void CheckForInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null && interactable != _currentInteractable)
            {
                ClearCurrentHover();
                _currentInteractable = interactable;
                _currentInteractable.OnHoverEnter();
            }
        }
        else
        {
            ClearCurrentHover();
        }
    }

    private void ClearCurrentHover()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.OnHoverExit();
            _currentInteractable = null;
        }
    }
}
