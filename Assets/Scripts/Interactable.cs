using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string PromptMessage;
    public bool UseEvents;

    public void BaseInteract()
    {
        if (UseEvents) 
        { 
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }

        Interact();
    }

    protected virtual void Interact(){}
}
