using System.Collections;
using UnityEngine;

public class TP : MonoBehaviour
{

    [SerializeField] GameObject portal;

    [SerializeField] float tpTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(tpTime);
        GameManager.Instance.player.transform.position = new Vector2(portal.transform.position.x,
            portal.transform.position.y);
    }
}
