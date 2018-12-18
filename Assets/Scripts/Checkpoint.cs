using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactivatedRotationSpeed = 100, activatedRotationSpeed = 500 ;
    [SerializeField]
    private float inactivatedScale = 1, activatedScale = 1.5f;
    private bool isActivated;

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateScale()
    {
        float scale = inactivatedScale;

        if (isActivated)
            scale = activatedScale;

        transform.localScale = Vector3.one * scale;
    }

    private void UpdateRotation()
    {
        float rotationspeed = inactivatedRotationSpeed;
        if (isActivated)
            rotationspeed = activatedRotationSpeed;

        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);
    }

    public void SetIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
        }
    }
}
