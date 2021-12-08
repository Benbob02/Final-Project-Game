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

        List<Letter> _letter = new List<Letter>();
        Word _word = new Word();

        Snake _snake = new Snake();
        ScoreBoard _scoreBoard = new ScoreBoard();

        List<Deathblock> _deathblocks = new List<Deathblock>();


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

            _outputService.CloseWindow();
            _outputService.OpenWindow(150, 50, "Game Over", Constants.FRAME_RATE);
            _outputService.StartDrawing();
            _outputService.DrawText(25, 25, "Game Over", false);
            _outputService.EndDrawing();
            System.Threading.Thread.Sleep(5000);

        }


        private void PrepareGame()
        {
            _outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Snake Game", Constants.FRAME_RATE);
            
            _word.NewWord();

            for(int i = 0;i<_word.WordLength();i++)
            {
                _letter.Add(new Letter(_word.GetLetterIndex(i)));
            }
            for(int i = 0;i<3;i++)
            {
                _deathblocks.Add(new Deathblock());
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


        private void DoOutputs()
        {
            _outputService.StartDrawing();

            _outputService.DrawActor(_scoreBoard);

            foreach(Letter i in _letter)
            {
                 _outputService.DrawText(i.GetX(),i.GetY(),i.GetLetter(), false);
            }
            foreach(Deathblock i in _deathblocks)
            {
                _outputService.DrawBox(i.GetX(),i.GetY(),i.GetWidth(),i.GetHeight(),true);
            }
           
            _outputService.DrawActors(_snake.GetAllSegments());

            _outputService.DrawText(Constants.MAX_X/2,Constants.MAX_Y-30,_word.GetWord(),false);

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

        private void HandleLetterCollision()
        {
            List<Letter> letterremove = new List<Letter>();
            bool reset = false;

            Actor head = _snake.GetHead();
            foreach(Letter i in _letter)
            {
                if (IsCollision(head, i))// && if (i.GetLetter() == _word.CurrentLetter().ToString())
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
                if(IsCollision(head,i))
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