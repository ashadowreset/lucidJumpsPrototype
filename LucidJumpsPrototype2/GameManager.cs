using System;

namespace LucidJumpsPrototype2          
{
    public class GameManager
    {
        private static GameManager instance = new GameManager();

        private string levelIndex;
        private Menu menu;
        private Level level;
        private Victory victory;
        private GameOver gameOver;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Input()
        {
            switch (levelIndex)
            {
                case "MenuScreen":
                    menu?.Input();
                    break;
                case "LevelScreen":
                    level?.Input();
                    break;
            }
        }

        public void Draw()
        {
            switch (levelIndex)
            {
                case "MenuScreen":
                    menu?.Draw();
                    break;
                case "LevelScreen":
                    level?.Draw();
                    break;

                case "VictoryScreen":
                    victory?.Draw();
                    break;
                case "GameOverScreen":
                    gameOver?.Draw();
                    break;
            }
        }

        public void Update()
        {
            switch (levelIndex)
            {
                case "MenuScreen":
                    menu?.Update();
                    break;
                case "LevelScreen":
                    level?.Update();
                    break;
                case "VictoryScreen":
                    victory?.Update();
                    break;
                case "GameOverScreen":
                    gameOver?.Update();
                    break;
            }
        }


        public void ChangeLevel(string levelName)
        {
            levelIndex = levelName;
            switch (levelName)
            {
                case "MenuScreen":
                    if (menu == null)
                    {
                        menu = new Menu();
                    }
                    break;
                case "LevelScreen":
                    if (level == null)
                    {
                        level = new Level();
                    }
                    break;

                case "VictoryScreen":
                    if (victory == null)
                    {
                        victory = new Victory();
                    }
                    break;

                case "GameOverScreen":
                    if (gameOver == null)
                    {
                        gameOver = new GameOver();
                    }
                    break;
            }
        }
    }
}

