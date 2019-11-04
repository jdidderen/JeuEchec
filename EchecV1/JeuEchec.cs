using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace EchecV1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class JeuEchec : Game
    {
        #region Initialisation des objets
        static int Grille = 8;
        static int Taille_Case = 70;
        static string[] ColonneNom = { "A", "B", "C", "D", "E", "F", "G", "H" };
        static string[] LigneNom = { "1", "2", "3", "4", "5", "6", "7", "8" };
        //Gestion des textures
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private Texture2D TextureEchiquier;
        private Texture2D[] TableauTexturePiece = new Texture2D[13];
        private Texture2D FondGauche;
        private Texture2D Bouton;
        private Texture2D FondDroit;
        private Texture2D Encadre;
        private Texture2D CaseBlanc;
        private Texture2D CaseNoir;
        private SpriteFont IndicationLettre;
        private SpriteFont IndicationChiffre;
        private SpriteFont Texte;
        //Gestion de l'échiquier
        private Pieces[,] EtatEchiquier;
        //Gestion de la partie
        private int[] SelectionPrecedente;
        private int[] SelectionActuelle; //Case sélectionnée (Celle en bleu)
        private int Tour = 0; //Nombre de tours joués
        private bool Tour_couleur = false; //Couleur du joueur qui est en train de joueur (false : Blanc / true : Noir)
        #endregion
        public JeuEchec()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            #region Initialisation
            //Changement de la taille de la fenêtre
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 620;
            graphics.ApplyChanges();
            //Initialisation des positions des pièces
            EtatEchiquier = new Pieces[8, 8] { { new Pieces(8), new Pieces(4), new Pieces(6), new Pieces(12), new Pieces(10), new Pieces(6), new Pieces(4), new Pieces(8) }, { new Pieces(2), new Pieces(2), new Pieces(2), new Pieces(2), new Pieces(2), new Pieces(2), new Pieces(2), new Pieces(2) }, { null, null, null, null, null, null, null, null }, { null, null, null, null, null, null, null, null }, { null, null, null, null, null, null, null, null }, { null, null, null, null, null, null, null, null }, { new Pieces(1), new Pieces(1), new Pieces(1), new Pieces(1), new Pieces(1), new Pieces(1), new Pieces(1), new Pieces(1) }, { new Pieces(7), new Pieces(3), new Pieces(5), new Pieces(11), new Pieces(9), new Pieces(5), new Pieces(3), new Pieces(7) } };
            #endregion
            SelectionPrecedente = null;
            SelectionActuelle = null;
            Tour = 0;
            Tour_couleur = false;
            Pieces.EchecBlanc = false;
            Pieces.EchecNoir = false;
            Pieces.MatBlanc = false;
            Pieces.MatNoir = false;
            base.Initialize();
        }

        protected void LoadImages(ref Texture2D imageVar,string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            imageVar = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream.Dispose();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            #region Création de la texture pour les cases de l'échiquier
            TextureEchiquier = new Texture2D(GraphicsDevice, 1, 1);
            TextureEchiquier.SetData(new Color[] { Color.White });
            #endregion
            #region Chargement de la texture pour le fond d'écran

            LoadImages(ref FondDroit, "Content/FondDroit.jpg");
            LoadImages(ref FondGauche, "Content/FondGauche.jpg");
            LoadImages(ref Encadre, "Content/Encadre.jpg");
            LoadImages(ref CaseBlanc, "Content/CaseBlanc.png");
            LoadImages(ref CaseNoir, "Content/CaseNoir.png");
            LoadImages(ref Bouton, "Content/Boutons.png");
            IndicationLettre = Content.Load<SpriteFont>("Papyrus_lettre");
            IndicationChiffre = Content.Load<SpriteFont>("Papyrus_chiffre");
            Texte = Content.Load<SpriteFont>("Papyrus_texte");
            #endregion
            #region Chargement des textures des pièces et ajout à un tableau
            for (int cpt = 1; cpt < 13; cpt++)
            {
                LoadImages(ref TableauTexturePiece[cpt],"Content/" + Enum.GetName(typeof(PieceID), cpt) + ".png");
            }
            #endregion
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();
            MouseState EtatSouris = Mouse.GetState();
            if (EtatSouris.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if(EtatSouris.X > 660 && EtatSouris.X < 990)
                {
                    if(EtatSouris.Y > 290 && EtatSouris.Y < 350)
                    {
                                this.Initialize();
                    }
                    if (EtatSouris.Y > 410 && EtatSouris.Y < 475)
                    {
                        //Sauvegarder
                    }
                    if (EtatSouris.Y > 520 && EtatSouris.Y < 590)
                    {
                        //Chargement
                    }
                }
            }
                if (!Pieces.MatBlanc || !Pieces.MatNoir)
            {
                if (EtatSouris.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    int xPos = (int)((EtatSouris.X-30)/ Taille_Case);
                    int yPos = (int)((EtatSouris.Y-30)/ Taille_Case);
                    if (xPos > -1 && xPos < Grille && yPos < Grille && yPos > -1)
                    {
                        if (SelectionActuelle == null)
                        {
                            if (EtatEchiquier[yPos, xPos] != null)
                            {
                                if (EtatEchiquier[yPos, xPos].Identifiant % 2 != 0 && !Tour_couleur)
                                {
                                    SelectionActuelle = new int[2];
                                    SelectionPrecedente = new int[2];
                                    SelectionActuelle[0] = xPos;
                                    SelectionActuelle[1] = yPos;
                                }
                                else if (EtatEchiquier[yPos, xPos].Identifiant % 2 == 0 && Tour_couleur)
                                {
                                    SelectionActuelle = new int[2];
                                    SelectionPrecedente = new int[2];
                                    SelectionActuelle[0] = xPos;
                                    SelectionActuelle[1] = yPos;
                                }
                            }
                        }
                        else if (EtatEchiquier[yPos, xPos] == null)
                        {
                            SelectionPrecedente[0] = SelectionActuelle[0];
                            SelectionPrecedente[1] = SelectionActuelle[1];
                            SelectionActuelle[0] = xPos;
                            SelectionActuelle[1] = yPos;
                            if (EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]].ChoixMouvement(EtatEchiquier, SelectionPrecedente[0], SelectionPrecedente[1], SelectionActuelle[0], SelectionActuelle[1]))
                            {
                                EtatEchiquier[SelectionActuelle[1], SelectionActuelle[0]] = EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]];
                                EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]] = null;
                                SelectionActuelle = null;
                                SelectionPrecedente = null;
                                if (Tour_couleur)
                                {
                                    Tour++;
                                }
                                Tour_couleur = !Tour_couleur;
                                Pieces.VerifEchec(EtatEchiquier);
                                if (Pieces.EchecBlanc || Pieces.EchecNoir)
                                {
                                    Pieces.VerifMat(EtatEchiquier);
                                }
                            }
                            else
                            {
                                SelectionActuelle[0] = SelectionPrecedente[0];
                                SelectionActuelle[1] = SelectionPrecedente[1];
                            }
                        }
                        else if (EtatEchiquier[yPos, xPos].Identifiant % 2 != EtatEchiquier[SelectionActuelle[1], SelectionActuelle[0]].Identifiant % 2 && EtatEchiquier[yPos, xPos] != EtatEchiquier[SelectionActuelle[1], SelectionActuelle[0]])
                        {
                            SelectionPrecedente[0] = SelectionActuelle[0];
                            SelectionPrecedente[1] = SelectionActuelle[1];
                            SelectionActuelle[0] = xPos;
                            SelectionActuelle[1] = yPos;
                            if (EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]].ChoixMouvement(EtatEchiquier, SelectionPrecedente[0], SelectionPrecedente[1], SelectionActuelle[0], SelectionActuelle[1]))
                            {
                                EtatEchiquier[SelectionActuelle[1], SelectionActuelle[0]] = EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]];
                                EtatEchiquier[SelectionPrecedente[1], SelectionPrecedente[0]] = null;
                                SelectionActuelle = null;
                                SelectionPrecedente = null;
                                if (Tour_couleur)
                                {
                                    Tour++;
                                }
                                Tour_couleur = !Tour_couleur;
                                Pieces.VerifEchec(EtatEchiquier);
                                if (Pieces.EchecBlanc || Pieces.EchecNoir)
                                {
                                    Pieces.VerifMat(EtatEchiquier);
                                }
                            }
                            else
                            {
                                SelectionActuelle[0] = SelectionPrecedente[0];
                                SelectionActuelle[1] = SelectionPrecedente[1];
                            }
                        }
                        else
                        {
                            if (EtatEchiquier[yPos, xPos].Identifiant % 2 != 0 && !Tour_couleur)
                            {
                                SelectionActuelle[0] = xPos;
                                SelectionActuelle[1] = yPos;
                            }
                            else if (EtatEchiquier[yPos, xPos].Identifiant % 2 == 0 && Tour_couleur)
                            {
                                SelectionActuelle[0] = xPos;
                                SelectionActuelle[1] = yPos;
                            }
                        }
                    }
                }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(102, 102, 153));
            Texture2D TexturePiece;
            spriteBatch.Begin();
            //Chargement fond d'écran
            spriteBatch.Draw(FondGauche, new Rectangle(0, 0, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(FondDroit, new Rectangle(Taille_Case * Grille + 60, 0, graphics.PreferredBackBufferWidth - 620, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(Encadre, new Rectangle(Taille_Case * Grille + 90, 50, 350, 200), Color.White);
            spriteBatch.Draw(Bouton, new Rectangle(Taille_Case * Grille + 95, 275, 345, 90), Color.White);
            spriteBatch.Draw(Bouton, new Rectangle(Taille_Case * Grille + 95, 400, 345, 90), Color.White);
            spriteBatch.Draw(Bouton, new Rectangle(Taille_Case * Grille + 95, 515, 345, 90), Color.White);
            spriteBatch.DrawString(Texte, "Nouvelle partie", new Vector2(Taille_Case * Grille + 200,305), Color.WhiteSmoke);
            spriteBatch.DrawString(Texte, "Sauver la partie", new Vector2(Taille_Case * Grille + 200, 430), Color.WhiteSmoke);
            spriteBatch.DrawString(Texte, "Charger une partie", new Vector2(Taille_Case * Grille + 190, 545), Color.WhiteSmoke);
            #region Création de l'échiquier
            Color CouleurCase = Color.White;
            for (int ligne = 0; ligne < 8; ligne++)
            {
                spriteBatch.DrawString(IndicationChiffre, LigneNom[7 - ligne], new Vector2(5, ligne * Taille_Case + 50), Color.WhiteSmoke);
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    spriteBatch.DrawString(IndicationLettre, ColonneNom[colonne], new Vector2(colonne * Taille_Case + 55,5), Color.WhiteSmoke);
                    if (ligne % 2 == 0)
                    {
                        if (colonne % 2 == 0)
                        {
                            CouleurCase = Color.White;
                        }
                        else
                        {
                            CouleurCase = Color.Gray;
                        }
                    }
                    else
                    {
                        if (colonne % 2 == 0)
                        {
                            CouleurCase = Color.Gray;
                        }
                        else
                        {
                            CouleurCase = Color.White;
                        }
                    }
                    if (SelectionActuelle != null)
                    {
                        if (SelectionActuelle[0] == colonne && SelectionActuelle[1] == ligne)
                        {
                            CouleurCase = Color.Brown;
                        }
                        Pieces.VerifMatetPredictions(EtatEchiquier, SelectionActuelle, true, this, null);
                    }
                    if (CouleurCase == Color.White)
                    {
                        spriteBatch.Draw(CaseBlanc, new Rectangle(colonne * Taille_Case + 30, ligne * Taille_Case + 30, Taille_Case, Taille_Case), Color.White);
                    }
                    else if (CouleurCase == Color.Gray)
                    {
                        spriteBatch.Draw(CaseNoir, new Rectangle(colonne * Taille_Case + 30 , ligne * Taille_Case + 30, Taille_Case, Taille_Case), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(CaseBlanc, new Rectangle(colonne * Taille_Case + 30, ligne * Taille_Case + 30, Taille_Case, Taille_Case), CouleurCase);
                    }
                    if (EtatEchiquier[ligne, colonne] != null)
                    {
                        TexturePiece = TableauTexturePiece[(EtatEchiquier[ligne, colonne]).Identifiant];
                        spriteBatch.Draw(TexturePiece, new Rectangle(colonne * Taille_Case + 30, ligne * Taille_Case + 30, Taille_Case, Taille_Case), Color.White);
                    }
                }
                if(Pieces.EchecBlanc)
                {
                    if(Pieces.MatBlanc)
                    {
                        spriteBatch.DrawString(IndicationChiffre, "Echec et Mat du Roi blanc", new Vector2(Taille_Case * Grille + 133, 100), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(IndicationChiffre, "Roi blanc en echec", new Vector2(Taille_Case * Grille + 165, 100), Color.White);
                    }                    
                }
                else if(Pieces.EchecNoir)
                {
                    if (Pieces.MatNoir)
                    {
                        spriteBatch.DrawString(IndicationChiffre, "Echec et Mat du Roi noir", new Vector2(Taille_Case * Grille + 165, 100), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(IndicationChiffre, "Roi noir en echec", new Vector2(Taille_Case * Grille + 133, 100), Color.White);
                    }                   
                }
                if(Tour_couleur)
                {
                    spriteBatch.DrawString(IndicationChiffre, "Au tour du joueur noir", new Vector2(Taille_Case * Grille + 133, 150), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(IndicationChiffre, "Au tour du joueur blanc", new Vector2(Taille_Case * Grille + 123, 150), Color.White);
                }
                

            }
            spriteBatch.End();
            #endregion
            base.Draw(gameTime);
        }
        #region Fonction pour générer les bordures pour l'assistance
        public void Bordure(int x, int y)
        {
            spriteBatch.Draw(TextureEchiquier, new Rectangle(x * Taille_Case + 30,30 + y * Taille_Case - 3, Taille_Case, 3), Color.DarkRed); //Ligne supérieure
            spriteBatch.Draw(TextureEchiquier, new Rectangle(x * Taille_Case + 30 + (Taille_Case),30 + y * Taille_Case, 3, Taille_Case), Color.DarkRed); //Ligne droite
            spriteBatch.Draw(TextureEchiquier, new Rectangle(x * Taille_Case + 30, 30 + y * Taille_Case + (Taille_Case - 3), Taille_Case, 3), Color.DarkRed); //Ligne inférieure
            spriteBatch.Draw(TextureEchiquier, new Rectangle(x * Taille_Case + 30,30 + y * Taille_Case, 3, Taille_Case), Color.DarkRed); //Ligne gauche
        }
        #endregion
    }
}
