using UnityEngine;

public class JumpOnTouch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpSpeed = 2f;
    public float forwardForce = 0.05f;
    private float cameraheight = 5.5f;
    public Ui_Manager uiManager;


    void Update()
    {
        if (uiManager.startButtonPressed == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
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
}
