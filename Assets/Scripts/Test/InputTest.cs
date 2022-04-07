using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton joybutton;
    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody =  GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f, joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f, 0);

        if (!jump && joybutton.pressed)
        {
            jump = true;
        }


    }
}
