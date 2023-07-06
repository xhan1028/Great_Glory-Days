using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    LevelUp = 0, Recovery
}

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private ItemType itemtype;
    private PlayerMovement playermovement;

    private void Awkae()
    {
        playermovement = GetComponent<PlayerMovement>();

        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);

        playermovement.MoveTo(new Vector3(x, y, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            Use(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch (itemtype)
        {
            case ItemType.LevelUp:
                player.GetComponent<PlayerWeapon>().AttackLevel ++;
                break;
            case ItemType.Recovery:
                player.GetComponent<PlayerHp>().CurrentHp += 2;
                break;
        }
    }
}
