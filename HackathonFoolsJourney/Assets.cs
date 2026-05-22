using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackathonFoolsJourney
{
    public class Assets
    {
        public readonly Texture2D WhitePixel;

        public readonly Texture2D CardBackside;
        public readonly Texture2D CardJudgement;
        public readonly Texture2D CardWorld;
        public readonly Texture2D CardChariot;
        public readonly Texture2D CardDeath;
        public readonly Texture2D CardDevil;
        public readonly Texture2D CardEmperor;
        public readonly Texture2D CardEmpress;
        public readonly Texture2D CardFool;
        public readonly Texture2D CardFortune;
        public readonly Texture2D CardHangedMan;
        public readonly Texture2D CardHermit;
        public readonly Texture2D CardHierophant;
        public readonly Texture2D CardJustice;
        public readonly Texture2D CardLovers;
        public readonly Texture2D CardMagician;
        public readonly Texture2D CardMoon;
        public readonly Texture2D CardPriestess;
        public readonly Texture2D CardStar;
        public readonly Texture2D CardStrength;
        public readonly Texture2D CardSun;
        public readonly Texture2D CardTemperance;
        public readonly Texture2D CardTower;

        public readonly Texture2D[] Cards;

        public readonly int CardWidth;
        public readonly int CardHeight;

        public Assets(Game game)
        {
            WhitePixel = game.Content.Load<Texture2D>("WhitePixel");

            // Cards
            CardBackside = game.Content.Load<Texture2D>("Cards/Back");
            CardJudgement = game.Content.Load<Texture2D>("Cards/Judgement");
            CardWorld = game.Content.Load<Texture2D>("Cards/World");
            CardChariot = game.Content.Load<Texture2D>("Cards/Chariot");
            CardDeath = game.Content.Load<Texture2D>("Cards/Death");
            CardDevil = game.Content.Load<Texture2D>("Cards/Devil");
            CardEmperor = game.Content.Load<Texture2D>("Cards/Emperor");
            CardEmpress = game.Content.Load<Texture2D>("Cards/Empress");
            CardFool = game.Content.Load<Texture2D>("Cards/Fool");
            CardFortune = game.Content.Load<Texture2D>("Cards/Fortune");
            CardHangedMan = game.Content.Load<Texture2D>("Cards/HangedMan");
            CardHermit = game.Content.Load<Texture2D>("Cards/Hermit");
            CardHierophant = game.Content.Load<Texture2D>("Cards/Hierophant");
            CardJustice = game.Content.Load<Texture2D>("Cards/Justice");
            CardLovers = game.Content.Load<Texture2D>("Cards/Lovers");
            CardMagician = game.Content.Load<Texture2D>("Cards/Magician");
            CardMoon = game.Content.Load<Texture2D>("Cards/Moon");
            CardPriestess = game.Content.Load<Texture2D>("Cards/Priestess");
            CardStar = game.Content.Load<Texture2D>("Cards/Star");
            CardStrength = game.Content.Load<Texture2D>("Cards/Strength");
            CardSun = game.Content.Load<Texture2D>("Cards/Sun");
            CardTemperance = game.Content.Load<Texture2D>("Cards/Temperance");
            CardTower = game.Content.Load<Texture2D>("Cards/Tower");

            CardWidth = CardBackside.Width;
            CardHeight = CardBackside.Height;

            Cards = [
                CardFool,           // 0
                CardMagician,       // 1
                CardPriestess,      // 2
                CardEmpress,        // 3
                CardEmperor,        // 4
                CardHierophant,     // 5
                CardLovers,         // 6
                CardChariot,        // 7
                CardJustice,        // 8
                CardHermit,         // 9
                CardFortune,        // 10
                CardHangedMan,      // 11
                CardDeath,          // 12
                CardTemperance,     // 13
                CardDevil,          // 14
                CardTower,          // 15
                CardStar,           // 16
                CardMoon,           // 17
                CardSun,            // 18
                CardJudgement,      // 19
                CardWorld,          // 20
            ];
        }
    }
}
