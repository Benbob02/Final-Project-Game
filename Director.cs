using System;
using System.Collections.Generic;
using Raylib_cs;
namespace Final_Project
{

    public class Director
    {
        private bool _keepPlaying = true;

        OutputService _outputService = new OutputService();
        InputService _inputService = new InputService();
        PhysicsService _physicsService = new PhysicsService();


        public Word _word = new Word();

        Snake _snake = new Snake();
        ScoreBoard _scoreBoard = new ScoreBoard();

        List<Deathblock> _deathblocks = new List<Deathblock>();

        private Dictionary<string, List<Actor>> _cast;
        private Dictionary<string, List<Action>> _script;

        public Director(Dictionary<string, List<Actor>> cast, Dictionary<string, List<Action>> script)
        {
            _cast = cast;
            _script = script;
        }
        public void StartGame()
        {
            PrepareGame();

            while (_keepPlaying)
            {
                CueAction("input");
                CueAction("update");
                CueAction("output");

                if (_inputService.IsWindowClosing())
                {
                    _keepPlaying = false;
                }
            }

            

        }

        private void CueAction(string phase)
        {
            List<Action> actions = _script[phase];

            foreach (Action action in actions)
            {
                action.Execute(_cast);
            }
        }

        private void PrepareGame()
        {   
            _word.NewWord();

            for(int i = 0;i<_word.WordLength();i++)
            {
                _cast["letter"].Add(new Letter(_word.GetLetterIndex(i)));
            }
        }

        private void GetInputs()
        {
            if (_inputService.IsLeftPressed())
            {
                _snake.TurnHead(new Point(-1, 0));
            }
            else if (_inputService.IsRightPressed())
            {
                _snake.TurnHead(new Point(1, 0));
            }
            else if (_inputService.IsUpPressed())
            {
                _snake.TurnHead(new Point(0, -1));
            }
            else if (_inputService.IsDownPressed())
            {
                _snake.TurnHead(new Point(0, 1));
            }
        }

        private void DoUpdates()
        {
            _snake.Move();

            HandleLetterCollision();
            HandleBodyCollision();
        }


    }
}