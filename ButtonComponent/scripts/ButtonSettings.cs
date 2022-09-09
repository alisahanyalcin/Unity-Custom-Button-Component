using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace alisahanyalcin.UI.Button
{
    public class ButtonSettings : MonoBehaviour
    {
        public bool useColor;
        public List<Image> images;
        public List<TextMeshProUGUI> texts;
        public Color normalColor;
        public Color hoverColor;
        public Color pressedColor;

        public void SetColor(MenuButton.ButtonState state)
        {
            switch (state)
            {
                case MenuButton.ButtonState.Normal:
                    foreach (var image in images)
                        image.color = this.normalColor;
                    foreach (var text in texts)
                        text.color = this.normalColor;
                    break;
                case MenuButton.ButtonState.Hover:
                    foreach (var image in images)
                        image.color = this.hoverColor;
                    foreach (var text in texts)
                        text.color = this.hoverColor;
                    break;
                case MenuButton.ButtonState.Exit:
                    foreach (var image in images)
                        image.color = this.normalColor;
                    foreach (var text in texts)
                        text.color = this.normalColor;
                    break;
                case MenuButton.ButtonState.Pressed:
                    foreach (var image in images)
                        image.color = this.pressedColor;
                    foreach (var text in texts)
                        text.color = this.pressedColor;
                    break;
            }
        }
    }
}