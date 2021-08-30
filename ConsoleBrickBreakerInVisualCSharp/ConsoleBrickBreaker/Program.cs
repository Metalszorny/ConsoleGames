using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleBrickBreaker
{
    /// <summary>
    /// Interaction logic for Program.
    /// </summary>
    class Program
    {
        #region Fields

        // The width of the map.
        private const int mapWidth = 29;

        // The height of the map.
        private const int mapHeight = 23;

        // The life count of the player.
        private static int playerLife = 3;

        // The score point of the player.
        private static int playerScore = 0;

        // The x position of the ball.
        private static int ballPositionX = 14;

        // The y position of the ball.
        private static int ballPositionY = 21;

        // The time limit for the ball timer.
        private const int ballMoveTime = 7500;

        // The timer to move the ball.
        private static int ballMoveTimer = 0;

        // The ball's next position.
        private static int brickToLook = 0;

        // The horizontal movement of the ball.
        private static int ballHorizontalMovement = -1;

        // The vertical movement of the ball.
        private static int ballVerticalMovement = 1;

        // The racket's going left.
        private static bool goingLeft = false;

        // The racket's going right.
        private static bool goingRight = false;

        // The game is paused.
        private static bool isGamePaused = false;

        // The ball is in wait.
        private static bool isBallInWait = true;

        // The game is over.
        private static bool isGameOver = false;

        // The x position of the racket.
        private static int racketPositionX = 11;

        // The y position of the racket.
        private const int racketPositionY = mapHeight - 1;

        // The width of the racket.
        private static int racketWidth = 6;

        // The number of the bricks.
        private static int brickCount = 0;

        // The map.
        private static char[,] map =
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', 'x', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 'x', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'o', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'}
        };

        #endregion Fields

        #region Methods

        /// <summary>
        /// The main method of the Program.
        /// </summary>
        /// <param name="args">The console input arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                // Show the map.
                DisplayMap();

                //
                while (!isGameOver)
                {
                    #region HandleInput

                    // A key was pushed.
                    if (Console.KeyAvailable)
                    {
                        // Handle the key input.
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                if (!goingLeft)
                                {
                                    goingLeft = true;
                                }
                                if (goingRight)
                                {
                                    goingRight = false;
                                }
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                if (!goingRight)
                                {
                                    goingRight = true;
                                }
                                if (goingLeft)
                                {
                                    goingLeft = false;
                                }
                                break;
                            case ConsoleKey.W:
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.Spacebar:
                                isBallInWait = false;
                                break;
                            case ConsoleKey.P:
                                if (isGamePaused)
                                {
                                    isGamePaused = false;
                                }
                                else
                                {
                                    isGamePaused = true;
                                }
                                break;
                            case ConsoleKey.Escape:
                                isGameOver = true;
                                break;
                        }

                        // Delete the read key input.
                        DeleteKeyInput();
                    }
                    else
                    {
                        if (goingLeft)
                        {
                            goingLeft = false;
                        }

                        if (goingRight)
                        {
                            goingRight = false;
                        }
                    }

                    #endregion HandleInput

                    // The game is not paused.
                    if (!isGamePaused)
                    {
                        #region HandleChanges

                        if (goingLeft)
                        {
                            MoveRacket(-1);
                        }
                        else if (goingRight)
                        {
                            MoveRacket(1);
                        }

                        // The ball is in move.
                        if (!isBallInWait)
                        {
                            // 
                            if (ballMoveTimer == ballMoveTime)
                            {
                                ballMoveTimer = 0;

                                // Move the ball.
                                MoveBall(ballHorizontalMovement, ballVerticalMovement);

                                // Ball collision.
                                BallCollision();
                            }
                            else
                            {
                                ballMoveTimer++;
                            }
                        }

                        #endregion HandleChanges
                    }
                }
            }
            catch
            { }
        }

        #region Functions

        /// <summary>
        /// The ball's collision detection with the game objects.
        /// </summary>
        private static void BallCollision()
        {
            try
            {
                #region BallAndWallContact

                // Ball and wall contact.
                if (ballPositionX <= 1 || ballPositionX >= mapWidth - 2 || ballPositionY <= 1 || ballPositionY >= mapHeight - 1)
                {
                    // The ball is at the side walls.
                    if (ballPositionX <= 1 || ballPositionX >= mapWidth - 2)
                    {
                        // Vertical direction change.
                        ballVerticalMovement *= -1;
                    }
                    // The ball is at the top wall.
                    else if (ballPositionY <= 1)
                    {
                        // Horizontal direction change.
                        ballHorizontalMovement *= -1;
                    }
                    // The ball is at the bottom.
                    else if (ballPositionY >= mapHeight - 1)
                    {
                        // Decrement the player's life points.
                        playerLife--;
                        WriteCharacterToConsole(23, 6, playerLife.ToString());

                        // Reposition the ball and racket.
                        WriteCharacterToConsole(ballPositionY, ballPositionX, " ");
                        ballPositionX = (mapWidth - 1) / 2;
                        ballPositionY = mapHeight - 2;
                        WriteCharacterToConsole(ballPositionY, ballPositionX, "o");
                        for (int i = 0; i < racketWidth + 1; i++)
                        {
                            WriteCharacterToConsole(racketPositionY, racketPositionX + i, " ");
                        }
                        racketPositionX = (mapWidth - 1) / 2 - racketWidth / 2;
                        for (int i = 0; i < racketWidth + 1; i++)
                        {
                            WriteCharacterToConsole(racketPositionY, racketPositionX + i, "-");
                        }
                        isBallInWait = true;
                        ballHorizontalMovement = - 1;
                        ballVerticalMovement = 1;

                        // The life points reached 0.
                        if (playerLife <= 0)
                        {
                            // End the game.
                            isGameOver = true;
                        }
                    }
                    // The ball is at the corners of the walls.
                    else
                    {
                        // Vertical direction change.
                        ballVerticalMovement *= -1;
                        // Horizontal direction change.
                        ballHorizontalMovement *= -1;
                    }
                }

                #endregion BallAndWallContact

                #region BallAndRacketContact

                // Ball and racket contact.
                else if (ballPositionX >= racketPositionX && ballPositionX <= racketPositionX + racketWidth && ballPositionY == racketPositionY - 1)
                {
                    // Horizontal direction change.
                    ballHorizontalMovement *= -1;
                }

                #endregion BallAndRacketContact

                #region BallAndBrickContact

                // Ball and brick contact.
                else if (map[ballPositionY - 1, ballPositionX - 1] == '*' || map[ballPositionY - 1, ballPositionX - 1] == 'x' ||
                        map[ballPositionY - 1, ballPositionX] == '*' || map[ballPositionY - 1, ballPositionX] == 'x' ||
                        map[ballPositionY - 1, ballPositionX + 1] == '*' || map[ballPositionY - 1, ballPositionX + 1] == 'x' ||
                        map[ballPositionY, ballPositionX - 1] == '*' || map[ballPositionY, ballPositionX - 1] == 'x' ||
                        map[ballPositionY, ballPositionX + 1] == '*' || map[ballPositionY, ballPositionX + 1] == 'x' ||
                        map[ballPositionY + 1, ballPositionX - 1] == '*' || map[ballPositionX + 1, ballPositionX - 1] == 'x' ||
                        map[ballPositionY + 1, ballPositionX] == '*' || map[ballPositionY + 1, ballPositionX] == 'x' ||
                        map[ballPositionY + 1, ballPositionX + 1] == '*' || map[ballPositionY + 1, ballPositionX + 1] == 'x')
                {
                    // Search for the ball's next position.
                    if (ballPositionX - 1 == ballPositionX + ballVerticalMovement && ballPositionY - 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 1;
                    }
                    else if (ballPositionX == ballPositionX + ballVerticalMovement && ballPositionY - 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 2;
                    }
                    else if (ballPositionX + 1 == ballPositionX + ballVerticalMovement && ballPositionY - 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 3;
                    }
                    else if (ballPositionX - 1 == ballPositionX + ballVerticalMovement && ballPositionY == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 4;
                    }
                    else if (ballPositionX + 1 == ballPositionX + ballVerticalMovement && ballPositionY == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 6;
                    }
                    else if (ballPositionX - 1 == ballPositionX + ballVerticalMovement && ballPositionY + 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 7;
                    }
                    else if (ballPositionX == ballPositionX + ballVerticalMovement && ballPositionY + 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 8;
                    }
                    else if (ballPositionX + 1 == ballPositionX + ballVerticalMovement && ballPositionY + 1 == ballPositionY + ballHorizontalMovement)
                    {
                        brickToLook = 9;
                    }

                    // The ball's next position is left-up or right-up or left-down or right-down.
                    if (brickToLook == 1 || brickToLook == 3 || brickToLook == 7 || brickToLook == 9)
                    {
                        #region LeftUp

                        // Left-up.
                        if (brickToLook == 1)
                        {
                            // Up.
                            if ((map[ballPositionY - 1, ballPositionX] == '*' || map[ballPositionY - 1, ballPositionX] == 'x') &&
                                map[ballPositionY, ballPositionX - 1] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY - 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY - 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY - 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                            // Left.
                            else if ((map[ballPositionY, ballPositionX - 1] == '*' || map[ballPositionY, ballPositionX - 1] == 'x') &&
                                map[ballPositionY - 1, ballPositionX] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX - 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX - 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX - 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Up and left.
                            else if ((map[ballPositionY - 1, ballPositionX] == '*' || map[ballPositionY - 1, ballPositionX] == 'x') &&
                                (map[ballPositionY, ballPositionX - 1] == '*' || map[ballPositionY, ballPositionX - 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY - 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY - 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY - 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX - 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX - 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX - 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Left-up.
                            else if (map[ballPositionY - 1, ballPositionX] == ' ' && map[ballPositionY, ballPositionX - 1] == ' ' && 
                                (map[ballPositionY - 1, ballPositionX - 1] == '*' || map[ballPositionY - 1, ballPositionX - 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                    WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                        }

                        #endregion LeftUp

                        #region RightUp

                        // Right-up.
                        else if (brickToLook == 3)
                        {
                            // Up.
                            if ((map[ballPositionY - 1, ballPositionX] == '*' || map[ballPositionY - 1, ballPositionX] == 'x') &&
                                map[ballPositionY, ballPositionX + 1] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY - 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY - 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY - 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                            // Right.
                            else if ((map[ballPositionY, ballPositionX + 1] == '*' || map[ballPositionY, ballPositionX + 1] == 'x') &&
                                map[ballPositionY - 1, ballPositionX] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX + 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX + 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX + 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Up and right.
                            else if ((map[ballPositionY - 1, ballPositionX] == '*' || map[ballPositionY - 1, ballPositionX] == 'x') &&
                                (map[ballPositionY, ballPositionX + 1] == '*' || map[ballPositionY, ballPositionX + 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY - 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY - 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY - 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX + 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX + 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX + 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Right-up.
                            else if (map[ballPositionY - 1, ballPositionX] == ' ' && map[ballPositionY, ballPositionX + 1] == ' ' &&
                                (map[ballPositionY - 1, ballPositionX + 1] == '*' || map[ballPositionY - 1, ballPositionX + 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                    WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                        }

                        #endregion RightUp

                        #region LeftDown

                        // Left-down.
                        else if (brickToLook == 7)
                        {
                            // Down.
                            if ((map[ballPositionY + 1, ballPositionX] == '*' || map[ballPositionY + 1, ballPositionX] == 'x') &&
                                map[ballPositionY, ballPositionX - 1] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY + 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                            // Left.
                            else if ((map[ballPositionY, ballPositionX - 1] == '*' || map[ballPositionY, ballPositionX - 1] == 'x') &&
                                map[ballPositionY + 1, ballPositionX] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX - 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX - 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX - 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Down and left.
                            else if ((map[ballPositionY + 1, ballPositionX] == '*' || map[ballPositionY + 1, ballPositionX] == 'x') &&
                                (map[ballPositionY, ballPositionX - 1] == '*' || map[ballPositionY, ballPositionX - 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY + 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX - 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX - 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX - 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Left-down.
                            else if (map[ballPositionY + 1, ballPositionX] == ' ' && map[ballPositionY, ballPositionX - 1] == ' ' &&
                                (map[ballPositionY + 1, ballPositionX - 1] == '*' || map[ballPositionY + 1, ballPositionX - 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                    WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                        }

                        #endregion LeftDown

                        #region RightDown

                        // Right-down.
                        else if (brickToLook == 9)
                        {
                            // Down.
                            if ((map[ballPositionY + 1, ballPositionX] == '*' || map[ballPositionY + 1, ballPositionX] == 'x') &&
                                map[ballPositionY, ballPositionX + 1] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY + 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                            // Right.
                            else if ((map[ballPositionY, ballPositionX + 1] == '*' || map[ballPositionY, ballPositionX + 1] == 'x') &&
                                map[ballPositionY + 1, ballPositionX] == ' ')
                            {
                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX + 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX + 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX + 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Down and right.
                            else if ((map[ballPositionY + 1, ballPositionX] == '*' || map[ballPositionY + 1, ballPositionX] == 'x') &&
                                (map[ballPositionY, ballPositionX + 1] == '*' || map[ballPositionY, ballPositionX + 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + 1, ballPositionX] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + 1, ballPositionX] = ' ';
                                    WriteCharacterToConsole(ballPositionY + 1, ballPositionX, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // The brick is breakable.
                                if (map[ballPositionY, ballPositionX + 1] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY, ballPositionX + 1] = ' ';
                                    WriteCharacterToConsole(ballPositionY, ballPositionX + 1, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                            }
                            // Right-down.
                            else if (map[ballPositionY + 1, ballPositionX] == ' ' && map[ballPositionY, ballPositionX + 1] == ' ' &&
                                (map[ballPositionY + 1, ballPositionX + 1] == '*' || map[ballPositionY + 1, ballPositionX + 1] == 'x'))
                            {
                                // The brick is breakable.
                                if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                                {
                                    // Remove brick.
                                    map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                    WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                    brickCount--;

                                    // Add score.
                                    playerScore += 1;
                                    DisplayScore(playerScore);
                                }

                                // Vertical direction change.
                                ballVerticalMovement *= -1;
                                // Horizontal direction change.
                                ballHorizontalMovement *= -1;
                            }
                        }

                        #endregion RightDown
                    }
                    // The ball's next position is left or right or up or down.
                    else if (brickToLook == 2 || brickToLook == 4 || brickToLook == 6 || brickToLook == 8)
                    {
                        #region UpOrDown

                        // Check up or down.
                        if (brickToLook == 2 || brickToLook == 8)
                        {
                            // The brick is breakable.
                            if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                            {
                                // Remove brick.
                                map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                brickCount--;

                                // Add score.
                                playerScore += 1;
                                DisplayScore(playerScore);
                            }

                            // Horizontal direction change.
                            ballHorizontalMovement *= -1;
                        }

                        #endregion UpOrDown

                        #region LeftOrRight

                        // Check left or right.
                        else if (brickToLook == 4 || brickToLook == 6)
                        {
                            // The brick is breakable.
                            if (map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] == '*')
                            {
                                // Remove brick.
                                map[ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement] = ' ';
                                WriteCharacterToConsole(ballPositionY + ballHorizontalMovement, ballPositionX + ballVerticalMovement, " ");
                                brickCount--;

                                // Add score.
                                playerScore += 1;
                                DisplayScore(playerScore);
                            }

                            // Vertical direction change.
                            ballVerticalMovement *= -1;
                        }

                        #endregion LeftOrRight
                    }

                    brickToLook = 0;

                    // The bricks are all gone.
                    if (brickCount <= 0)
                    {
                        // End the game.
                        isGameOver = true;
                    }
                }

                #endregion BallAndBrickContact
            }
            catch
            { }
        }

        /// <summary>
        /// Displays the map to the console.
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
                        // The cell of the map.
                        Console.Write(map[i, j]);

                        // Count the breakable bricks.
                        if (map[i, j] == '*')
                        {
                            brickCount++;
                        }
                    }

                    // Break the line.
                    Console.WriteLine();
                }

                // The information line.
                Console.WriteLine("Life: " + playerLife + ", Score: 000, Exit: Press Esc.");
            }
            catch
            { }
        }

        /// <summary>
        /// Moves the racket on the console.
        /// </summary>
        /// <param name="movement">The movement of the racket.</param>
        private static void MoveRacket(int movement)
        {
            try
            {
                // The game is not paused.
                if (!isGamePaused)
                {
                    #region MoveLeft

                    // Move left.
                    if (movement < 0)
                    {
                        // The racket is at the left wall.
                        if (racketPositionX <= 1)
                        {
                            racketPositionX = 1;
                        }
                        // The racket can move.
                        else
                        {
                            map[racketPositionY, racketPositionX + racketWidth] = ' ';
                            WriteCharacterToConsole(racketPositionY, racketPositionX + racketWidth, " ");

                            racketPositionX += movement;

                            map[racketPositionY, racketPositionX] = '-';
                            WriteCharacterToConsole(racketPositionY, racketPositionX, "-");

                            // The ball is on the racket.
                            if (isBallInWait)
                            {
                                // Move the ball with the same amount.
                                MoveBall(0, movement);
                            }
                        }
                    }

                    #endregion MoveLeft

                    #region MoveRight

                    // Move right.
                    else if (movement > 0)
                    {
                        // The racket is at the right wall.
                        if (racketPositionX + racketWidth >= mapWidth - 2)
                        {
                            racketPositionX = mapWidth - 2 - racketWidth;
                        }
                        // The racket can move.
                        else
                        {
                            map[racketPositionY, racketPositionX] = ' ';
                            WriteCharacterToConsole(racketPositionY, racketPositionX, " ");

                            racketPositionX += movement;

                            map[racketPositionY, racketPositionX + racketWidth] = '-';
                            WriteCharacterToConsole(racketPositionY, racketPositionX + racketWidth, "-");

                            // The ball is on the racket.
                            if (isBallInWait)
                            {
                                // Move the ball with the same amount.
                                MoveBall(0, movement);
                            }
                        }
                    }

                    #endregion MoveRight
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Moves the ball.
        /// </summary>
        /// <param name="horizontalMovement">The horizontal movement of the ball.</param>
        /// <param name="verticalMovement">The vertical movement of the ball.</param>
        private static void MoveBall(int horizontalMovement, int verticalMovement)
        {
            try
            {
                map[ballPositionY, ballPositionX] = ' ';
                WriteCharacterToConsole(ballPositionY, ballPositionX, " ");

                // Move the ball.
                ballPositionX += verticalMovement;
                ballPositionY += horizontalMovement;

                map[ballPositionY, ballPositionX] = 'o';
                WriteCharacterToConsole(ballPositionY, ballPositionX, "o");
            }
            catch
            { }
        }

        /// <summary>
        /// Display the score.
        /// </summary>
        /// <param name="score">The player's score.</param>
        private static void DisplayScore(int score)
        {
            try
            {
                if (playerScore / 100 > 1)
                {
                    WriteCharacterToConsole(23, 16, playerScore.ToString());
                }
                else if (playerScore / 10 > 1)
                {
                    WriteCharacterToConsole(23, 17, playerScore.ToString());
                }
                else
                {
                    WriteCharacterToConsole(23, 18, playerScore.ToString());
                }
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
                Console.CursorLeft = 0;
                Console.Write(" ");
                Console.CursorLeft -= 1;
            }
            catch
            { }
        }

        /// <summary>
        /// Writes a character to the console display.
        /// </summary>
        /// <param name="positionX">The x position.</param>
        /// <param name="positionY">The y position.</param>
        /// <param name="charToDisplay">The character.</param>
        private static void WriteCharacterToConsole(int positionX, int positionY, string charToDisplay)
        {
            try
            {
                Console.SetCursorPosition(positionY, positionX);
                Console.Write(charToDisplay.ToString());
                Console.SetCursorPosition(0, 24);
            }
            catch
            { }
        }

        #endregion Functions

        #endregion Methods
    }
}
