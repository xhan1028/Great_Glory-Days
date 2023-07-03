using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Screen_Data screenData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    private PlayerWeapon playerweapon;
    private PlayerMovement playermovement;

    private void Awake()
    {
        playermovement = GetComponent<PlayerMovement>();
        playerweapon = GetComponent<PlayerWeapon>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        playermovement.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(keyCodeAttack))
        {
            playerweapon.StartFiring();
        }

        if (Input.GetKeyUp(keyCodeAttack))
        {
            playerweapon.StopFiring();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenData.LimitMin.x, screenData.LimitMax.x),Mathf.Clamp(transform.position.y, screenData.LimitMin.y, screenData.LimitMax.y));
    }
}
