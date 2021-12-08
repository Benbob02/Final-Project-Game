using System;
using System.Collections.Generic;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService _outputService = new OutputService();
            InputService _inputService = new InputService();

            cast["snake"] = new List<Actor>();
            cast["letter"] = new List<Actor>();
            cast["scoreboard"] = new List<Actor>();
            cast["deathblock"] = new List<Actor>();

            cast["snake"].Add(new Snake());

            cast["scoreboard"].Add(new ScoreBoard());

            for(int i = 0;i<3;i++)
            {
                cast["deathblock"].Add(new Deathblock());
            }

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            //script["output"].Add(new OutputService());
            script["input"].Add(new GetInput());

            script["output"].Add(new DoOutputs());

            _outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Snake Game", Constants.FRAME_RATE);
            
            Director theDirector = new Director(cast,script);
            theDirector.StartGame();

            _outputService.CloseWindow();
            _outputService.OpenWindow(150, 50, "Game Over", Constants.FRAME_RATE);
            _outputService.StartDrawing();
            _outputService.DrawText(25, 25, "Game Over", false);
            _outputService.EndDrawing();
            System.Threading.Thread.Sleep(5000);
        }
    }
}
