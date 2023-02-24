using UnityEngine;

 public class RotateWithDrag : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float rotationRate = 1.0f;
        private float m_previousX;
        private float m_previousY;
        private ToolLogic toolLogic;
        public Transform targetTransform;

    private void Start()
    {
        toolLogic = this.gameObject.GetComponent<ToolLogic>();
    }

    private void Update ()
        {
            bool menuAccessed = toolLogic.getMenuAccessed();
            if (!menuAccessed)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    m_previousX = Input.mousePosition.x;
                    m_previousY = Input.mousePosition.y;
                }
                else if (Input.GetMouseButton(1))
                {
                    var deltaX = (Input.mousePosition.y - m_previousY) * rotationRate;
                    var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
                    targetTransform.Rotate(deltaX, deltaY, 0, Space.World);

                    m_previousX = Input.mousePosition.x;
                    m_previousY = Input.mousePosition.y;
                }
            }
        }
    }
