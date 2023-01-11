using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{


    public class Main : MonoBehaviour
    {

        private InputController _inputController;

        private ListExecuteObjectController _interactiveObject;

        
        //private ListExecuteObjectController _executeObject;
        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;

        private int _bonusCount;


        [SerializeField] private Unit _player;

        [SerializeField] private Bonus[] BonusObj;

        [SerializeField] private BadBonus badBonus;
        [SerializeField] private Button _restartButton;


        IEnumerator interactivEnum;


        private void Awake()
        {
            _reference = new Reference();

            _inputController = new InputController(_player.GetComponent<Unit>());
          

            _interactiveObject = new ListExecuteObjectController(BonusObj); // Создаём экземпляр объекта

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);

            interactivEnum = _interactiveObject.GetEnumerator();
            

            foreach (var item in _interactiveObject)
            {
                if(item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddBonus;
                }
                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayer += _viewEndGame.GameOver;
                    badBonus.OnCaughtPlayer += CaughtPlayer;
                }
            }

            //badBonus.OnCaughtPlayer += GameOver;
        }
        private void CaughtPlayer(string value, Color args)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewBonus.Display(_bonusCount);
        }

        //public void GameOver(string name, Color color)
        //{
        //    Debug.Log(name + " color:" + color);
        //}


        void Update()
        {
            //if (_interactiveObject.MoveNext())
            //{
            //    IExecute temp = (IExecute)_interactiveObject.Current;
            //    temp.Update();
            //}
            //else
            //{
            //    _interactiveObject.Reset();
            //    Debug.Log("Reset");
            //}

            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }
                _interactiveObject[i].Update();
            }



        }
    }
}
