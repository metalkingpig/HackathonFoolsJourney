using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HackathonFoolsJourney
{
    public class Assets
    {
        public readonly Texture2D WhitePixel;

        public readonly SpriteFont Font;

        public readonly Texture2D BGCastle;

        // Misc
        public readonly Texture2D CardOutline;
        public readonly Texture2D CardBackside;

        // Jack
        public readonly Texture2D CardJack1;
        public readonly Texture2D CardJack2;
        public readonly Texture2D CardJack3;
        public readonly Texture2D CardJack4;
        public readonly Texture2D CardJack5;
        public readonly Texture2D CardJack6;
        public readonly Texture2D CardJack7;
        public readonly Texture2D CardJack8;
        public readonly Texture2D CardJack9;
        public readonly Texture2D CardJack10;
        public readonly Texture2D CardJackJ;
        public readonly Texture2D CardJackQ;
        public readonly Texture2D CardJackK;

        // Cup
        public readonly Texture2D CardCup1;
        public readonly Texture2D CardCup2;
        public readonly Texture2D CardCup3;
        public readonly Texture2D CardCup4;
        public readonly Texture2D CardCup5;
        public readonly Texture2D CardCup6;
        public readonly Texture2D CardCup7;
        public readonly Texture2D CardCup8;
        public readonly Texture2D CardCup9;
        public readonly Texture2D CardCup10;
        public readonly Texture2D CardCupJ;
        public readonly Texture2D CardCupQ;
        public readonly Texture2D CardCupK;

        // Cup
        public readonly Texture2D CardSword1;
        public readonly Texture2D CardSword2;
        public readonly Texture2D CardSword3;
        public readonly Texture2D CardSword4;
        public readonly Texture2D CardSword5;
        public readonly Texture2D CardSword6;
        public readonly Texture2D CardSword7;
        public readonly Texture2D CardSword8;
        public readonly Texture2D CardSword9;
        public readonly Texture2D CardSword10;
        public readonly Texture2D CardSwordJ;
        public readonly Texture2D CardSwordQ;
        public readonly Texture2D CardSwordK;

        // Major
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

            Font = game.Content.Load<SpriteFont>("Fonts/Tiny5");

            // Backgrounds
            BGCastle = game.Content.Load<Texture2D>("Backgrounds/Castle");

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

            // Jack
            CardJack1 = game.Content.Load<Texture2D>("Cards/Jack1");
            CardJack2 = game.Content.Load<Texture2D>("Cards/Jack2");
            CardJack3 = game.Content.Load<Texture2D>("Cards/Jack3");
            CardJack4 = game.Content.Load<Texture2D>("Cards/Jack4");
            CardJack5 = game.Content.Load<Texture2D>("Cards/Jack5");
            CardJack6 = game.Content.Load<Texture2D>("Cards/Jack6");
            CardJack7 = game.Content.Load<Texture2D>("Cards/Jack7");
            CardJack8 = game.Content.Load<Texture2D>("Cards/Jack8");
            CardJack9 = game.Content.Load<Texture2D>("Cards/Jack9");
            CardJack10 = game.Content.Load<Texture2D>("Cards/Jack10");
            CardJackK = game.Content.Load<Texture2D>("Cards/JackK");
            CardJackQ = game.Content.Load<Texture2D>("Cards/JackK");
            CardJackJ = game.Content.Load<Texture2D>("Cards/JackJ");

            // Cup
            CardCup1 = game.Content.Load<Texture2D>("Cards/Cup1");
            CardCup2 = game.Content.Load<Texture2D>("Cards/Cup2");
            CardCup3 = game.Content.Load<Texture2D>("Cards/Cup3");
            CardCup4 = game.Content.Load<Texture2D>("Cards/Cup4");
            CardCup5 = game.Content.Load<Texture2D>("Cards/Cup5");
            CardCup6 = game.Content.Load<Texture2D>("Cards/Cup6");
            CardCup7 = game.Content.Load<Texture2D>("Cards/Cup7");
            CardCup8 = game.Content.Load<Texture2D>("Cards/Cup8");
            CardCup9 = game.Content.Load<Texture2D>("Cards/Cup9");
            CardCup10 = game.Content.Load<Texture2D>("Cards/Cup10");
            CardCupK = game.Content.Load<Texture2D>("Cards/CupK");
            CardCupQ = game.Content.Load<Texture2D>("Cards/CupK");
            CardCupJ = game.Content.Load<Texture2D>("Cards/CupJ");

            // Sword
            CardSword1 = game.Content.Load<Texture2D>("Cards/Sword1");
            CardSword2 = game.Content.Load<Texture2D>("Cards/Sword2");
            CardSword3 = game.Content.Load<Texture2D>("Cards/Sword3");
            CardSword4 = game.Content.Load<Texture2D>("Cards/Sword4");
            CardSword5 = game.Content.Load<Texture2D>("Cards/Sword5");
            CardSword6 = game.Content.Load<Texture2D>("Cards/Sword6");
            CardSword7 = game.Content.Load<Texture2D>("Cards/Sword7");
            CardSword8 = game.Content.Load<Texture2D>("Cards/Sword8");
            CardSword9 = game.Content.Load<Texture2D>("Cards/Sword9");
            CardSword10 = game.Content.Load<Texture2D>("Cards/Sword10");
            CardSwordK = game.Content.Load<Texture2D>("Cards/SwordK");
            CardSwordQ = game.Content.Load<Texture2D>("Cards/SwordK");
            CardSwordJ = game.Content.Load<Texture2D>("Cards/SwordJ");

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
