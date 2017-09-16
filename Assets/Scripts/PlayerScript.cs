using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 1f;
    public Vector3 direction, lookAt;
    public LayerMask hittable;
    public GameObject lookAtObject;

    [SerializeField]
    private Rigidbody rigid;
    private LineRenderer lineR;

    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        lineR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RigidMove();

        RaycastHit hit;
        Debug.DrawRay(transform.position,direction);
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            direction = hit.point;
            Debug.Log(hit);
        }


        direction.y = 1.5f;
        lookAtObject.transform.position = direction;

        transform.LookAt(lookAtObject.transform, Vector3.up);

        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

        lineR.SetPosition(0, transform.position);

        lineR.SetPosition(1, lookAtObject.transform.position);
    }

    private void RigidMove()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxisRaw("Vertical") * playerSpeed;

        Vector3 zAxisForce = transform.forward * inputZ * playerSpeed;
        Vector3 xAxisForce = transform.right * inputX * playerSpeed;

        rigid.AddForce(zAxisForce);
        rigid.AddForce(xAxisForce);
    }
}
