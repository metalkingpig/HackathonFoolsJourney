using HackathonFoolsJourney.GameRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HackathonFoolsJourney
{
    public class GameState
    {
        private readonly Main game;
        private readonly Assets assets;
        private readonly Renderer renderer;

        private Deck deck;
        private PlayingField field;
        private Player player;
        private List<CardEffect> cardEffects;
        private Random rng = new Random();

        private int cardHovered;
        private float cardRotation;
        private bool cardJustUsed;

        private bool selectingAction;
        private int selectedCard;
        private int selectedAction; // 1 == Health, 2 == Strength, 3 == Wisdom

        public GameState(Main game, Assets assets, Renderer renderer)
        {
            this.game = game;
            this.assets = assets;
            this.renderer = renderer;

            deck = new(assets);
            field = new(deck);
            player = new(20);
            cardEffects = [];
            selectingAction = false;
            selectedCard = -1;
        }

        public void Update()
        {
            var kbState = Keyboard.GetState();

            if (selectingAction)
            {
                if (kbState.IsKeyDown(Keys.Q))
                {
                    selectedAction = 1;
                    if (!cardJustUsed)
                    {
                        Card card = GetCardFromIndex(selectedCard);
                        UseCard(ref card);
                        SetCardFromIndex(selectedCard, card);
                        if (card.value <= 0)
                            field.RemoveCard(selectedCard);
                        selectingAction = false;
                        selectedCard = -1;
                    }
                    cardJustUsed = true;
                }
                else if (kbState.IsKeyDown(Keys.W))
                {
                    selectedAction = 2;
                    if (!cardJustUsed && player.Strength > 0)
                    {
                        Card card = GetCardFromIndex(selectedCard);
                        UseCard(ref card);
                        SetCardFromIndex(selectedCard, card);
                        if (card.value <= 0)
                            field.RemoveCard(selectedCard);
                        selectingAction = false;
                        selectedCard = -1;
                    }
                    cardJustUsed = true;
                }
                else if (kbState.IsKeyDown(Keys.E))
                {
                    selectedAction = 3;
                    if (!cardJustUsed && player.Wisdom > 0)
                    {
                        Card card = GetCardFromIndex(selectedCard);
                        UseCard(ref card);
                        SetCardFromIndex(selectedCard, card);
                        if (card.value <= 0)
                            field.RemoveCard(selectedCard);
                        selectingAction = false;
                        selectedCard = -1;
                    }
                    cardJustUsed = true;
                }
                else
                {
                    cardJustUsed = false;
                }
                return;
            }

            if (cardHovered >= 0)
            {
                Card card = GetCardFromIndex(cardHovered);
                if (kbState.IsKeyDown(Keys.Q)) // Use
                {
                    if (!cardJustUsed)
                    {
                        if (card.suit == CardSuit.Arcana)
                        {
                            selectingAction = true;
                            selectedCard = cardHovered;
                            if (card.value <= 0)
                            {
                                field.RemoveCard(cardHovered);
                            }
                        }
                        else
                        {
                            UseCard(ref card);
                            field.RemoveCard(cardHovered);

                            Vector2 pos = GetCardUIPosition(cardHovered);

                            CardEffect effect = new()
                            {
                                Texture = card.tex,
                                X = pos.X,
                                Y = pos.Y,
                                VX = (rng.NextSingle() * (3f - -3) + -3),
                                VY = -3,
                                Color = Color.White,
                            };
                            effect.RotationSpeed = effect.VX * 0.01f;
                            cardEffects.Add(effect);
                        }
                    }
                    cardJustUsed = true;
                }
                else if (kbState.IsKeyDown(Keys.W)) // Discard
                {
                    if (!cardJustUsed && field.CanDiscard(card))
                    {
                        Vector2 pos = GetCardUIPosition(cardHovered);

                        field.RemoveCard(cardHovered);

                        CardEffect effect = new()
                        {
                            Type = 1,
                            Texture = card.tex,
                            X = pos.X,
                            Y = pos.Y,
                            VX = (rng.NextSingle() * (3f - -3) + -3),
                            VY = -3,
                            Color = Color.White,
                        };
                        effect.RotationSpeed = effect.VX * 0.05f;
                        cardEffects.Add(effect);
                    }

                    cardJustUsed = true;
                }
                else if (kbState.IsKeyDown(Keys.E)) // Store
                {
                    if (!cardJustUsed && field.CanStore(card))
                    {
                        field.Storage.Add(card);
                        field.RemoveCard(cardHovered);
                    }

                    cardJustUsed = true;
                }
                else
                {
                    cardJustUsed = false;
                }
            }
            else
            {
                cardJustUsed = false;
            }
        }

        public void Draw(Renderer renderer)
        {
            cardHovered = -1;

            // Draw BG
            renderer.DrawCentered(assets.BGCastle, Renderer.VirtualWidth / 2, Renderer.VirtualHeight / 2, new Vector2(8), Color.Violet);

            // Player Stats
            renderer.DrawTextScaled(assets.Font, $"Health:{player.Health}", 10, 10, 2);
            renderer.DrawTextScaled(assets.Font, $"Strength:{player.Strength}", 10, 40, 2);
            renderer.DrawTextScaled(assets.Font, $"Wisdom:{player.Wisdom}", 10, 70, 2);

            renderer.DrawTextCentered(assets.Font, "Storage", 700, 50, 2);

            // Cards
            int cardsPerRow = field.Field.Count;
            float xIncr = (float)Renderer.VirtualWidth / (cardsPerRow + 1);
            float x = 0f;
            for (int i = 0; i < cardsPerRow; i++)
            {
                x += xIncr;
                if (selectedCard == i || (selectedCard == -1 && renderer.MouseInHitbox(game.currentMouseState.X, game.currentMouseState.Y, x, 650, assets.CardWidth * 2, assets.CardHeight * 2)))
                {
                    renderer.DrawAnimatedCard(field.Field[i].tex, x, 650, cardRotation, new Vector2(2));
                    cardRotation += 0.05f;
                    cardHovered = i;
                }
                else
                    renderer.DrawCentered(field.Field[i].tex, x, 650, 2);
            }

            // Storage
            float y = 100;
            for (int i = field.Storage.Count - 1; i >= 0; i--)
            {
                y += 100;
                if (selectedCard == i + PlayingField.FIELD_MAX || ((cardHovered == i + PlayingField.FIELD_MAX || cardHovered == -1) && selectedCard == -1 && renderer.MouseInHitbox(game.currentMouseState.X, game.currentMouseState.Y, 700, y, assets.CardWidth * 2, assets.CardHeight * 2)))
                {
                    renderer.DrawAnimatedCard(field.Field[i].tex, 700, y, cardRotation, new Vector2(2));
                    cardRotation += 0.05f;
                    cardHovered = i + PlayingField.FIELD_MAX;
                }
                else
                    renderer.DrawCentered(field.Storage[i].tex, 700, y, 2);
            }

            for (int i = 0; i < cardEffects.Count; i++)
            {
                CardEffect effect = cardEffects[i];
                effect.Draw(renderer);

                if (effect.Type == 0)
                {
                    effect.X += effect.VX;
                    effect.Y += effect.VY;
                    effect.Rotation += effect.RotationSpeed;
                    effect.VY -= 0.3f;
                    Color col = effect.Color;
                    int alpha = col.A - 10;
                    if (alpha < 0) alpha = 0;
                    col.A = (byte)alpha;
                    effect.Color = col;
                }
                else
                {
                    effect.X += effect.VX;
                    effect.Y += effect.VY;
                    effect.Rotation += effect.RotationSpeed;
                    effect.VY += 0.3f;
                }

                if (effect.Y > Renderer.VirtualHeight + 200 || effect.Y < -200)
                {
                    cardEffects.RemoveAt(i);
                    i--;
                }
                else
                {
                    cardEffects[i] = effect;
                }
            }

            if (selectedCard != -1 || cardHovered != -1)
                RenderActions(renderer);

            // Draw bars on screen edge when resizing window
            renderer.DrawEdgeBars();

            if (cardHovered == -1)
                cardRotation = MathHelper.PiOver2;
        }

        private Vector2 GetCardUIPosition(int cardIndex)
        {
            if (cardIndex < PlayingField.FIELD_MAX)
            {
                int cardsPerRow = field.Field.Count;
                float xIncr = (float)Renderer.VirtualWidth / (cardsPerRow + 1);
                float x = xIncr * cardIndex + xIncr;
                return new Vector2(x, 650);
            }
            else
            {
                float y = 100 * (cardIndex - PlayingField.FIELD_MAX) + 200;
                return new Vector2(700, y);
            }
        }

        private void RenderActions(Renderer renderer)
        {
            Card card;
            if (selectedCard != -1)
            {
                card = GetCardFromIndex(selectedCard);
            }
            else
            {
                card = GetCardFromIndex(cardHovered);
            }

            if (card.suit == CardSuit.Arcana)
            {
                renderer.DrawTextCentered(assets.Font, "Challenge Card", 400, 50, 2f);
                renderer.DrawTextCentered(assets.Font, $"Current Value: {card.value}", 400, 80, 1.5f);
            }

            if (selectedCard != -1)
            {
                renderer.DrawTextCentered(assets.Font, "You can choose to use your:", 400, 200, 2f);
                renderer.DrawTextCentered(assets.Font, "Health (Q)", 400, 250, 1.5f);
                Color color = player.Strength > 0 ? Color.White : new Color(0.3f, 0.3f, 0.3f);
                renderer.DrawTextCentered(assets.Font, "Strength (W)", 400, 300, 1.5f, color);
                color = player.Wisdom > 0 ? Color.White : new Color(0.3f, 0.3f, 0.3f);
                renderer.DrawTextCentered(assets.Font, "Wisdom (E)", 400, 350, 1.5f, color);
            }
            else
            {
                renderer.DrawTextCentered(assets.Font, "Possible Actions:", 400, 200, 2f);

                renderer.DrawTextCentered(assets.Font, "Press Q To Use", 400, 250, 1.5f);

                if (!field.CanDiscard(card))
                    renderer.DrawTextCentered(assets.Font, "Press W To Discard", 400, 300, 1.5f, new Color(0.3f, 0.3f, 0.3f));
                else
                    renderer.DrawTextCentered(assets.Font, "Press W To Discard", 400, 300, 1.5f);

                if (!field.CanStore(card))
                    renderer.DrawTextCentered(assets.Font, "Press E To Store", 400, 350, 1.5f, new Color(0.3f, 0.3f, 0.3f));
                else
                    renderer.DrawTextCentered(assets.Font, "Press E To Store", 400, 350, 1.5f);
            }
        }

        private Card GetCardFromIndex(int index)
        {
            if (index < PlayingField.FIELD_MAX)
                return field.Field[index];
            else
                return field.Storage[index - PlayingField.FIELD_MAX];
        }

        private void SetCardFromIndex(int index, Card card)
        {
            if (index < PlayingField.FIELD_MAX)
                field.Field[index] = card;
            else
                field.Storage[index - PlayingField.FIELD_MAX] = card;
        }

        private void UseCard(ref Card card)
        {
            switch (card.suit)
            {
                case CardSuit.Arcana:
                    // 1 == Health, 2 == Strength, 3 == Wisdom
                    if (selectedAction == 1)
                    {
                        player.Health -= card.value;
                        if (player.Health <= 0)
                        {
                            throw new NotImplementedException("dead");
                        }
                        card.value = 0;
                    }
                    else if (selectedAction == 2)
                    {
                        card.value -= player.Strength;
                        player.Strength = 0;
                    }
                    else if (selectedAction == 3)
                    {
                        int cardValue = card.value;
                        card.value -= player.Wisdom;
                        player.Wisdom -= cardValue;
                        if (player.Wisdom < 0) player.Wisdom = 0;
                    }
                    break;
                case CardSuit.Jack:
                    player.Wisdom += card.value;
                    break;
                case CardSuit.Cup:
                    player.Health += card.value;
                    break;
                case CardSuit.Sword:
                    player.Strength += card.value;
                    break;
            }
        }

        private struct CardEffect
        {
            public Texture2D Texture;
            public int Type;
            public float X;
            public float Y;
            public float VX;
            public float VY;
            public float Rotation;
            public float RotationSpeed;
            public Color Color;

            public readonly void Draw(Renderer renderer)
            {
                renderer.DrawCentered(Texture, X, Y, new Vector2(2), Rotation, Color);
            }
        }
    }
}
