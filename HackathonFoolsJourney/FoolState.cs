using System.Collections.Generic;

namespace HackathonFoolsJourney
{
    public class FoolState
    {
        public int MaxVitality { get; private set; } = 25;
        public int Vitality { get; private set; } = 25;

        public List<TarotCard> Satchel { get; private set; } = new();
        public List<TarotCard> Wisdom { get; private set; } = new();

        public TarotCard Strength { get; set; }
        public TarotCard Volition { get; set; }

        public void GainVitality(int amount)
        {
            Vitality += amount;

            if (Vitality > MaxVitality)
                Vitality = MaxVitality;
        }

        public void LoseVitality(int amount)
        {
            Vitality -= amount;

            if (Vitality < 0)
                Vitality = 0;
        }

        public bool IsDead()
        {
            return Vitality <= 0;
        }
    }
}