using System;
using System.Collections.Generic;
using Raylib_cs;
namespace Final_Project
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        private bool _keepPlaying = true;

        OutputService _outputService = new OutputService();
        InputService _inputService = new InputService();

        // TODO: Add this line back in when the Food class
        // is ready
        List<Food> _food = new List<Food>();
        Word _word = new Word();

        Snake _snake = new Snake();
        ScoreBoard _scoreBoard = new ScoreBoard();

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void StartGame()
        {
            PrepareGame();

            while (_keepPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();

                if (_inputService.IsWindowClosing())
                {
                    _keepPlaying = false;
                }
            }

            Console.WriteLine("Game over!");
        }

        /// <summary>
        /// Performs any initial setup for the game.
        /// </summary>
        private void PrepareGame()
        {
            _outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Snake Game", Constants.FRAME_RATE);
            
            _word.NewWord();
            for(int i = 0;i<_word.WordLength();i++)
            {
                _food.Add(new Food(_word.GetLetterIndex(i)));
            }
        }

        /// <summary>
        /// Get any input needed from the user.
        /// </summary>
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

            HandleFoodCollision();
            HandleBodyCollision();
        }


        private void DoOutputs()
        {
            _outputService.StartDrawing();

            _outputService.DrawActor(_scoreBoard);

            foreach(Food i in _food)
            {
                 _outputService.DrawText(i.GetX(),i.GetY(),i.GetLetter(), true);
            }
           
            _outputService.DrawActors(_snake.GetAllSegments());

            _outputService.DrawText(Constants.MAX_X/2,Constants.MAX_Y-30,_word.GetWord(),true);

            _outputService.EndDrawing();
        }

        private void HandleBodyCollision()
        {
            Actor head = _snake.GetHead();

            List<Actor> segments = _snake.GetCollidableSegments();

            foreach(Actor segment in segments)
            {
                if (IsCollision(head, segment))
                {
                    _keepPlaying = false;
                    break;
                }
            }
        }

        private void HandleFoodCollision()
        {
            List<Food> foodremove = new List<Food>();
            bool reset = false;

            Actor head = _snake.GetHead();
            foreach(Food i in _food)
            {
                if (IsCollision(head, i))// && if (i.GetLetter() == _word.CurrentLetter().ToString())
                {
                    if (i.GetLetter() == _word.CurrentLetter().ToString())
                    {
                        foodremove.Add(i);
                        _word.IncrementIndex();
                    }        
                    else
                    {
                        reset = true;
                    }
                }
            }
            if (reset == true)
            {
                _scoreBoard.AddPoints(-1);
                _food.Clear();
                _word.NewWord();
                for(int i = 0;i<_word.WordLength();i++)
                {
                    _food.Add(new Food(_word.GetLetterIndex(i)));
                }
            }
            foreach(Food i in foodremove)
            {
                _food.Remove(i);
            }
            foodremove.Clear();
            if (_food.Count == 0)
            {
                int points = _word.GetPoints();
                _snake.GrowTail(points);
                _scoreBoard.AddPoints(points);
                _word.NewWord();
                for(int i = 0;i<_word.WordLength();i++)
                {
                    _food.Add(new Food(_word.GetLetterIndex(i)));
                }
            }
        }

        /// <summary>
        /// Returns true if the two actors are overlapping.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsCollision(Actor first, Actor second)
        {
            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }


    }
}