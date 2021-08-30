using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTron
{
	/// <summary>
    /// The interaction logic for the program.
    /// </summary>
    class Program
    {
        #region Fields

        #region Map

        // The map's width.
        private const int mapWidth = 79;

        // The map's height.
        private const int mapHeight = 23;

        // The map.
        private static char[,] map = new char[mapHeight, mapWidth]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        // Draw the map in color.
        private static bool coloredMap = true;

        #endregion Map

        #region Character

        // The snake.
        private static List<Tron> trons = new List<Tron>();

        #endregion Character

        #region MapFunction

        // Indicates that the game is in session or not.
        private static bool gameFinished = false;

        // The status of the game.
        private static GameStages gameStatus = GameStages.Menu;

        // The number of the options.
        private const int optionsNumber = 2;

        // The curzor for the options.
        private static int optionsPointer = 1;

        // The refresh rate of the game.
        private static int sleepTime = 50;

        // The difficulty of the game.
        private static GameDifficulties gameDifficulty = GameDifficulties.Normal;

        // The difficulties of the game.
        private enum GameDifficulties
        {
            Easy,
            Normal,
            Hard
        }

        // The enum of game stages.
        private enum GameStages
        {
            Menu,
            Highsores,
            Game,
            Options,
            Exit
        }

        #endregion MapFunction

        #endregion Fields

        #region Methods

        /// <summary>
        /// The main method of the Program.
        /// </summary>
        /// <param name="args">The input arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                while (!gameFinished)
                {
                    #region Menu

                    // The menu stage.
                    if (gameStatus == GameStages.Menu)
                    {
                        #region RefreshDisplay

                        DisplayMenu();

                        #endregion RefreshDisplay

                        // Repeat the key read until a valid key is pushed.
                        while (gameStatus == GameStages.Menu)
                        {
                            #region HandleInput

                            // A key was pushed.
                            if (Console.KeyAvailable)
                            {
                                // Handle the key input.
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        gameStatus = GameStages.Game;
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        gameStatus = GameStages.Options;
                                        break;
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
                                        gameStatus = GameStages.Exit;
                                        break;
                                }

                                // Delete the read key input.
                                DeleteKeyInput();
                            }

                            #endregion HandleInput
                        }
                    }

                    #endregion Menu

                    #region Game

                    // The game stage.
                    else if (gameStatus == GameStages.Game)
                    {
                        #region PreSet

                        // Refresh the tron.
                        trons.Clear();
                        trons.Add(new Tron(new Position(11, 14), Tron.TronColors.Red, Tron.Directions.Right, true));
                        trons.Add(new Tron(new Position(11, 63), Tron.TronColors.Blue, Tron.Directions.Left, true));

                        // Clears the map and repositions the trons.
                        for (int i = 1; i < mapHeight - 1; i++)
                        {
                            for (int j = 1; j < mapWidth - 1; j++)
                            {
                                map[i, j] = ' ';
                            }
                        }
                        
                        // Put the trons on the map.
                        map[trons[0].Position.X, trons[0].Position.Y] = trons[0].Draw();
                        map[trons[1].Position.X, trons[1].Position.Y] = trons[1].Draw();

                        // Set the game difficulty.
                        switch (gameDifficulty)
                        {
                            case GameDifficulties.Easy:
                                sleepTime = 65;
                                break;
                            case GameDifficulties.Normal:
                                sleepTime = 50;
                                break;
                            case GameDifficulties.Hard:
                                sleepTime = 40;
                                break;
                        }

                        #endregion PreSet

                        #region RefreshDisplay

                        DisplayMap();

                        #endregion RefreshDisplay

                        // Repeat while the game is active.
                        while (gameStatus == GameStages.Game)
                        {
                            #region HandleInput

                            // A key was pushed.
                            if (Console.KeyAvailable)
                            {
                                // Handle the key input.
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.W:
                                        if (trons[0].Direction != Tron.Directions.Down)
                                        {
                                            trons[0].Direction = Tron.Directions.Up;
                                        }
                                        break;
                                    case ConsoleKey.UpArrow:
                                        if (trons[1].Direction != Tron.Directions.Down)
                                        {
                                            trons[1].Direction = Tron.Directions.Up;
                                        }
                                        break;
                                    case ConsoleKey.A:
                                        if (trons[0].Direction != Tron.Directions.Right)
                                        {
                                            trons[0].Direction = Tron.Directions.Left;
                                        }
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        if (trons[1].Direction != Tron.Directions.Right)
                                        {
                                            trons[1].Direction = Tron.Directions.Left;
                                        }
                                        break;
                                    case ConsoleKey.D:
                                        if (trons[0].Direction != Tron.Directions.Left)
                                        {
                                            trons[0].Direction = Tron.Directions.Right;
                                        }
                                        break;
                                    case ConsoleKey.RightArrow:
                                        if (trons[1].Direction != Tron.Directions.Left)
                                        {
                                            trons[1].Direction = Tron.Directions.Right;
                                        }
                                        break;
                                    case ConsoleKey.S:
                                        if (trons[0].Direction != Tron.Directions.Up)
                                        {
                                            trons[0].Direction = Tron.Directions.Down;
                                        }
                                        break;
                                    case ConsoleKey.DownArrow:
                                        if (trons[1].Direction != Tron.Directions.Up)
                                        {
                                            trons[1].Direction = Tron.Directions.Down;
                                        }
                                        break;
                                    case ConsoleKey.Escape:
                                        gameStatus = GameStages.Menu;
                                        break;
                                }

                                // Delete the read key input.
                                DeleteKeyInput();
                            }

                            #endregion HandleInput

                            #region HandleChanges

                            // Only handle the changes in the game stage.
                            if (gameStatus == GameStages.Game)
                            {
                                #region MoveTrons

                                // The trons move.
                                MoveTrons();

                                #endregion MoveTrons

                                #region CollisionDetection

                                if (trons[0].IsAlive == false && trons[1].IsAlive == false)
                                {
                                    Console.Write("Draw.");
                                    Thread.Sleep(2000);
                                }
                                else if (trons[0].IsAlive == true && trons[1].IsAlive == false)
                                {
                                    Console.Write("Red player wins.");
                                    Thread.Sleep(2000);
                                }
                                else if (trons[0].IsAlive == false && trons[1].IsAlive == true)
                                {
                                    Console.Write("Blue player wins.");
                                    Thread.Sleep(2000);
                                }

                                #endregion CollisionDetection
                            }

                            #endregion HandleChanges

                            Thread.Sleep(sleepTime);
                        }
                    }

                    #endregion Game

                    #region Options

                    // The options stage.
                    else if (gameStatus == GameStages.Options)
                    {
                        #region RefreshDisplay

                        DisplayOptions();
                        optionsPointer = 1;

                        #endregion RefreshDisplay

                        // Repeat the key read until the escape is pushed.
                        while (gameStatus == GameStages.Options)
                        {
                            #region HandleInput

                            // A key was pushed.
                            if (Console.KeyAvailable)
                            {
                                // Handle the key input.
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Escape:
                                        gameStatus = GameStages.Menu;
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        switch (optionsPointer)
                                        {
                                            case 1:
                                                if (coloredMap)
                                                {
                                                    coloredMap = false;
                                                    ChangeText(new Position(2, 7), "Off");
                                                }
                                                else
                                                {
                                                    coloredMap = true;
                                                    ChangeText(new Position(2, 7), "On ");
                                                }
                                                break;
                                            case 2:
                                                if (gameDifficulty == GameDifficulties.Hard)
                                                {
                                                    gameDifficulty = GameDifficulties.Normal;
                                                    ChangeText(new Position(4, 12), "Normal");
                                                }
                                                else if (gameDifficulty == GameDifficulties.Normal)
                                                {
                                                    gameDifficulty = GameDifficulties.Easy;
                                                    ChangeText(new Position(4, 12), " Easy ");
                                                }
                                                break;
                                        }
                                        break;
                                    case ConsoleKey.RightArrow:
                                        switch (optionsPointer)
                                        {
                                            case 1:
                                                if (coloredMap)
                                                {
                                                    coloredMap = false;
                                                    ChangeText(new Position(2, 7), "Off");
                                                }
                                                else
                                                {
                                                    coloredMap = true;
                                                    ChangeText(new Position(2, 7), "On ");
                                                }
                                                break;
                                            case 2:
                                                if (gameDifficulty == GameDifficulties.Easy)
                                                {
                                                    gameDifficulty = GameDifficulties.Normal;
                                                    ChangeText(new Position(4, 12), "Normal");
                                                }
                                                else if (gameDifficulty == GameDifficulties.Normal)
                                                {
                                                    gameDifficulty = GameDifficulties.Hard;
                                                    ChangeText(new Position(4, 12), " Hard ");
                                                }
                                                break;
                                        }
                                        break;
                                    case ConsoleKey.UpArrow:
                                        if (optionsPointer > 1)
                                        {
                                            optionsPointer--;
                                            ChangeOption(optionsPointer, optionsPointer + 1);
                                        }
                                        else
                                        {
                                            optionsPointer = optionsNumber;
                                            ChangeOption(optionsNumber, 1);
                                        }
                                        break;
                                    case ConsoleKey.DownArrow:
                                        if (optionsPointer < optionsNumber)
                                        {
                                            optionsPointer++;
                                            ChangeOption(optionsPointer, optionsPointer - 1);
                                        }
                                        else
                                        {
                                            optionsPointer = 1;
                                            ChangeOption(1, optionsNumber);
                                        }
                                        break;
                                }

                                // Delete the read key input.
                                DeleteKeyInput();
                            }

                            #endregion HandleInput
                        }
                    }

                    #endregion Options

                    #region Exit

                    // The exit stage.
                    else if (gameStatus == GameStages.Exit)
                    {
                        // End the program.
                        gameFinished = true;
                    }

                    #endregion Exit
                }
            }
            catch
            { }
        }

        #region Functions

        /// <summary>
        /// Changes the selected option.
        /// </summary>
        /// <param name="currentpointer">The current selection.</param>
        /// <param name="previouspointer">The previous selection.</param>
        private static void ChangeOption(int currentpointer, int previouspointer)
        {
            try
            {
                // Don't reposition with the same position.
                if (currentpointer != previouspointer)
                {
                    // Make the current selection have the curzor.
                    switch (currentpointer)
                    {
                        case 1:
                            Console.SetCursorPosition(7, 2);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (coloredMap)
                            {
                                Console.Write("On ");
                            }
                            else
                            {
                                Console.Write("Off");
                            }
                            break;
                        case 2:
                            Console.SetCursorPosition(12, 4);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            switch (gameDifficulty)
                            {
                                case GameDifficulties.Easy:
                                    Console.Write(" Easy ");
                                    break;
                                case GameDifficulties.Normal:
                                    Console.Write("Normal");
                                    break;
                                case GameDifficulties.Hard:
                                    Console.Write(" Hard ");
                                    break;
                            }
                            break;
                    }

                    // Make the previous selection the default color.
                    switch (previouspointer)
                    {
                        case 1:
                            Console.SetCursorPosition(7, 2);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            if (coloredMap)
                            {
                                Console.Write("On ");
                            }
                            else
                            {
                                Console.Write("Off");
                            }
                            break;
                        case 2:
                            Console.SetCursorPosition(12, 4);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            switch (gameDifficulty)
                            {
                                case GameDifficulties.Easy:
                                    Console.Write(" Easy ");
                                    break;
                                case GameDifficulties.Normal:
                                    Console.Write("Normal");
                                    break;
                                case GameDifficulties.Hard:
                                    Console.Write(" Hard ");
                                    break;
                            }
                            break;
                    }

                    Console.SetCursorPosition(1, 9);
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Changes the text at the given position.
        /// </summary>
        /// <param name="position">The position to write.</param>
        /// <param name="text">The test to write.</param>
        private static void ChangeText(Position position, string text)
        {
            try
            {
                Console.SetCursorPosition(position.Y, position.X);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(text);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(1, 9);
            }
            catch
            { }
        }

        /// <summary>
        /// Validates the next step of the snake.
        /// </summary>
        /// <param name="newposition">The new position.</param>
        /// <param name="troncolor">The tron's color.</param>
        private static void ValidateNextStep(Position newposition, Tron.TronColors troncolor)
        {
            try
            {
                switch (map[newposition.X, newposition.Y])
                {
                    case ' ':
                        foreach (Tron oneTron in trons)
                        {
                            if (oneTron.TronColor == troncolor)
                            {
                                // Draw the tron on the map and the display.
                                oneTron.Position = newposition;
                                RefreshChar(oneTron.Position, oneTron.Draw());
                                map[oneTron.Position.X, oneTron.Position.Y] = oneTron.Draw();
                            }
                        }
                        break;
                    case 'x':
                    case '+':
                    case '#':
                        foreach (Tron oneTron in trons)
                        {
                            if (oneTron.TronColor == troncolor)
                            {
                                // Sets the tron's alive status to false.
                                oneTron.IsAlive = false;
                            }
                        }
                        gameStatus = GameStages.Menu;
                        break;
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Moves the trons.
        /// </summary>
        private static void MoveTrons()
        {
            try
            {
                foreach (Tron oneTron in trons)
                {
                    switch (oneTron.Direction)
                    {
                        case Tron.Directions.Left:
                            // The snake is at tunnel.
                            if (oneTron.Position.Y - 1 < 0)
                            {
                                ValidateNextStep(new Position(oneTron.Position.X, mapWidth - 1), oneTron.TronColor);
                            }
                            // Move left.
                            else
                            {
                                ValidateNextStep(new Position(oneTron.Position.X, oneTron.Position.Y - 1), oneTron.TronColor);
                            }
                            break;
                        case Tron.Directions.Right:
                            // The snake is at tunnel.
                            if (oneTron.Position.Y + 1 > mapWidth - 1)
                            {
                                ValidateNextStep(new Position(oneTron.Position.X, 0), oneTron.TronColor);
                            }
                            // Move right.
                            else
                            {
                                ValidateNextStep(new Position(oneTron.Position.X, oneTron.Position.Y + 1), oneTron.TronColor);
                            }
                            break;
                        case Tron.Directions.Up:
                            // The snake is at tunnel.
                            if (oneTron.Position.X - 1 < 0)
                            {
                                ValidateNextStep(new Position(mapHeight - 1, oneTron.Position.Y), oneTron.TronColor);
                            }
                            // Move up.
                            else
                            {
                                ValidateNextStep(new Position(oneTron.Position.X - 1, oneTron.Position.Y), oneTron.TronColor);
                            }
                            break;
                        case Tron.Directions.Down:
                            // The snake is at tunnel.
                            if (oneTron.Position.X + 1 > mapHeight - 1)
                            {
                                ValidateNextStep(new Position(0, oneTron.Position.Y), oneTron.TronColor);
                            }
                            // Move up.
                            else
                            {
                                ValidateNextStep(new Position(oneTron.Position.X + 1, oneTron.Position.Y), oneTron.TronColor);
                            }
                            break;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Displays the menu.
        /// </summary>
        private static void DisplayMenu()
        {
            try
            {
                // Clear the console.
                Console.Clear();

                // Display the menu.
                Console.WriteLine("Press the number of the option.");
                Console.WriteLine();
                Console.WriteLine("1. Start Game");
                Console.WriteLine();
                Console.WriteLine("2. Options");
                Console.WriteLine();
                Console.WriteLine("3. Exit");
                Console.WriteLine();
            }
            catch
            { }
        }

        /// <summary>
        /// Overwrites the given position with the given character.
        /// </summary>
        /// <param name="position">The position to write to.</param>
        /// <param name="character">The character to write.</param>
        private static void RefreshChar(Position position, char character)
        {
            try
            {
                Console.SetCursorPosition(position.Y, position.X);

                // Display the ghost in color.
                if (coloredMap)
                {
                    // Handles the characters.
                    switch (character)
                    {
                        case '#':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case 'x':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case '+':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ' ':
                            break;
                    }

                    Console.Write(character);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                // Display the ghost in black and white.
                else
                {
                    Console.Write(character);
                }

                Console.SetCursorPosition(0, 24);
            }
            catch
            { }
        }

        /// <summary>
        /// Deletes the read key input.
        /// </summary>
        private static void DeleteKeyInput()
        {
            try
            {
                Console.CursorLeft -= 1;
                Console.Write(" ");
                Console.CursorLeft -= 1;
            }
            catch
            { }
        }

        /// <summary>
        /// Displays the options.
        /// </summary>
        private static void DisplayOptions()
        {
            try
            {
                // Clear the console.
                Console.Clear();

                // Display the menu.
                Console.WriteLine("Options");
                Console.WriteLine();
                Console.Write("Color: ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
				
                if (coloredMap)
                {
                    Console.Write("On ");
                }
                else
                {
                    Console.Write("Off");
                }
				
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Difficulty: ");
				
                switch (gameDifficulty)
                {
                    case GameDifficulties.Easy:
                        Console.Write(" Easy ");
                        break;
                    case GameDifficulties.Normal:
                        Console.Write("Normal");
                        break;
                    case GameDifficulties.Hard:
                        Console.Write(" Hard ");
                        break;
                }
				
                Console.WriteLine();
                Console.WriteLine();

                // Display the return message.
                Console.WriteLine();
                Console.WriteLine("Press Up or Down to select an option and Left or Right to change it.");
                Console.WriteLine("Press Esc to return to menu.");
            }
            catch
            { }
        }

        /// <summary>
        /// Displays the map.
        /// </summary>
        private static void DisplayMap()
        {
            try
            {
                // Clear the console.
                Console.Clear();

                // The rows of the map.
                for (int i = 0; i < mapHeight; i++)
                {
                    // The columns of the map.
                    for (int j = 0; j < mapWidth; j++)
                    {
                        // Show colored map.
                        if (coloredMap)
                        {
                            // Set the color based on the map item.
                            switch (map[i, j])
                            {
                                case '#':
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case 'x':
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case '+':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case ' ':
                                    break;
                            }

                            // Show the item and reset the color.
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        // Show black and white map.
                        else
                        {
                            Console.Write(map[i, j]);
                        }
                    }

                    // Brake the line.
                    Console.WriteLine();
                }

                // Show the information line.
                Console.WriteLine("Red: W, A, S, D, Blue: Up, Left, Down, Right, Exit: Press Esc.");
            }
            catch
            { }
        }

        #endregion Functions

        #endregion Methods
    }
}
