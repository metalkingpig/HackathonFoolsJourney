namespace HackathonFoolsJourney.GameRules
{
    public struct Player(int health = 20)
    {
        public int Health = health;
        public int Strength;
        public int Wisdom;
    }
}
