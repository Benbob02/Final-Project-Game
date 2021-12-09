using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class DoOutputs : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word, Snake _snake)
        {
            OutputService _outputService = new OutputService();
            Actor _scoreBoard = cast["scoreboard"][0];
            List<Actor> _letter = cast["letter"];
            List<Actor> _deathblocks = cast["deathblock"];

            _outputService.StartDrawing();

            //_outputService.DrawActor(_scoreBoard);
            _outputService.DrawText(_scoreBoard.GetX(), _scoreBoard.GetY(), _scoreBoard.GetText(), false);

            foreach(Letter i in _letter)
            {
                 _outputService.DrawText(i.GetX(),i.GetY(),i.GetLetter(), false);
            }
            foreach(Deathblock i in _deathblocks)
            {
                _outputService.DrawBox(i.GetX(),i.GetY(),i.GetWidth(),i.GetHeight(),true);
            }
           
            _outputService.DrawActors(_snake.GetAllSegments());

            _outputService.DrawText(Constants.MAX_X/2,Constants.MAX_Y-30, _word.GetWord(),false);

            _outputService.EndDrawing();
        }
    }
}