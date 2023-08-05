using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform followTarget = null;
    [SerializeField] PlayerController player = null;
    [SerializeField] Vector3 followVelocity;
    [SerializeField] float followSmoothMaxTime = 0.35f;
    [SerializeField] Camera cam = null;




    void Start()
    {
        // Screen.SetResolution(720 , 1280, true);
        followVelocity = new Vector3(1, 1, 1);
    }


    void LateUpdate()
    {



        if (followTarget != null && player != null)
        {
            var followTargetPosition = new Vector3(followTarget.position.x, followTarget.position.y + 3, transform.position.z);
            // var followSmoothTime = player.turnSpeed > 0 ? player.maxSpeed * followSmoothMaxTime : 0;
            transform.position = Vector3.SmoothDamp(transform.position, followTargetPosition, ref followVelocity, 0.5f);
            //  transform.position = transform.position - player.transform.position ;
        }

        var fovYDeg = cam.fieldOfView;
        var fovXDeg = GetFovXDegFromFovYDeg(fovYDeg, cam.aspect);


    }

    public static float GetFovXDegFromFovYDeg(float fovYDeg, float aspect)
    {
        return 2 * Mathf.Atan(Mathf.Tan(fovYDeg * Mathf.Deg2Rad / 2) * aspect) * Mathf.Rad2Deg;
    }

    public static float GetFovYDegFromFovXDeg(float fovXDeg, float aspect)
    {
        return 2 * Mathf.Atan(Mathf.Tan(fovXDeg * Mathf.Deg2Rad / 2) / aspect) * Mathf.Rad2Deg;
    }
}
