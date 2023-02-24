using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minZoom = 50f;
    [SerializeField] float maxZoom = 100f;
    private float targetFieldOfView;
    private Camera m_camera;
    private ToolLogic toolLogic;

    // Start is called before the first frame update
    private void Start()
    {
        m_camera = this.gameObject.GetComponent<Camera>();
        toolLogic= this.gameObject.GetComponent<ToolLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        bool menuAccessed = toolLogic.getMenuAccessed();

        if (!menuAccessed) {
         
            if (Input.mouseScrollDelta.y > 0)
            {
                targetFieldOfView -= 5;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                targetFieldOfView += 5;
            }


            targetFieldOfView = Mathf.Clamp(targetFieldOfView, minZoom, maxZoom);
            m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, targetFieldOfView, Time.deltaTime * speed);
        }
    }
}
