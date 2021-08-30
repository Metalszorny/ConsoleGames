using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleBattleship
{
    /// <summary>
    /// Interaction logic for Program.
    /// </summary>
    class Program
    {
        #region Fields

        #region Map

        // The map's height.
        private const int mapHeight = 21;

        // The map's width.
        private const int mapWidth = 43;

        // The map.
        private static char[,] map = new char[mapHeight, mapWidth]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#', ' ', '#', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '+', '-', '#'}, 
            {'#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#', ' ', '#', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '#'}, 
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        // Draw the map in color.
        private static bool coloredMap = true;

        #endregion Map

        #region CharacterFunction

        // The player's score.
        private static int playerScore = 0;

        #endregion CharacterFunction

        #region MapFunction

        // 
        private static int cursorMinimumX = 0;

        // 
        private static int cursorMinimumY = 0;

        // 
        private static int cursorMaximumX = 0;

        // 
        private static int cursorMaximumY = 0;

        // 
        private static List<Ship> shipsToSet = null;

        // 
        private static List<Ship> playerShips = null;

        // 
        private static List<Ship> enemyShips = null;

        // 
        private static bool IsShipSettingOn = true;

        // 
        private static Position cursorPosition = new Position(1, 1);

        // 
        private Position playerMapStart = new Position(0, 0);

        // 
        private Position enemyMapStart = new Position(0, 22);

        // Indicates that the game is in session or not.
        private static bool gameFinished = false;

        // The game needs to preset some values.
        private static bool gamePreset = true;

        // The status of the game.
        private static GameStages gameStatus = GameStages.Menu;

        // Refresh the display.
        public static bool refreshDisplay = false;

        // The random.
        private static Random rnd = new Random();

        // The number of the options.
        private const int optionsNumber = 2;

        // The curzor for the options.
        private static int optionsPointer = 1;

        // Object generate limit to prevent infinate loops.
        private const int tryLimit = 20;

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
                        cursorMinimumX = 0;
                        cursorMinimumY = 0;
                        cursorMaximumX = ((mapWidth / 2) - 1);
                        cursorMaximumY = mapHeight;

                        #region PreSet

                        // Pre-set values.
                        if (gamePreset)
                        {
                            cursorPosition = new Position(1, 1);
                            shipsToSet = GenerateShipsToSet();
                            playerShips = new List<Ship>();
                            enemyShips = new List<Ship>();
                        }

                        #endregion PreSet

                        #region RefreshDisplay

                        DisplayMap();
                        ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);

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
                                    case ConsoleKey.UpArrow:
                                        if (cursorPosition.X - 2 >= cursorMinimumY)
                                        {
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Black, map[cursorPosition.X, cursorPosition.Y]);
                                            cursorPosition.X -= 2;
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                                        }
                                        break;
                                    case ConsoleKey.A:
                                    case ConsoleKey.LeftArrow:
                                        if (cursorPosition.Y - 2 >= cursorMinimumX)
                                        {
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Black, map[cursorPosition.X, cursorPosition.Y]);
                                            cursorPosition.Y -= 2;
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                                        }
                                        break;
                                    case ConsoleKey.D:
                                    case ConsoleKey.RightArrow:
                                        if (cursorPosition.Y + 2 < cursorMaximumX)
                                        {
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Black, map[cursorPosition.X, cursorPosition.Y]);
                                            cursorPosition.Y += 2;
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                                        }
                                        break;
                                    case ConsoleKey.S:
                                    case ConsoleKey.DownArrow:
                                        if (cursorPosition.X + 2 < cursorMaximumY)
                                        {
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Black, map[cursorPosition.X, cursorPosition.Y]);
                                            cursorPosition.X += 2;
                                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                                        }
                                        break;
                                    case ConsoleKey.Enter:
                                        if (IsShipSettingOn)
                                        {
                                            SetShip();
                                        }
                                        else
                                        {
                                            BombShip();
                                        }
                                        break;
                                    case ConsoleKey.Spacebar:
                                        if (IsShipSettingOn)
                                        {
                                            RotateShip();
                                        }
                                        break;
                                    case ConsoleKey.Escape:
                                        gameStatus = GameStages.Menu;
                                        gamePreset = true;
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

                            }

                            #endregion HandleChanges

                            Thread.Sleep(sleepTime);

                            #region GameRefresh

                            // The display needs to be refreshed.
                            if (refreshDisplay)
                            {
                                #region Text

                                #region Score

                                // Display the player's score.
                                if (playerScore / 10000 > 0)
                                {
                                    Console.SetCursorPosition(8, 20);
                                }
                                else if (playerScore / 1000 > 0)
                                {
                                    Console.SetCursorPosition(8, 20);
                                    Console.Write("0");
                                    Console.SetCursorPosition(9, 20);
                                }
                                else if (playerScore / 100 > 0)
                                {
                                    Console.SetCursorPosition(8, 20);
                                    Console.Write("00");
                                    Console.SetCursorPosition(10, 20);
                                }
                                else if (playerScore / 10 > 0)
                                {
                                    Console.SetCursorPosition(8, 20);
                                    Console.Write("000");
                                    Console.SetCursorPosition(11, 20);
                                }
                                else
                                {
                                    Console.SetCursorPosition(8, 20);
                                    Console.Write("0000");
                                    Console.SetCursorPosition(12, 20);
                                }

                                Console.Write(playerScore);
                                Console.SetCursorPosition(0, 21);

                                #endregion Score

                                #endregion Text

                                refreshDisplay = false;
                            }

                            #endregion GameRefresh
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
        /// 
        /// </summary>
        private static List<Ship> GenerateShipsToSet()
        {
            try
            {
                List<Ship> returnValue = new List<Ship>();
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.one, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.one, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.one, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.one, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.two, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.two, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.two, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.three, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.three, Ship.Situations.Horizontal));
                returnValue.Add(new Ship(new Position(0, 0), Ship.ShipTypes.four, Ship.Situations.Horizontal));

                return returnValue;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SetShip()
        {
            try
            {
                if (IsShipSettingOn)
                {
                    if (ValidateShipPosition(cursorPosition, shipsToSet[0].Situation, shipsToSet[0].ShipType))
                    {
                        map[cursorPosition.X, cursorPosition.Y] = 'O';
                        RefreshChar(cursorPosition, 'O');
                        int iterator = 0;

                        switch (shipsToSet[0].ShipType)
                        {
                            case Ship.ShipTypes.two:
                                iterator = 1;
                                switch (shipsToSet[0].Situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X + ((i + 1) * 2), cursorPosition.Y] = 'O';
                                            RefreshChar(new Position(cursorPosition.X + ((i + 1) * 2), cursorPosition.Y), 'O');
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)] = 'O';
                                            RefreshChar(new Position(cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)), 'O');
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.three:
                                iterator = 2;
                                switch (shipsToSet[0].Situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X + ((i + 1) * 2), cursorPosition.Y] = 'O';
                                            RefreshChar(new Position(cursorPosition.X + ((i + 1) * 2), cursorPosition.Y), 'O');
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)] = 'O';
                                            RefreshChar(new Position(cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)), 'O');
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.four:
                                iterator = 3;
                                switch (shipsToSet[0].Situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X + ((i + 1) * 2), cursorPosition.Y] = 'O';
                                            RefreshChar(new Position(cursorPosition.X + ((i + 1) * 2), cursorPosition.Y), 'O');
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)] = 'O';
                                            RefreshChar(new Position(cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)), 'O');
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.five:
                                iterator = 4;
                                switch (shipsToSet[0].Situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X + ((i + 1) * 2), cursorPosition.Y] = 'O';
                                            RefreshChar(new Position(cursorPosition.X + ((i + 1) * 2), cursorPosition.Y), 'O');
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)] = 'O';
                                            RefreshChar(new Position(cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)), 'O');
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.six:
                                iterator = 5;
                                switch (shipsToSet[0].Situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X + ((i + 1) * 2), cursorPosition.Y] = 'O';
                                            RefreshChar(new Position(cursorPosition.X + ((i + 1) * 2), cursorPosition.Y), 'O');
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            map[cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)] = 'O';
                                            RefreshChar(new Position(cursorPosition.X, cursorPosition.Y + ((i + 1) * 2)), 'O');
                                        }
                                        break;
                                }
                                break;
                        }

                        ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                        Ship newShip = shipsToSet[0];
                        newShip.Position = cursorPosition;
                        playerShips.Add(newShip);
                        shipsToSet.RemoveAt(0);

                        if (shipsToSet.Count == 0)
                        {
                            IsShipSettingOn = false;
                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Black, map[cursorPosition.X, cursorPosition.Y]);
                            cursorPosition = new Position(1, 23);
                            ChangeBackgroundColor(cursorPosition, ConsoleColor.Gray, map[cursorPosition.X, cursorPosition.Y]);
                            cursorMinimumX = ((mapWidth / 2) + 1);
                            cursorMaximumX = mapWidth;
                        }
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RotateShip()
        {
            try
            {
                if (IsShipSettingOn)
                {
                    switch (shipsToSet[0].Situation)
                    {
                        case Ship.Situations.Horizontal:
                            shipsToSet[0].Situation = Ship.Situations.Vertical;
                            break;
                        case Ship.Situations.Vertical:
                            shipsToSet[0].Situation = Ship.Situations.Horizontal;
                            break;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BombShip()
        {
            try
            {
                if (!IsShipSettingOn)
                {
                    
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="situation"></param>
        /// <param name="shipType"></param>
        /// <returns></returns>
        private static bool ValidateShipPosition(Position startPosition, Ship.Situations situation, Ship.ShipTypes shipType)
        {
            try
            {
                bool returnValue = false;

                if (IsShipSettingOn)
                {
                    if (map[startPosition.X, startPosition.Y] == ' ')
                    {
                        int iterator = 0;
                        bool valid = true;

                        switch (shipType)
                        {
                            case Ship.ShipTypes.one:
                                returnValue = true;
                                break;
                            case Ship.ShipTypes.two:
                                iterator = 1;

                                switch (situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X + ((i + 1) * 2), startPosition.Y] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X, startPosition.Y + ((i + 1) * 2)] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.three:
                                iterator = 2;

                                switch (situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X + ((i + 1) * 2), startPosition.Y] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X, startPosition.Y + ((i + 1) * 2)] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.four:
                                iterator = 3;

                                switch (situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X + ((i + 1) * 2), startPosition.Y] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X, startPosition.Y + ((i + 1) * 2)] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.five:
                                iterator = 4;

                                switch (situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X + ((i + 1) * 2), startPosition.Y] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X, startPosition.Y + ((i + 1) * 2)] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                }
                                break;
                            case Ship.ShipTypes.six:
                                iterator = 5;

                                switch (situation)
                                {
                                    case Ship.Situations.Vertical:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X + ((i + 1) * 2), startPosition.Y] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                    case Ship.Situations.Horizontal:
                                        for (int i = 0; i < iterator; i++)
                                        {
                                            if (map[startPosition.X, startPosition.Y + ((i + 1) * 2)] != ' ')
                                            {
                                                valid = false;

                                                break;
                                            }
                                        }

                                        if (valid)
                                        {
                                            returnValue = true;
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }

                return returnValue;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="character"></param>
        private static void ChangeBackgroundColor(Position position, ConsoleColor color, char character)
        {
            Position previousPosition = new Position(Console.CursorTop, Console.CursorLeft);
            Console.SetCursorPosition(position.Y, position.X);
            Console.BackgroundColor = color;
            RefreshChar(position, character);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(previousPosition.Y, previousPosition.X);
        }

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
                        case '+':
                        case '-':
                        case '|':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '@':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '*':
                        case 'X':
                            Console.ForegroundColor = ConsoleColor.White;
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

                Console.SetCursorPosition(0, 22);
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
                                case '+':
                                case '-':
                                case '|':
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case 'O':
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case '@':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case '*':
                                case 'X':
                                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("Score: {0:00000}, Exit: Press Esc.", playerScore);
            }
            catch
            { }
        }

        #endregion Functions

        #endregion Methods
    }
}
