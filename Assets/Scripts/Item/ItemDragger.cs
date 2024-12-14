using UnityEngine;
using Zenject;

public class ItemDragger : MonoBehaviour
{
    private Item target;
    private Camera mainCamera;

    private float liftAltitude;

    [Inject]
    private void Construct(GameConfig config)
    {
        liftAltitude = config.LiftAltitude;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && target == null) // if we hold our mouse and our target is not selected yet
        {
            SelectItem();
        }
        
        if (target != null) 
        {
            ChangeTargetPosition();

            if (Input.GetMouseButtonUp(0)) // if we have just released mouse button and target is still selected
            {
                DeselectItem();
            }
        }
    }

    private void SelectItem()
    {
        var hit = CastRay();
        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag(Item.Tag))
            {
                return;
            }
        }

        target = hit.collider.GetComponent<Item>();
        target.SetState(ItemState.Drag);
        Cursor.visible = false;
    }

    private void DeselectItem()
    {
        target.SetState(ItemState.Idle);
        target = null;
        Cursor.visible = true;
    }

    private RaycastHit CastRay()
    {
        var mousePosition = Input.mousePosition;
        var farMousePosition = new Vector3(mousePosition.x, mousePosition.y, mainCamera.farClipPlane);
        var nearMousePosition = new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane);
        var worldMousePositionFar = mainCamera.ScreenToWorldPoint(farMousePosition);
        var worldMousePositionNear = mainCamera.ScreenToWorldPoint(nearMousePosition);

        RaycastHit hit;

        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }

    private void ChangeTargetPosition()
    {
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(target.transform.position).z);
        var worldPos = mainCamera.ScreenToWorldPoint(position);
        target.transform.position = new Vector3(worldPos.x, liftAltitude, worldPos.z);
    }
}