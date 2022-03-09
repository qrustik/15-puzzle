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
            SpawnGrid();
            

        }

        public void Update()
        {
            InputController();


        }

        private void SpawnGrid()
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
                    var newCell = Instantiate(cell, grid.transform);
                    newCell.localPosition = position;
                    position.x += widthCell;
                    text = newCell.GetComponentInChildren<Text>();
                    if (count == Size * Size)
                    {
                        text.text = "";
                        newCell.gameObject.SetActive(false);
                        continue;
                    }
                    text.text = count++.ToString();
                }
                position.y -= heightCell;
                position.x = grid.offsetMin.x + widthCell / 2;
            }

            GameController.OnStart(Size, Size, Id, Name);
        }

        private void InputController()
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index > Size - 1)
                {
                    var upIndex = index - Size;
                    Debug.Log("leftIndex: " + upIndex);
                    var cellUp = grid.GetChild(upIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellUp.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    cell.gameObject.SetActive(true);
                    cellUp.gameObject.SetActive(false);

                    GameController.SwapCells(index, upIndex);
                }

            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index % Size != Size - 1)
                {
                    var rightIndex = index + 1;
                    Debug.Log("leftIndex: " + rightIndex);
                    var cellRight = grid.GetChild(rightIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellRight.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    cell.gameObject.SetActive(true);
                    cellRight.gameObject.SetActive(false);

                    GameController.SwapCells(index, rightIndex);
                }

            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                var index = GameController.GetIndexOfEmptyCell();
                var cell = grid.GetChild(index);
                Debug.Log("Index: " + index);
                if (index < Size * (Size - 1))
                {
                    var downIndex = index + Size;
                    Debug.Log("leftIndex: " + downIndex);
                    var cellDown = grid.GetChild(downIndex);

                    var text1 = cell.GetComponentInChildren<Text>();
                    var text2 = cellDown.GetComponentInChildren<Text>();
                    var tmp = text1.text;
                    text1.text = text2.text;
                    text2.text = tmp;

                    cell.gameObject.SetActive(true);
                    cellDown.gameObject.SetActive(false);

                    GameController.SwapCells(index, downIndex);
                }

            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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

                    cell.gameObject.SetActive(true);
                    cellLeft.gameObject.SetActive(false);

                    GameController.SwapCells(index, leftIndex);
                }
            }





        }


        private bool IsCorrectGrid()
        {
            var check = false;

            for(int i = 0; i < Size; i++)
            {

            }


            return check;
        }

        private void Mixing()
        {

        }

    }
}
