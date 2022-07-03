using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class TreeManager : MonoBehaviour
    {
        public List<GameObject> treePart = new List<GameObject>();
        public GameObject wood;
        public GameObject stick;
        public float woodOffset;
        public Vector2 lastWoodPos;
        public Vector2 startWoodPos;

        public Slider timeSlider;

        public static TreeManager instance;

        public float amount;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            CreateStartTree();
        }

        private void Update()
        {
            if(timeSlider.value == 0)
            {
                Player.main.EndGame();
            }
            timeSlider.value -= amount * Time.deltaTime;
        }

        void CreateStartTree()
        {
            lastWoodPos = startWoodPos;
            for(int i = 0; i < 5; i++)
            {
                CreateTree();
            }
        }

        void CreateTree()
        {
            GameObject _Wood = Instantiate(wood, new Vector2(0, lastWoodPos.y + woodOffset), Quaternion.identity);
            _Wood.AddComponent<Wood>();
            _Wood.name = "Wood";
            treePart.Add(_Wood);
            lastWoodPos = _Wood.transform.position;
            treePart[0].GetComponent<Wood>().hasStick = true;

            if (Random.Range(0, 6) <= 2 && !_Wood.GetComponent<Wood>().hasStick)
            {
                GameObject _Stick = Instantiate(stick, new Vector2(-1.5f, lastWoodPos.y + 0.3f), Quaternion.identity, _Wood.transform);
                _Wood.GetComponent<Wood>().hasStick = true;
            }

            if (Random.Range(0, 6) >= 4 && !_Wood.GetComponent<Wood>().hasStick)
            {
                GameObject _Stick = Instantiate(stick, new Vector2(1.5f, lastWoodPos.y + 0.3f), Quaternion.identity, _Wood.transform);
                _Wood.GetComponent<Wood>().hasStick = true;
            }
        }

        public void CutTree()
        {
            lastWoodPos.y = lastWoodPos.y - woodOffset;
            for(int i = 0; i < treePart.Count; i++)
            {
                treePart[i].transform.position = new Vector2(0, treePart[i].transform.position.y - woodOffset);
            }
            Destroy(treePart[0]);
            treePart.RemoveAt(0);
            CreateTree();
        }
    }
}
