using System;

namespace Lab05
{
    internal class Plus
    {
        private Func<float, float, float> fabricPlus;

        public Plus(Func<double, double, float> fabricPlus)
        {
        }

        public Plus(Func<float, float, float> fabricPlus)
        {
            this.fabricPlus = fabricPlus;
        }
    }
}