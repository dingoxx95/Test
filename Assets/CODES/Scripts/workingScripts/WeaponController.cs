using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    private const float kurtAngle = 90f;

    public Sprite frontSprite, backSprite, leftSideSprite, rightSideSprite;

    private Transform thisTransform = null;
    private Vector2 mouseGlobalPosition, aimDirection = new Vector2();
    private Quaternion rotAngle, maxAngle, minAngle, euler = new Quaternion();
    private new SpriteRenderer renderer = null;

    void Awake() {
        thisTransform = GetComponent<Transform>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (Input.GetKeyDown("i")) renderer.sprite = backSprite;
        if (Input.GetKeyDown("j")) renderer.sprite = leftSideSprite;
        if (Input.GetKeyDown("l")) renderer.sprite = rightSideSprite;
        if (Input.GetKeyDown("k")) renderer.sprite = frontSprite;

        euler = Quaternion.Euler(0f, 0f, 90f);
        mouseGlobalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mouseGlobalPosition - (Vector2)thisTransform.position;
        rotAngle = Quaternion.LookRotation(Vector3.forward, aimDirection.normalized) * euler;
        //KurtAngle = Vector3.Angle(Vector3.forward, aimDirection.normalized);
        maxAngle = rotAngle * Quaternion.Inverse(euler);
        minAngle = Quaternion.Inverse(maxAngle);

        if (Quaternion.Angle(maxAngle, minAngle) > kurtAngle) thisTransform.rotation = rotAngle;
    }

}