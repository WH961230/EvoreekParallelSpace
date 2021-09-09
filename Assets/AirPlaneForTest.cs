using UnityEngine;

public class AirPlaneForTest : MonoBehaviour
{
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private bool isRise;
    private bool isGlide;
    private float time;
    public float totalTime;
    public float rise;
    public float glide;
    private Vector3 endVec;
    private Quaternion endQua;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRise = true;
            rig.useGravity = false;
            rig.freezeRotation = true;
            time = totalTime;
        }

        endVec = transform.position;
        endQua = transform.rotation;
        
        if (isRise)
        {
            if (time > 0)
            {
                endVec += transform.up * rise * Time.deltaTime;
                time -= Time.deltaTime;
            } 
            else
            {
                isGlide = true;
                time = 0;
            }
        }

        if (isGlide)
        {
            endVec -= transform.up * glide * Time.deltaTime;
        }

        if (isRise || isGlide)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            endVec += (transform.forward * v + transform.right * h) * Time.deltaTime;

            if (h != 0)
            {
                endQua = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + h, transform.eulerAngles.z);
            }
        }

        rig.MovePosition(endVec);
        rig.MoveRotation(endQua);
    }
}
