using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    class confetti :MonoBehaviour
    {
        public Sprite[] sprites;

        [HideInInspector] public Color color;
        [HideInInspector] public float speed;
        [HideInInspector] public float destroyCoordinate;

        private int frame;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            frame = Random.Range(0, 13);
            transform.Rotate(0, 0, Random.Range(75,105));
            spriteRenderer.sprite = sprites[frame];
            spriteRenderer.color = color;

            StartCoroutine(Move());
            StartCoroutine(Animate());
        }


        private IEnumerator Move()
        {
            var v = transform.position;

            while (transform.position.y > destroyCoordinate)
            {
                //v.y = transform.position.y;
                v.y = v.y - .5f * Time.deltaTime;

                //transform.Translate(v.x, v.y, 0);
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                yield return null;
            }
         
            Destroy(gameObject);
        }

        private IEnumerator Animate()
        {
            var waitTime = new WaitForSeconds(.2f);
            while (true)
            {
                frame++;
                if (frame == sprites.Length) frame = 0;
                spriteRenderer.sprite = sprites[frame];

                yield return waitTime;
            }
        }

    }
}
