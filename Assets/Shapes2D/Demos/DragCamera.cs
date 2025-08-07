namespace Shapes2D {

	using UnityEngine;
	using System.Collections;
	using UnityEngine.InputSystem;

	public class DragCamera : MonoBehaviour {
		Vector3 anchor;
		Vector3 origin;
		bool dragging;
		bool zoomed;
		float lastClick;

		void LateUpdate () {
			if (Mouse.current.leftButton.wasPressedThisFrame) {
				float time = Time.time;
				if (time - lastClick < 0.3f) {
					zoomed = !zoomed;
					if (zoomed)
						Camera.main.orthographicSize = 1;
					else
						Camera.main.orthographicSize = 7.35f;
				}
				lastClick = time;
				dragging = true;
				anchor = Mouse.current.position.ReadValue();
				origin = Camera.main.transform.position;
			}
			if (Mouse.current.leftButton.wasReleasedThisFrame) {
				dragging = false;
			}
			if (dragging) {
				Vector3 mousePos = Mouse.current.position.ReadValue();
				Vector3 delta = Camera.main.ScreenToWorldPoint(mousePos - anchor
				                - new Vector3(-Screen.width / 2f, -Screen.height / 2f, Camera.main.transform.position.z))
				                - new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

				Camera.main.transform.position = origin - delta;
			}
		}
	}

}