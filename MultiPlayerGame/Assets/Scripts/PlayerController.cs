using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool isLocalPlayer;

    Vector3 oldPosition;
    Vector3 currentPosition;

    Quaternion oldRotation;
    Quaternion currentRotation;

    void Start()
    {
        oldPosition = transform.position;
        currentPosition = oldPosition;
        oldRotation = transform.rotation;
        currentRotation = oldRotation;
    }

    void Update()
    {
        if(!isLocalPlayer) return;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime *  150f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        currentPosition = transform.position;
        currentRotation = transform.rotation;

        if(currentPosition != oldPosition) {
            // TODO: Networking Stuff
            oldPosition = currentPosition;
        }

        if(currentRotation != oldRotation) {
            // TODO: Networking Stuff
            oldRotation = currentRotation;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            // TODO: Networking Stuff
            // n.CommandShoot()
            Fire();
        }
    }

    public void Fire() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Bullet b = bullet.GetComponent<Bullet>();
        b.playerFrom = gameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

        Destroy(bullet, 2f);
    }
}
