using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Outline Settings")]
    [SerializeField] private Outline outline; // Reference to an outline component/shader

    private void Awake()
    {
        if (outline == null) outline = GetComponent<Outline>();
        if (outline != null) outline.enabled = false;
    }

    public void OnHoverEnter() 
    {
        if (outline != null) outline.enabled = true;
    }

    public void OnHoverExit() 
    {
        if (outline != null) outline.enabled = false;
    }

    public void OnInteract()
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }
}
