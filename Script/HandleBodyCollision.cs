using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class HandleBodyCollision : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word)
        {
            Actor head = _snake.GetHead();
            PhysicsService _physicsService = new PhysicsService();


            List<Actor> segments = _snake.GetCollidableSegments();

            foreach(Actor segment in segments)
            {
                if (_physicsService.IsCollision(head, segment))
                {
                    _keepPlaying = false;
                    break;
                }
            }
        }
        }
    }
}