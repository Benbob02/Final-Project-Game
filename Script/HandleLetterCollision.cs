using System;
using System.Collections.Generic;

namespace Final_Project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class HandleLetterCollision : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast, Word _word)
        {
            PhysicsService _physicsService = new PhysicsService();



            List<Letter> letterremove = new List<Letter>();
            bool reset = false;
            List<Actor> _letter = cast["letter"];

            Actor head = _snake.GetHead();
            foreach(Letter i in _letter)
            {
                if (_physicsService.IsCollision(head, i))// && if (i.GetLetter() == _word.CurrentLetter().ToString())
                {
                    if (i.GetLetter() == _word.CurrentLetter().ToString())
                    {
                        letterremove.Add(i);
                        _word.IncrementIndex();
                    }        
                    else
                    {
                        reset = true;
                    }
                }
            }
            
            foreach(Deathblock i in _deathblocks)
            {
                if(_physicsService.IsCollision(head,i))
                {
                    _keepPlaying = false;
                }
            }

            if (reset == true)
            {
                _scoreBoard.AddPoints(-1);
                _letter.Clear();
                _word.NewWord();
                

                for(int i = 0;i<_word.WordLength();i++)
                {
                    _letter.Add(new Letter(_word.GetLetterIndex(i)));
                }
            }

            foreach(Letter i in letterremove)
            {
                _letter.Remove(i);
            }

            letterremove.Clear();

            if (_letter.Count == 0)
            {
                int points = _word.GetPoints();
                _snake.GrowTail(points);
                _scoreBoard.AddPoints(points);
                _word.NewWord();

                for(int i = 0;i<_word.WordLength();i++)
                {
                    _letter.Add(new Letter(_word.GetLetterIndex(i)));
                }
            }
        }
    }
}