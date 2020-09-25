using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    /// <summary>
    /// Written　Saito Takahiro
    /// </summary>
    [SerializeField]Vector3 ToRotation;
    [SerializeField] private float rotateSpeed = 1;
    private bool Unlocked = false;
    GameObject key;
    private void Start()
    {
        //ToRotation = Quaternion.Euler(transform.parent.gameObject.transform.localRotation.x, 90, transform.parent.gameObject.transform.localRotation.z);
    }
    void Update()
    {
        if (Unlocked)
        {
            if (key != null)
            {
                key.transform.localPosition = Vector3.zero;
            }
            transform.parent.gameObject.transform.localRotation = Quaternion.Slerp(transform.parent.gameObject.transform.localRotation, Quaternion.Euler(ToRotation), rotateSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            key = other.gameObject;
            StartCoroutine("DoorOpenCoroutine");
        }
    }

    public IEnumerator DoorOpenCoroutine()
    {
        key.transform.parent = transform;
        key.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Unlocked = true;
        yield return new WaitForSecondsRealtime(2);
        Destroy(key);

    }


}
