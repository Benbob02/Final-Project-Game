using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Final_Project
{

    public class OutputService
    {
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.BLACK;

        public OutputService()
        {

        }


        public void OpenWindow(int width, int height, string title, int frameRate)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }


        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public void StartDrawing()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);


            // The following two lines are to show the nice chalkboard background, 
            // but it does slow down the computer if you do
            
            //Raylib_cs.Texture2D texture= Raylib.LoadTexture(Constants.background);
            //Raylib.DrawTexture(texture, 1, 1, Color.WHITE);
            
        }

        
        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        
        public void DrawBox(int x, int y, int width, int height, bool death = false)
        {
            if(!death)
            {
                Raylib.DrawRectangle(x, y, width, height, Raylib_cs.Color.YELLOW);            
            }
            else
            {
                Raylib.DrawRectangle(x, y, width, height, Raylib_cs.Color.RED);
            }
        }

        
        public void DrawText(int x, int y, string text, bool darkText)
        {
            Raylib_cs.Color color = Raylib_cs.Color.WHITE;

            if (darkText)
            {
                color = Raylib_cs.Color.BLACK;
            }

            Raylib.DrawText(text,
                x + Constants.DEFAULT_TEXT_OFFSET,
                y + Constants.DEFAULT_TEXT_OFFSET,
                Constants.DEFAULT_FONT_SIZE,
                color);
        }

        public void DrawActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();
            int width = actor.GetWidth();
            int height = actor.GetHeight();

            bool darkText = true;

            if (actor.HasBox())
            {
                DrawBox(x, y, width, height);
                darkText = false;
            }

            if (actor.HasText())
            {
                string text = actor.GetText();
                DrawText(x, y, text, darkText);
            }
        }

       
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

    }

}