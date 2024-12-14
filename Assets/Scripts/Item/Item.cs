using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public const string Tag = "Item";

    [SerializeField]
    private ItemModel itemModel;

    private Quaternion initialRotation;
    private Rigidbody body;

    public void SetState(ItemState state)
    {
        switch (state)
        {
            case ItemState.Idle:
                body.isKinematic = false;
                break;
            case ItemState.Drag:
                body.isKinematic = true;
                transform.rotation = initialRotation;
                break;
        }
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }
}
