using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace alisahanyalcin.UI.Button
{
    [RequireComponent(typeof(ButtonSettings))]
    public class MenuButton : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public enum ButtonState
        {
            Normal,
            Hover,
            Exit,
            Pressed
        }

        public ButtonState buttonState = ButtonState.Normal;

        [Space] [SerializeField] private UnityEvent @normal;
        [Space] [SerializeField] private UnityEvent @hover;
        [Space] [SerializeField] private UnityEvent @exit;
        [Space] [SerializeField] private UnityEvent @pressed;

        private bool _pressed = false;
        private ButtonSettings _buttonSettings;
        
        private void Start()
        {
            _buttonSettings = GetComponent<ButtonSettings>();
            if (_buttonSettings != null)
                _buttonSettings.SetColor(buttonState);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonState = ButtonState.Hover;
            _buttonSettings.SetColor(ButtonState.Hover);
            
            if (!_pressed)
                TriggerEvent(buttonState);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonState = ButtonState.Exit;
            _buttonSettings.SetColor(ButtonState.Exit);
            TriggerEvent(buttonState);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            buttonState = ButtonState.Pressed;
            _buttonSettings.SetColor(ButtonState.Pressed);
            
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            TriggerEvent(buttonState);

            _pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            buttonState = ButtonState.Normal;
            _buttonSettings.SetColor(ButtonState.Normal);
            
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            TriggerEvent(buttonState);

            _pressed = false;
        }

        private void TriggerEvent(ButtonState state)
        {
            switch (state)
            {
                case ButtonState.Normal:
                    @normal.Invoke();
                    break;
                case ButtonState.Hover:
                    @hover.Invoke();
                    break;
                case ButtonState.Exit:
                    @exit.Invoke();
                    break;
                case ButtonState.Pressed:
                    @pressed.Invoke();
                    break;
            }
        }
    }
}
