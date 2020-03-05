using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        player.SetAxis(Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump"))
            player.Jump();
    }
}
