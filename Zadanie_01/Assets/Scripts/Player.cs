using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 8f;
    public float horizontalSpeed = 1f;

    public int collectedCoins = 0;
    public int coinsTotal = 6;


    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator PointTracker()
    {

        if (collectedCoins < coinsTotal)
        {
            Debug.Log(collectedCoins);
            yield return new WaitForSeconds(5.1f);
        }
        else
        {
            Debug.Log("Collected all Coins!");
            yield return new WaitForSeconds(2.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * horizontalSpeed;
        var vertical = Input.GetAxis("Vertical");

        var transform = GetComponent<Transform>();
        if (transform != null)
        {
            var pos = transform.position;

            Vector3 vector = new Vector2(horizontal, vertical) * Time.deltaTime * movementSpeed;
            pos += vector;

            transform.position = pos;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Collectible"))
        {
            GameObject obj = collision.gameObject;
            obj.SetActive(false);
            collectedCoins += 1;
            StartCoroutine(PointTracker());
        }
    }


}
