using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Ray ray;
    RaycastHit hit;
    public Camera cam;
    public Vector3 up;
    public bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC") && shot == false)
                {
                    shot = true;
                    up = new Vector3(transform.position.x, 10f, transform.position.z);
                    StartCoroutine(noBlasting());
                }
            }
        }
    }
    IEnumerator noBlasting()
    {
        hit.rigidbody.AddForce(up, ForceMode.Impulse);
        yield return new WaitForSeconds(1.5f);
        shot = false;
    }
}
