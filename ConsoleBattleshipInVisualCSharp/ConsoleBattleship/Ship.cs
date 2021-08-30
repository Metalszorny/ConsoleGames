using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBattleship
{
    class Ship
    {
        private Position position;

        private ShipTypes shipType;

        private bool isAlive;

        private Situations situation;

        public enum Situations
        {
            Vertical,
            Horizontal
        }

        public enum ShipTypes
        {
            one,
            two,
            three,
            four,
            five,
            six
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        public ShipTypes ShipType
        {
            get { return shipType; }
            set { shipType = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Situations Situation
        {
            get { return situation; }
            set { situation = value; }
        }

        public Ship()
        { }

        public Ship(Position position, ShipTypes shipType, Situations situation)
        {
            this.position = position;
            this.shipType = shipType;
            this.isAlive = true;
            this.situation = situation;
        }
    }
}
