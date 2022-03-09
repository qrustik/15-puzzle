using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controllers;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private int Size;
        [SerializeField]
        private string Name;
        [SerializeField]
        private int Id;
        [SerializeField]
        private RectTransform grid;
        [SerializeField]
        private Text text;
        [SerializeField]
        private RectTransform cell;

        public void Start()
        {
            grid = Instantiate(grid, transform);
            var width = grid.sizeDelta.x;
            var height = grid.sizeDelta.y;
            var widthCell = width / Size;
            var heightCell = height / Size;

            cell.sizeDelta = new Vector3(widthCell, heightCell);

            Debug.Log("cell.sizeDelta: " + cell.sizeDelta.ToString());
            Debug.Log("grid.offsetMax: " + grid.offsetMax.ToString());

            var position = new Vector3(grid.offsetMin.x + widthCell / 2, grid.offsetMax.y - heightCell / 2);

            int count = 1;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    cell = Instantiate(cell, grid.transform);
                    cell.localPosition = position;
                    position.x += widthCell;
                    text = cell.GetComponentInChildren<Text>();
                    if (count == Size * Size)
                    {
                        text.text = "";
                        continue;
                    }
                    text.text = count++.ToString();
                }
                position.y -= heightCell;
                position.x = grid.offsetMin.x + widthCell / 2;
            }

            GameController.OnStart(Size, Size, Id, Name);
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index % Size != 0)
                {
                    var leftIndex = index - 1;
                    Debug.Log("leftIndex: " + leftIndex);
                    var cellLeft = grid.GetChild(leftIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellLeft.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    GameController.SwapCells(index, leftIndex);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index < Size * Size - 1)
                {
                    var downIndex = index + Size;
                    Debug.Log("leftIndex: " + downIndex);
                    var cellLeft = grid.GetChild(downIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellLeft.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    GameController.SwapCells(index, downIndex);
                }

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index % Size != Size - 1)
                {
                    var rightIndex = index + 1;
                    Debug.Log("leftIndex: " + rightIndex);
                    var cellLeft = grid.GetChild(rightIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellLeft.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    GameController.SwapCells(index, rightIndex);
                }

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index > Size - 1)
                {
                    var upIndex = index - Size;
                    Debug.Log("leftIndex: " + upIndex);
                    var cellLeft = grid.GetChild(upIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellLeft.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    GameController.SwapCells(index, upIndex);
                }

            }
        }

    }
}
