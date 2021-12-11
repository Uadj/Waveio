using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement;
    [SerializeField]
    private StageContoller stageController;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (stageController.IsGameOver)
        {
            return;
        }
        movement.MoveToX();
        StartCoroutine("move2");
        
    }
    private IEnumerator move2()
    {
        if (Input.GetMouseButton(0))
        {
            movement.MoveToY();
        }
        yield return new WaitForSeconds(0.02f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Item"))
        {
            stageController.IncreaseScore(1);
            Destroy(collision.gameObject);

        }
        else if (collision.tag.Equals("Obstacle"))
        {
            Destroy(GetComponent<Rigidbody2D>());
            stageController.GameOver();
        }
    }

}
