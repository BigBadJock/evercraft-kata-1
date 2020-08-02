using System;

namespace EverCraft.Core
{
    public struct Ability
    {
        // implicitly convert from integer to new object of type Ability
        public static implicit operator Ability(int value) => new Ability(value);

        public Ability(int value)
        {
            if (value < 1 || value > 20) throw new ArgumentOutOfRangeException();
            this.value = value;
        }

        private int value;

        public int Value
        {
            get { return value; }
            set
            {
                if (value < 1 || value > 20) throw new ArgumentOutOfRangeException();
                this.value = value;
            }

        }


        public int Modifier => (int)(Math.Floor((this.Value - 10) / 2f));

    }
}