using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] float speed;
    private float targetFieldOfView;
    private Camera m_camera;

    // Start is called before the first frame update
    private void Start()
    {
        m_camera = this.gameObject.GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            targetFieldOfView -= 5;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFieldOfView += 5;
        }
        

        targetFieldOfView = Mathf.Clamp(targetFieldOfView, 50f, 100f);
        m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, targetFieldOfView, Time.deltaTime * speed);
    }
}
