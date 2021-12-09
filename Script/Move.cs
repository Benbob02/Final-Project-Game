using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class Move : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word, Snake _snake)
        {
            _snake.Move();
        }
    }
}