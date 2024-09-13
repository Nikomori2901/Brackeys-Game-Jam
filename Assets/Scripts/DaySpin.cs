using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class DaySpin : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    bool rotated = false;
    float r;

    [Button]
    public void StartSpinning()
    {
        StopAllCoroutines();

        if (!rotated)
        {
            StartCoroutine(Spin(180f));
            rotated = true;
        }

        else
        {
            StartCoroutine(Spin(0f));
            rotated = false;
        }
    }

    private IEnumerator Spin(float targetRotation)
    {
        while (transform.rotation.z != targetRotation)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref r, spinSpeed);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return new WaitForEndOfFrame();
        }
    }
}
