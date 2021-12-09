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

        public Word _word = new Word();
        Snake _snake = new Snake();
        

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
                

                if (_inputService.IsWindowClosing() || _cast["scoreboard"][0].gameover == true)
                {
                    _keepPlaying = false;
                }
                else
                {
                    CueAction("output");
                }
            }

            

        }

        private void CueAction(string phase)
        {
            List<Action> actions = _script[phase];

            foreach (Action action in actions)
            {
                action.Execute(_cast, _word, _snake);
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


    }
}