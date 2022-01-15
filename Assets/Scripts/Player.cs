using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Collider2D objectCollider;
    public Collider2D anotherCollider;
    private BoxCollider2D boxCollider;
    private Vector3 move;
    private RaycastHit2D hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        move = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        move = new Vector3(x, y, 0);
        if (move.x > 0)
            transform.localScale = new Vector3(3, 3, 1);
        else if (move.x < 0)
            transform.localScale = new Vector3(-3, 3, 1);
        if (move.y > 0)
            transform.localScale = new Vector3(3, 3, 1);
        else if (move.y < 0)
            transform.localScale = new Vector3(3, 3, 1);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, move.y), Mathf.Abs(move.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, move.y * Time.deltaTime, 0);

        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(move.x, 0), Mathf.Abs(move.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(move.x * Time.deltaTime, 0, 0);

        }
        if (transform.position.x<2.0 && transform.position.x > 1.60 && transform.position.y <- 1.50 && transform.position.y>-1.70)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Challenge");
            Debug.Log("ok");
        }
    
}
}
