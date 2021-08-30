using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTron
{
    /// <summary>
    /// Base class for Tron.
    /// </summary>
    class Tron
    {
        #region Fields

        // The position of the Tron.
        private Position position;

        // The color of the Tron.
        private TronColors tronColor;

        // The direction, where the tron is heading.
        private Directions direction;

        // The tron is alive.
        private bool isAlive;

        // The colors of the Tron.
        public enum TronColors
        {
            Red,
            Blue
        }

        // The directions of the Tron.
        public enum Directions
        {
            Left,
            Right,
            Up,
            Down
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Gets or sets the tronColor.
        /// </summary>
        /// <value>
        /// The tronColor.
        /// </value>
        public TronColors TronColor
        {
            get { return tronColor; }
            set { tronColor = value; }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// Gets or sets the isAlive.
        /// </summary>
        /// <value>
        /// The isAlive.
        /// </value>
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Tron"/> class.
        /// </summary>
        public Tron()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tron"/> class.
        /// </summary>
        /// <param name="position">The position of the Tron.</param>
        /// <param name="troncolor">The color of the Tron.</param>
        /// <param name="direction">The direction of the Tron.</param>
        /// <param name="isalive">The tron is alive.</param>
        public Tron(Position position, TronColors troncolor, Directions direction, bool isalive)
        {
            this.Position = position;
            this.TronColor = troncolor;
            this.Direction = direction;
            this.IsAlive = isalive;
        }
		
		/// <summary>
        /// Destroys the instance of the <see cref="Tron"/> class.
        /// </summary>
        ~Tron()
        { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Draws the Tron.
        /// </summary>
        /// <returns>The image of the Tron object.</returns>
        public char Draw()
        {
            try
            {
                char returnValue = ' ';

                switch (this.TronColor)
                {
                    case TronColors.Blue:
                        returnValue = 'x';
                        break;
                    case TronColors.Red:
                        returnValue = '+';
                        break;
                }

                return returnValue;
            }
            catch
            {
                return ' ';
            }
        }

        /// <summary>
        /// Repositions the Tron.
        /// </summary>
        /// <param name="newposition">The new position of the Tron.</param>
        public void Reposition(Position newposition)
        {
            try
            {
                // Sets the position's value to the new position.
                this.position.X = newposition.X;
                this.position.Y = newposition.Y;
            }
            catch
            { }
        }

        #endregion Methods
    }
}
