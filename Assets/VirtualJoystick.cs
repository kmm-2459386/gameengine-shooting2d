using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Image joystickBackground;
    public Image joystickHandle;

    private Vector2 inputVector;

    void Start()
    {
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position - (Vector2)joystickBackground.rectTransform.position;
        position /= joystickBackground.rectTransform.sizeDelta;

        inputVector = new Vector2(position.x * 2, position.y * 2);
        inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

        // スティックの中心からノブの位置を設定
        joystickHandle.rectTransform.anchoredPosition = new Vector2(
            inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2),
            inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2)
        );
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero; // スティックの中心に戻す
    }

    public float Horizontal() { return inputVector.x; }
    public float Vertical() { return inputVector.y; }
}