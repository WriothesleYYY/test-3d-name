using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinText;

    public float speed = 10;

    private int _count;
    private Rigidbody _PlayerRigidbody;
    private float _horizontalInput;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerRigidbody = GetComponent<Rigidbody>();
        _count = 0;
        CountText.text = "count:  " + _count.ToString();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);
        _PlayerRigidbody.AddForce(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            CountText.text = "count: " + _count.ToString();


            if(_count >= 8)
            {
                WinText.gameObject.SetActive(true);
            }
        }
    }


}
