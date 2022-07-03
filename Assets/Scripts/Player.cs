using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        public bool isTouchingStick;
        public static Player main;
        public GameObject deadUI;

        private void Awake()
        {
            main = this;
        }

        private void Start()
        {
            deadUI.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!isTouchingStick)
                {
                    TreeManager.instance.CutTree();
                    transform.position = new Vector2(-2, -3);
                    ScoreManager.instance.AddPoints(1);
                    TreeManager.instance.timeSlider.value += 2;
                    TreeManager.instance.amount += ScoreManager.instance.score / 100;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!isTouchingStick)
                {
                    TreeManager.instance.CutTree();
                    transform.position = new Vector2(2, -3);
                    ScoreManager.instance.AddPoints(1);
                    TreeManager.instance.timeSlider.value += 2;
                    TreeManager.instance.amount += ScoreManager.instance.score / 100;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Stick")
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            isTouchingStick = true;
            TreeManager.instance.timeSlider.gameObject.SetActive(false);
            deadUI.SetActive(true);
        }
    }
}
