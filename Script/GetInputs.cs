using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class GetInput : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word, Snake _snake)
        {
            InputService _inputService = new InputService();

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
    }
}