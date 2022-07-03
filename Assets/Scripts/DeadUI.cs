using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts {
    public class DeadUI : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
