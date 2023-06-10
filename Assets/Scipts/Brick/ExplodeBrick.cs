using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBrick : MonoBehaviour
{
    [SerializeField] private Color color;

    private GameObject partical;
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;


            ScoreManager.instance.UpdateScore();

            BrickUI tmp = gameObject.GetComponentInChildren<BrickUI>();
            tmp.UpdateValueText();

            if (tmp._value <= 0)
            {
                Vector2 pos = gameObject.transform.position;
                Brick.instance.Destroy(gameObject, pos);
            }
        }
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;

        }
    }
}
