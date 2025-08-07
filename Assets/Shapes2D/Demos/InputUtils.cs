namespace Shapes2D {
    
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class InputUtils {

        public static Vector3 InputToWorldPosition(Vector2 inputPos) {
            Vector3 pos = new Vector3(inputPos.x, inputPos.y, 
                    -Camera.main.transform.position.z);
            return Camera.main.ScreenToWorldPoint(pos);
        }


        public static bool MouseDownOrTap() {
            if (Mouse.current?.leftButton.wasPressedThisFrame == true)
                return true;

            if (Touchscreen.current != null)
            {
                foreach (var touch in Touchscreen.current.touches)
                {
                    if (touch.press.wasPressedThisFrame)
                        return true;
                }
            }

            return false;
        }
        
        public static Vector2 MouseOrTapPosition() {
            if (Touchscreen.current != null)
            {
                foreach (var touch in Touchscreen.current.touches)
                {
                    if (touch.press.isPressed)
                        return touch.position.ReadValue();
                }
            }

            if (Mouse.current != null)
            {
                return Mouse.current.position.ReadValue();
            }

            return Vector2.zero;
        }

    }

}