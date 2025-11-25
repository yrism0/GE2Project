using UnityEngine;

public abstract class Interactable : MonoBehaviour
{ // SS - Interactable Script - The basis for all interactables and events

    // Variables

    public bool useEvents;
    public string promptMessage;

   public void BaseInteract()
    {
        if (useEvents) // IF useEvents is ticked in the editore THEN...
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke(); // Gets script and Invokes the Unity Event called "OnInteract"
        }            
        Interact();
    }

    protected virtual void Interact() // This function is overriden by other interactable scripts - It will run on Interaction
    {
        // SS - NO CODE TO BE WRITTEN HERE
    }
}
