using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public bool isInPosition = true;
    public Vector3 wantedRot;

    IEnumerator ChangeRotation(Vector3 wantedRot)
    {
        Debug.Log("ChangeRotation");
        while (!isInPosition)
        {
            Debug.Log("inLoop");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(wantedRot), 0.2f);
            if (transform.rotation.eulerAngles.y - wantedRot.y % 360 < 0.01f)
                isInPosition = true;
            yield return new WaitForEndOfFrame();
        }
        
    }
	void Update () {
        if (isInPosition)
        {
             wantedRot = transform.rotation.eulerAngles;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isInPosition = false;
                wantedRot.y += 90;
                StartCoroutine(ChangeRotation(wantedRot));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isInPosition = false;
                wantedRot.y -= 90;
                StartCoroutine(ChangeRotation(wantedRot));
            }
        }
	}
}
