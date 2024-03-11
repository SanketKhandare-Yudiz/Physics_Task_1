using TMPro;
using Unity.Collections;
using UnityEngine;

public class Jump_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpSpeed = 3f;
    public float forwardForce = 0.1f;
    private float cameraheight = 5f;
    public Ui_Manager uiManager;

  
    void Update()
    {
        if (uiManager.startButtonPressed == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
            {
                if (transform.position.y < cameraheight)
                {
                    Vector2 jumpDirection = Vector2.up + Vector2.right * forwardForce;

                    rb.AddForce(jumpDirection * jumpSpeed, ForceMode2D.Impulse);

                }
            }
        }
    }
}



