using UnityEngine;

public class Controls: MonoBehaviour
{
	private float rotationSpeed = 0.5f;
	private float zoomSpeed = 0.5f;
	private float minZoom = 1f;
	private float maxZoom = 20f;

	private Vector2 previousTouchPosition;

	void Update()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved)
			{
				float rotationX = touch.deltaPosition.y * rotationSpeed;
				float rotationY = -touch.deltaPosition.x * rotationSpeed;

				transform.Rotate(rotationX, rotationY, 0, Space.World);
			}
		}
		else if (Input.touchCount == 2)
		{
			Touch touch0 = Input.GetTouch(0);
			Touch touch1 = Input.GetTouch(1);

			if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
			{
				Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
				Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

				float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
				float touchDeltaMag = (touch0.position - touch1.position).magnitude;

				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

				float zoomAmount = deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;
				float newZoom = transform.localScale.x + zoomAmount;

				newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

				transform.localScale = new Vector3(newZoom, newZoom, newZoom);
			}
			else if (touch0.phase == TouchPhase.Began && touch1.phase == TouchPhase.Began)
			{
				previousTouchPosition = touch1.position - touch0.position;
			}
		}
	}
}
