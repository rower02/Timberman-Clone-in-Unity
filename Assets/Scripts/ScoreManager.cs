using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;
        public int score;
        public Text scoreTxt;
        private void Awake()
        {
            instance = this;
        }

        public void AddPoints(int value)
        {
            score += value;
            scoreTxt.text = "Score: " + score.ToString();
        }
    }
}