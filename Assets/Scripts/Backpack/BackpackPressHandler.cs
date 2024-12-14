using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BackpackPressHandler: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField]
    private float longPressThreshold = 1.0f; // Time to trigger long pres

    [SerializeField]
    private UnityEvent<Backpack> onLongPress; // Event for long press

    [SerializeField]
    private Backpack target;

    private bool isPressing = false;  // Tracks if the pointer is held down
    private float pressStartTime;     // Time when the press started

    private bool longPressTriggered = false; // Prevent multiple triggers

    private void Update()
    {
        // Check for long press while pressing
        if (isPressing && !longPressTriggered && Time.time - pressStartTime >= longPressThreshold)
        {
            longPressTriggered = true; // Prevent multiple events for a single long press
            onLongPress.Invoke(target);     // Trigger the event
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        longPressTriggered = false;   // Reset trigger flag
        pressStartTime = Time.time;   // Record the start time
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;           // Reset pressing flag
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPressing = false;           // Cancel pressing if pointer exits the GameObject
    }
}
