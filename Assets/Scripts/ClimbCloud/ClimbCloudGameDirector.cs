using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbCloudGameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;
    public float velocityX;

    public float GetVelocityX()
    {
        return this.velocityX;
    }

    public void UpdateVelocityText(Vector2 velocity)
    {
        this.velocityX = Mathf.Abs(velocity.x);

        this.velocityText.text = $"{velocityX:0.0}";
    }
}
