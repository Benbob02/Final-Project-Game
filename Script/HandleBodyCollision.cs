using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class HandleBodyCollision : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word, Snake _snake)
        {
            OutputService _outputService = new OutputService();
            PhysicsService _physicsService = new PhysicsService();

            Actor head = _snake.GetHead();

            List<Actor> segments = _snake.GetCollidableSegments();

            foreach(Actor segment in segments)
            {
                if (_physicsService.IsCollision(head, segment))
                {
                    cast["scoreboard"][0].gameover = true;
                    break;
                }
            }
        }
    }
}