using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float xMovespeed = 2;
    [SerializeField]
    private float xDelta = 2;
    private float xStartPosition;
    [SerializeField]
    private float yMovespeed = 0.5f;
    private Rigidbody2D rigid2d;
    // Start is called before the first frame update
    private void Awake()
    {
        xStartPosition = transform.position.x;
        rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void MoveToX()
    {
        float x = xStartPosition + xDelta * Mathf.Sin(Time.time * xMovespeed);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    public void MoveToY()
    {
        rigid2d.AddForce(transform.up * yMovespeed, ForceMode2D.Impulse);
    }
}
