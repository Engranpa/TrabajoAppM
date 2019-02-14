using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class JoystickMira : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
        public Joystick joystickmira;
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontalM, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public string horizontalmAxisName = "HorizontalM"; // The name given to the horizontal axis for the cross platform input


		Vector3 m_StartPos;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalMVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
      

        void Start()
        {
            CreateVirtualAxes();
            m_StartPos = transform.position;
            
        }

		void UpdateVirtualAxes(Vector3 value)
		{
			var delta = m_StartPos - value;
			delta.y = -delta.y;
			delta /= MovementRange;
			if (m_UseX)
			{
				m_HorizontalMVirtualAxis.Update(-delta.x);
			}

		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontalM);

			// create new axes based on axes to use
			if (m_UseX)
			{
				m_HorizontalMVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalmAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalMVirtualAxis);
			}
		}


		public void OnDrag(PointerEventData data)
		{
			Vector3 newPos = Vector3.zero;

			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				//delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
				newPos.x = delta;
			}

			transform.position = Vector3.ClampMagnitude( new Vector3(newPos.x, 0,newPos.z), MovementRange) + m_StartPos;
			UpdateVirtualAxes(transform.position);
		}


		public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
		}


		public void OnPointerDown(PointerEventData data) { }

		void OnDisable()
		{
			// remove the joysticks from the cross platform input
			if (m_UseX)
			{
				m_HorizontalMVirtualAxis.Remove();
			}
		
		}
	}
}