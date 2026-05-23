using System.Collections.Generic;

namespace HackathonFoolsJourney
{
    public class FoolState
    {
        public int MaxVitality { get; private set; } = 25;
        public int Vitality { get; private set; } = 25;

        public List<TarotCard> Satchel { get; private set; } = new();
        public List<TarotCard> Wisdom { get; private set; } = new();   // max 3 Coins

        public TarotCard Strength { get; set; }      // one Baton
        public TarotCard Volition { get; set; }      // one Sword

        public void Reset()
        {
            Vitality = MaxVitality;
            Satchel.Clear();
            Wisdom.Clear();
            Strength = null;
            Volition = null;
        }

        public void GainVitality(int amount)
        {
            Vitality = System.Math.Min(MaxVitality, Vitality + amount);
        }

        public void LoseVitality(int amount)
        {
            Vitality = System.Math.Max(0, Vitality - amount);
        }

        public bool IsDead() => Vitality <= 0;
    }
}