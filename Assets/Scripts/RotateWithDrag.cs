using UnityEngine;

namespace RakibUtils
{
    public class RotateWithDrag : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float rotationRate = 1.0f;
        private float m_previousX;
        private float m_previousY;
        [SerializeField] private Camera m_camera;

        private void Update ()
        {

            if (Input.GetMouseButtonDown(1))
            {
                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }

            if(Input.GetMouseButton(1)) 
            {
                var deltaX = (Input.mousePosition.y - m_previousY) * rotationRate;
                var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
                transform.Rotate (deltaX, deltaY, 0, Space.World);
                
                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }
        }
    }
}