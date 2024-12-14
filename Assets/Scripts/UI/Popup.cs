using UnityEngine;
using UnityEngine.UI;

public abstract class Popup : MonoBehaviour
{
    [SerializeField]
    protected Button buttonClose;

    public abstract PopupType PopupType { get; }

    private void OnEnable()
    {
        buttonClose.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        buttonClose.onClick.RemoveListener(Hide);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}