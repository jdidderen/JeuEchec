using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace EchecV1
{
    public enum PieceID
    {
        None, //0
        pion_blanc, //1
        pion_noir, //2
        cavalier_blanc, //3
        cavalier_noir, //4
        fou_blanc, //5
        fou_noir, //6
        tour_blanc, //7
        tour_noir, //8
        roi_blanc, //9
        roi_noir, //10
        reine_blanc, //11
        reine_noir, //12
    };
    public class Pieces
    {
        #region Déclaration
        public int Identifiant; //Identfiant basé sur l'enum PieceID
        public bool Mouvement; //Est-ce que la pièce s'est déjà déplacée ?
        public static bool EchecBlanc = false;
        public static bool EchecNoir = false;
        public static bool MatBlanc = false;
        public static bool MatNoir = false;
        #endregion
        public Pieces(int id)
        {
            this.Identifiant = id;
            this.Mouvement = false;
        }
        #region Appel des mouvements
        public bool ChoixMouvement(Pieces[,] Echequier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            switch (Echequier[Aypos, Axpos].Identifiant)
            {
                case 1:
                    return MouvementPionBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 2:
                    return MouvementPionNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 3:
                    return MouvementCavalierBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 4:
                    return MouvementCavalierNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 5:
                    return MouvementFouBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 6:
                    return MouvementFouNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 7:
                    return MouvementTourBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 8:
                    return MouvementTourNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 9:
                    return MouvementRoiBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 10:
                    return MouvementRoiNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 11:
                    return MouvementReineBlanc(Echequier, Axpos, Aypos, Nxpos, Nypos);
                case 12:
                    return MouvementReineNoir(Echequier, Axpos, Aypos, Nxpos, Nypos);
                default:
                    return false;
            }
        }
        #endregion
        #region Mouvements des pièces
        public bool MouvementPionBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos == Nxpos && Aypos - 1 == Nypos && Echiquier[Nypos, Nxpos] == null)
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos == Nxpos && Aypos - 2 == Nypos && Echiquier[Nypos, Nxpos] == null)
            {

                if (this.Mouvement == false)
                {
                    if (Echiquier[Aypos - 2, Axpos] == null && Pieces.EchecRoiBlanc(Echiquier, Aypos, Axpos, Nxpos, Nypos))
                    {
                        this.Mouvement = true;
                        return true;
                    }
                }
            }
            if (Axpos - 1 == Nxpos && Aypos - 1 == Nypos && Echiquier[Nypos, Nxpos] != null)
            {
                if (Echiquier[Nypos, Nxpos].Identifiant % 2 == 0 && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos - 1 == Nypos && Echiquier[Nypos, Nxpos] != null)
            {
                if (Echiquier[Nypos, Nxpos].Identifiant % 2 == 0 && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            return false;
        }
        public bool MouvementPionNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos == Nxpos && Aypos + 1 == Nypos && Echiquier[Nypos, Nxpos] == null)
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos == Nxpos && Aypos + 2 == Nypos && Echiquier[Nypos, Nxpos] == null)
            {

                if (this.Mouvement == false)
                {
                    if (Echiquier[Aypos + 2, Axpos] == null && Pieces.EchecRoiNoir(Echiquier, Aypos, Axpos, Nxpos, Nypos))
                    {
                        this.Mouvement = true;
                        return true;
                    }
                }
            }
            if (Axpos - 1 == Nxpos && Aypos + 1 == Nypos && Echiquier[Nypos, Nxpos] != null)
            {
                if (Echiquier[Nypos, Nxpos].Identifiant % 2 != 0 && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos + 1 == Nypos && Echiquier[Nypos, Nxpos] != null)
            {
                if (Echiquier[Nypos, Nxpos].Identifiant % 2 != 0 && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            return false;
        }
        public bool MouvementCavalierBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos + 1 == Nxpos && Aypos - 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 2 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 2 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos + 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos + 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 2 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 2 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos - 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            return false;
        }
        public bool MouvementCavalierNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos + 1 == Nxpos && Aypos - 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 2 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 2 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos + 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos + 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 2 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 2 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos - 2 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    return true;
                }
            }
            return false;
        }
        public bool MouvementFouBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos > Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementFouNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos > Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementTourBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos == Nxpos && Aypos < Nypos && Aypos + cpt < 8)
                {
                    if (Axpos == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos == Nxpos && Aypos > Nypos && Aypos - cpt > -1)
                {
                    if (Axpos == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos == Nypos && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos == Nypos && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementTourNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos == Nxpos && Aypos < Nypos && Aypos + cpt < 8)
                {
                    if (Axpos == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos == Nxpos && Aypos > Nypos && Aypos - cpt > -1)
                {
                    if (Axpos == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos == Nypos && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos == Nypos && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementReineBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos == Nxpos && Aypos < Nypos && Aypos + cpt < 8)
                {
                    if (Axpos == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos == Nxpos && Aypos > Nypos && Aypos - cpt > -1)
                {
                    if (Axpos == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos == Nypos && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos == Nypos && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementReineNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (Axpos == Nxpos && Aypos < Nypos && Aypos + cpt < 8)
                {
                    if (Axpos == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos == Nxpos && Aypos > Nypos && Aypos - cpt > -1)
                {
                    if (Axpos == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos == Nypos && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos == Nypos && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos > Nypos && Aypos - cpt > -1 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos - cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos - cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos < Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos + cpt < 8)
                {
                    if (Axpos + cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos + cpt] != null)
                    {
                        return false;
                    }
                }
                else if (Axpos > Nxpos && Aypos < Nypos && Aypos + cpt < 8 && Axpos - cpt > -1)
                {
                    if (Axpos - cpt == Nxpos && Aypos + cpt == Nypos && Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                    {
                        return true;
                    }
                    else if (Echiquier[Aypos + cpt, Axpos - cpt] != null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool MouvementRoiBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 == 0))
            {
                if (Pieces.EchecRoiBlanc(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            return false;
        }
        public bool MouvementRoiNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            if (Axpos == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos + 1 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos + 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            if (Axpos - 1 == Nxpos && Aypos - 1 == Nypos && (Echiquier[Nypos, Nxpos] == null || Echiquier[Nypos, Nxpos].Identifiant % 2 != 0))
            {
                if (Pieces.EchecRoiNoir(Echiquier, Axpos, Aypos, Nxpos, Nypos))
                {
                    this.Mouvement = true;
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Vérification de l'échec + Echec et mat
        public static bool EchecRoiBlanc(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            bool LigneG = true, LigneD = true, ColonneH = true, ColonneB = true, DiaHG = true, DiaHD = true, DiaBG = true, DiaBD = true;
            Pieces[,] EchequierVirtuel = new Pieces[8, 8];
            for (int colonne = 0; colonne < 8; colonne++)
            {
                for (int ligne = 0; ligne < 8; ligne++)
                {
                    EchequierVirtuel[ligne, colonne] = Echiquier[ligne, colonne];
                }
            }

            EchequierVirtuel[Nypos, Nxpos] = EchequierVirtuel[Aypos, Axpos];
            EchequierVirtuel[Aypos, Axpos] = null;
            int[] PosRoi = new int[2];
            for (int colonne = 0; colonne < 8; colonne++)
            {
                for (int ligne = 0; ligne < 8; ligne++)
                {
                    if (EchequierVirtuel[ligne, colonne] != null)
                    {
                        if (EchequierVirtuel[ligne, colonne].Identifiant == 9)
                        {
                            PosRoi[0] = colonne;
                            PosRoi[1] = ligne;
                            ligne = 8;
                            colonne = 8;
                        }
                    }
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 1] != null && (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 1].Identifiant == 2 || EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 1].Identifiant == 10))
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 1] != null && (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 1].Identifiant == 2 || EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 1].Identifiant == 10))
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0]] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0]].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1], PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1], PosRoi[0] - 1].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1], PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1], PosRoi[0] + 1].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[0] - 1 > -1 && PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0]] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0]].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[0] + 1 < 8 && PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1].Identifiant == 10)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] - 2 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 2] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 2].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] - 2 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 2] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 2].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 2 < 8 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] - 1].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 2 < 8 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] + 1].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] + 2 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 2] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 2].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] + 2 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 2] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 2].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 2 > -1 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] + 1].Identifiant == 4)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 2 > -1 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] - 1].Identifiant == 4)
                {
                    return false;
                }
            }
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (PosRoi[0] + cpt < 8 && PosRoi[1] < 8 && LigneD)
                {
                    if (EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt].Identifiant == 8 || EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            LigneD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > -1 && PosRoi[1] > -1 && LigneG)
                {
                    if (EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt].Identifiant == 8 || EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            LigneG = false;
                        }
                    }
                }
                if (PosRoi[0] < 8 && PosRoi[1] - cpt > -1 && ColonneH)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]].Identifiant == 8 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            ColonneH = false;
                        }
                    }
                }
                if (PosRoi[0] > -1 && PosRoi[1] + cpt < 8 && ColonneB)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]].Identifiant == 8 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            ColonneB = false;
                        }
                    }
                }
                if (PosRoi[0] + cpt < 8 && PosRoi[1] + cpt < 8 && DiaBD)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt].Identifiant == 6 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            DiaBD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > 0 && PosRoi[1] - cpt > -1 && DiaHG)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt].Identifiant == 6 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            DiaHG = false;
                        }
                    }
                }
                if (PosRoi[0] + cpt > 0 && PosRoi[0] + cpt < 8 && PosRoi[1] - cpt > -1 && PosRoi[1] - cpt < 8 && DiaHD)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt].Identifiant == 6 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            DiaHD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > -1 && PosRoi[1] + cpt < 8 && DiaBG)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt].Identifiant == 6 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt].Identifiant == 12)
                        {
                            return false;
                        }
                        else
                        {
                            DiaBG = false;
                        }
                    }
                }
            }
            return true;
        }
        public static bool EchecRoiNoir(Pieces[,] Echiquier, int Axpos, int Aypos, int Nxpos, int Nypos)
        {
            bool LigneG = true, LigneD = true, ColonneH = true, ColonneB = true, DiaHG = true, DiaHD = true, DiaBG = true, DiaBD = true;
            Pieces[,] EchequierVirtuel = new Pieces[8, 8];
            for (int colonne = 0; colonne < 8; colonne++)
            {
                for (int ligne = 0; ligne < 8; ligne++)
                {
                    EchequierVirtuel[ligne, colonne] = Echiquier[ligne, colonne];
                }
            }

            EchequierVirtuel[Nypos, Nxpos] = EchequierVirtuel[Aypos, Axpos];
            EchequierVirtuel[Aypos, Axpos] = null;
            int[] PosRoi = new int[2];
            for (int colonne = 0; colonne < 8; colonne++)
            {
                for (int ligne = 0; ligne < 8; ligne++)
                {
                    if (EchequierVirtuel[ligne, colonne] != null)
                    {
                        if (EchequierVirtuel[ligne, colonne].Identifiant == 10)
                        {
                            PosRoi[0] = colonne;
                            PosRoi[1] = ligne;
                            ligne = 8;
                            colonne = 8;
                        }
                    }
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1] != null && (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1].Identifiant == 1 || EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1].Identifiant == 9))
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1] != null && (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1].Identifiant == 1 || EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1].Identifiant == 9))
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0]] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0]].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1], PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1], PosRoi[0] - 1].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1], PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1], PosRoi[0] + 1].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[0] - 1 > -1 && PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 1].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0]] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0]].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[0] + 1 < 8 && PosRoi[1] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 1].Identifiant == 9)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] - 2 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 2] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] - 2].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] - 2 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 2] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] - 2].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 2 < 8 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] - 1].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 2 < 8 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] + 2, PosRoi[0] + 1].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] + 1 < 8 && PosRoi[0] + 2 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 2] != null && EchequierVirtuel[PosRoi[1] + 1, PosRoi[0] + 2].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 1 > -1 && PosRoi[0] + 2 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 2] != null && EchequierVirtuel[PosRoi[1] - 1, PosRoi[0] + 2].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 2 > -1 && PosRoi[0] + 1 < 8)
            {
                if (EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] + 1] != null && EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] + 1].Identifiant == 3)
                {
                    return false;
                }
            }
            if (PosRoi[1] - 2 > -1 && PosRoi[0] - 1 > -1)
            {
                if (EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] - 1] != null && EchequierVirtuel[PosRoi[1] - 2, PosRoi[0] - 1].Identifiant == 3)
                {
                    return false;
                }
            }
            for (int cpt = 1; cpt < 8; cpt++)
            {
                if (PosRoi[0] + cpt < 8 && PosRoi[1] < 8 && LigneD)
                {
                    if (EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt].Identifiant == 7 || EchequierVirtuel[PosRoi[1], PosRoi[0] + cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            LigneD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > -1 && PosRoi[1] > -1 && LigneG)
                {
                    if (EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt].Identifiant == 7 || EchequierVirtuel[PosRoi[1], PosRoi[0] - cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            LigneG = false;
                        }
                    }
                }
                if (PosRoi[0] < 8 && PosRoi[1] - cpt > -1 && ColonneH)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]].Identifiant == 7 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0]].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            ColonneH = false;
                        }
                    }
                }
                if (PosRoi[0] > -1 && PosRoi[1] + cpt < 8 && ColonneB)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]].Identifiant == 7 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0]].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            ColonneB = false;
                        }
                    }
                }
                if (PosRoi[0] + cpt < 8 && PosRoi[1] + cpt < 8 && DiaBD)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt].Identifiant == 5 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] + cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            DiaBD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > 0 && PosRoi[1] - cpt > -1 && DiaHG)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt].Identifiant == 5 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] - cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            DiaHG = false;
                        }
                    }
                }
                if (PosRoi[0] + cpt > 0 && PosRoi[0] + cpt < 8 && PosRoi[1] - cpt > -1 && PosRoi[0] - cpt < 8 && DiaHD)
                {
                    if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt].Identifiant == 5 || EchequierVirtuel[PosRoi[1] - cpt, PosRoi[0] + cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            DiaHD = false;
                        }
                    }
                }
                if (PosRoi[0] - cpt > -1 && PosRoi[1] + cpt < 8 && DiaBG)
                {
                    if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt] != null)
                    {
                        if (EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt].Identifiant == 5 || EchequierVirtuel[PosRoi[1] + cpt, PosRoi[0] - cpt].Identifiant == 11)
                        {
                            return false;
                        }
                        else
                        {
                            DiaBG = false;
                        }
                    }
                }
            }
            return true;
        }
        public static void VerifEchec(Pieces[,] Echiquier)
        {
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    if (Echiquier[colonne, ligne] != null)
                    {
                        if (Echiquier[colonne, ligne].Identifiant % 2 == 0)
                        {
                            if (!EchecRoiNoir(Echiquier, ligne, colonne, ligne, colonne))
                            {
                                EchecNoir = true;
                            }
                            else
                            {
                                EchecNoir = false;
                            }
                        }
                        if (Echiquier[colonne, ligne].Identifiant % 2 != 0)
                        {
                            if (!EchecRoiBlanc(Echiquier, ligne, colonne, ligne, colonne))
                            {
                                EchecBlanc = true;
                            }
                            else
                            {
                                EchecBlanc = false;
                            }
                        }
                    }
                }
            }
        }
        public static void VerifMat(Pieces[,] Echiquier)
        {
            int[] MovPossible = new int[2]; // 0 : Blanc et 1 : Noir$
            int[] Position = new int[2];
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    if (Echiquier[ligne, colonne] != null)
                    {
                        Position[0] = colonne;
                        Position[1] = ligne;
                        VerifMatetPredictions(Echiquier, Position, false, null, MovPossible);
                    }
                }
            }
            if(MovPossible[0] == 0)
            {
                Pieces.MatBlanc = true;
            }
            if (MovPossible[1] == 0)
            {
                Pieces.MatNoir = true;
            }
        }
        public static void VerifMatetPredictions(Pieces[,] Echiquier, int[] position, bool predoumat, JeuEchec Graph, int[] Mouvements)
        {
            #region Prédictions Pion Blanc
            if (Echiquier[position[1], position[0]].Identifiant == 1)
            {
                if (position[1] > 0 && position[1] < 7)
                {
                    if (Echiquier[position[1] - 1, position[0]] == null)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] - 1))
                        {
                            if (!predoumat)
                            {
                                Mouvements[0]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] - 1);
                            }
                        }
                        if (Echiquier[position[1], position[0]].Mouvement == false)
                        {
                            if (Echiquier[position[1] - 2, position[0]] == null && Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] - 2))
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - 2);
                                }
                            }
                        }
                    }
                }
                if (position[0] > 0 && position[0] < 8 && position[1] < 7 && position[1] > 0)
                {
                    if (Echiquier[position[1] - 1, position[0] - 1] != null)
                    {
                        if (Echiquier[position[1] - 1, position[0] - 1].Identifiant % 2 == 0 && Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1] - 1))
                        {
                            if (!predoumat)
                            {
                                Mouvements[0]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0] - 1, position[1] - 1);
                            }
                        }
                    }
                }
                if (position[0] > -1 && position[0] < 7 && position[1] < 7 && position[1] > 0)
                {
                    if (Echiquier[position[1] - 1, position[0] + 1] != null)
                    {
                        if (Echiquier[position[1] - 1, position[0] + 1].Identifiant % 2 == 0 && Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1] - 1))
                        {
                            if (!predoumat)
                            {
                                Mouvements[0]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0] + 1, position[1] - 1);
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Pion Noir
            else if (Echiquier[position[1], position[0]].Identifiant == 2)
            {
                if (position[1] > 0 && position[1] < 7)
                {
                    if (Echiquier[position[1] + 1, position[0]] == null) //Si case libre alors peut avance d'une case
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] + 1))
                        {
                            if (!predoumat)
                            {
                                Mouvements[1]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] + 1);
                            }
                        }
                        if (Echiquier[position[1], position[0]].Mouvement == false) //Si 1er mouvement et case vide alors peut avancer de deux cases
                        {
                            if (Echiquier[position[1] + 2, position[0]] == null && Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] + 2))
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + 2);
                                }
                            }
                        }
                    }
                }
                if (position[0] > 0 && position[0] < 8) //Vérification à gauche
                {
                    if (Echiquier[position[1] + 1, position[0] - 1] != null)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] - 1].Identifiant % 2 != 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                if (position[0] > -1 && position[0] < 7) //Vérification à droite
                {
                    if (Echiquier[position[1] + 1, position[0] + 1] != null)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] + 1].Identifiant % 2 != 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] + 1);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Cavalier blanc
            else if (Echiquier[position[1], position[0]].Identifiant == 3)
            {
                #region Déplacement cavalier de 1 à droite
                if (position[0] > -1 && position[0] < 7)
                {
                    if (position[1] > 1 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1] - 2))
                        {
                            if (Echiquier[position[1] - 2, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] - 2, position[0] + 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] - 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] - 2);
                                }
                            }
                        }
                    }
                    if (position[1] > -1 && position[1] < 6)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1] + 2))
                        {
                            if (Echiquier[position[1] + 2, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] + 2, position[0] + 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] + 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] + 2);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 2 à droite
                if (position[0] > -1 && position[0] < 6)
                {
                    if (position[1] > 0 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 2, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] + 2] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] + 2].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 2, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 2, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[1] > 0 && position[1] < 7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 2, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] + 2] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] + 2].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 2, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 2, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 1 à gauche
                if (position[0] > 0 && position[0] < 8)
                {
                    if (position[1] > 1 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1] - 2))
                        {
                            if (Echiquier[position[1] - 2, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] - 2, position[0] - 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] - 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] - 2);
                                }
                            }
                        }
                    }
                    if (position[1] > -1 && position[1] < 6)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1] + 2))
                        {
                            if (Echiquier[position[1] + 2, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] + 2, position[0] - 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] + 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] + 2);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 2 à gauche
                if (position[0] > 2 && position[0] < 8)
                {
                    if (position[1] > 0 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 2, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] - 2] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] - 2].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 2, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 2, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[1] > 0 && position[1] < 7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 2, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] - 2] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] - 2].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 2, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 2, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region Prédictions Cavalier noir
            else if (Echiquier[position[1], position[0]].Identifiant == 4)
            {
                #region Déplacement cavalier de 1 à droite
                if (position[0] > -1 && position[0] < 7)
                {
                    if (position[1] > 1 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1] - 2))
                        {
                            if (Echiquier[position[1] - 2, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] - 2, position[0] + 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] - 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] - 2);
                                }
                            }
                        }
                    }
                    if (position[1] > -1 && position[1] < 6)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1] + 2))
                        {
                            if (Echiquier[position[1] + 2, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] + 2, position[0] + 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] + 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] + 2);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 2 à droite
                if (position[0] > -1 && position[0] < 6)
                {
                    if (position[1] > 0 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 2, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] + 2] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] + 2].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 2, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 2, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[1] > 0 && position[1] < 7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 2, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] + 2] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] + 2].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 2, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 2, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 1 à gauche
                if (position[0] > 0 && position[0] < 8)
                {
                    if (position[1] > 1 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1] - 2))
                        {
                            if (Echiquier[position[1] - 2, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] - 2, position[0] - 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] - 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] - 2);
                                }
                            }
                        }
                    }
                    if (position[1] > -1 && position[1] < 6)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1] + 2))
                        {
                            if (Echiquier[position[1] + 2, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] + 2, position[0] - 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] + 2);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] + 2);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Déplacement cavalier de 2 à gauche
                if (position[0] > 2 && position[0] < 8)
                {
                    if (position[1] > 0 && position[1] < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 2, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] - 2] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] - 2].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 2, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 2, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[1] > 0 && position[1] < 7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 2, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] - 2] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] - 2].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 2, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 2, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region Prédictions Fou blanc
            else if (Echiquier[position[1], position[0]].Identifiant == 5)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] + cpt < 8 && D1)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] + cpt] != null)
                            {
                                D1 = false;
                                if (Echiquier[position[1] + cpt, position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] - cpt > -1 && D2)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1] - cpt, position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] + cpt] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] - cpt] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Fou Noir
            else if (Echiquier[position[1], position[0]].Identifiant == 6)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] + cpt < 8 && D1)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] + cpt] != null)
                            {
                                if (Echiquier[position[1] + cpt, position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                    }
                                }
                                D1 = false;
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] - cpt > -1 && D2)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1] - cpt, position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] + cpt] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] - cpt] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Tour blanc
            else if (Echiquier[position[1], position[0]].Identifiant == 7)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] < 8 && D1)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + cpt] != null)
                            {
                                D1 = false;
                                if (Echiquier[position[1], position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] > -1 && D2)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1], position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0]] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0]].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0]] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0]].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Tour Noir
            else if (Echiquier[position[1], position[0]].Identifiant == 8)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] < 8 && D1)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + cpt] != null)
                            {
                                if (Echiquier[position[1], position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1]);
                                    }
                                }
                                D1 = false;
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] > -1 && D2)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1], position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0]] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0]].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0]] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0]].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Reine blanc
            else if (Echiquier[position[1], position[0]].Identifiant == 11)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true, D5 = true, D6 = true, D7 = true, D8 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] < 8 && D1)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + cpt] != null)
                            {
                                D1 = false;
                                if (Echiquier[position[1], position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] > -1 && D2)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1], position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0]] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0]].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0]] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0]].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] + cpt < 8 && D5)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] + cpt] != null)
                            {
                                D5 = false;
                                if (Echiquier[position[1] + cpt, position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] - cpt > -1 && D6)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] - cpt] != null)
                            {
                                D6 = false;
                                if (Echiquier[position[1] - cpt, position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] - cpt > -1 && D7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] + cpt] != null)
                            {
                                D7 = false;
                                if (Echiquier[position[1] - cpt, position[0] + cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] + cpt < 8 && D8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] - cpt] != null)
                            {
                                D8 = false;
                                if (Echiquier[position[1] + cpt, position[0] - cpt].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Reine Noir
            else if (Echiquier[position[1], position[0]].Identifiant == 12)
            {
                bool D1 = true, D2 = true, D3 = true, D4 = true, D5 = true, D6 = true, D7 = true, D8 = true;
                for (int cpt = 1; cpt < 8; cpt++)
                {
                    if (position[0] + cpt < 8 && position[1] < 8 && D1)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + cpt] != null)
                            {
                                if (Echiquier[position[1], position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1]);
                                    }
                                }
                                D1 = false;
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] > -1 && D2)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - cpt] != null)
                            {
                                D2 = false;
                                if (Echiquier[position[1], position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] < 8 && position[1] - cpt > -1 && D3)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0]] != null)
                            {
                                D3 = false;
                                if (Echiquier[position[1] - cpt, position[0]].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] > -1 && position[1] + cpt < 8 && D4)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0]] != null)
                            {
                                D4 = false;
                                if (Echiquier[position[1] + cpt, position[0]].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0], position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] + cpt < 8 && D5)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] + cpt] != null)
                            {
                                if (Echiquier[position[1] + cpt, position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                    }
                                }
                                D5 = false;
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] - cpt > -1 && D6)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] - cpt] != null)
                            {
                                D6 = false;
                                if (Echiquier[position[1] - cpt, position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] + cpt < 8 && position[1] - cpt > -1 && D7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + cpt, position[1] - cpt))
                        {
                            if (Echiquier[position[1] - cpt, position[0] + cpt] != null)
                            {
                                D7 = false;
                                if (Echiquier[position[1] - cpt, position[0] + cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + cpt, position[1] - cpt);
                                }
                            }
                        }
                    }
                    if (position[0] - cpt > -1 && position[1] + cpt < 8 && D8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - cpt, position[1] + cpt))
                        {
                            if (Echiquier[position[1] + cpt, position[0] - cpt] != null)
                            {
                                D8 = false;
                                if (Echiquier[position[1] + cpt, position[0] - cpt].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - cpt, position[1] + cpt);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Prédictions Roi blanc
            else if (Echiquier[position[1], position[0]].Identifiant == 9)
            {
                #region Ligne supérieure
                if (position[1] - 1 < 8 && position[1] - 1 > 0)
                {
                    if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] - 1))
                    {
                        if (Echiquier[position[1] - 1, position[0]] != null)
                        {
                            if (Echiquier[position[1] - 1, position[0]].Identifiant % 2 == 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - 1);
                                }
                            }
                        }
                        else
                        {
                            if (!predoumat)
                            {
                                Mouvements[0]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] - 1);
                            }
                        }
                    }
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] - 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] + 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] - 1);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Ligne milieu
                if (position[1] < 8 && position[1] > -1)
                {
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - 1] != null)
                            {
                                if (Echiquier[position[1], position[0] - 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + 1] != null)
                            {
                                if (Echiquier[position[1], position[0] + 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1]);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Ligne inférieure
                if (position[1] + 1 < 7 && position[1] + 1 > -1)
                {
                    if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0], position[1] + 1))
                    {
                        if (Echiquier[position[1] + 1, position[0]] != null)
                        {
                            if (Echiquier[position[1] + 1, position[0]].Identifiant % 2 == 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + 1);
                                }
                            }
                        }
                        else
                        {
                            if (!predoumat)
                            {
                                Mouvements[0]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] + 1);
                            }
                        }
                    }
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] - 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] - 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] + 1);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiBlanc(Echiquier, position[0], position[1], position[0] + 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] + 1].Identifiant % 2 == 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[0]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[0]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region Prédictions Roi Noir
            else if (Echiquier[position[1], position[0]].Identifiant == 10)
            {
                #region Ligne supérieure
                if (position[1] - 1 < 8 && position[1] - 1 > 0)
                {
                    if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] - 1))
                    {
                        if (Echiquier[position[1] - 1, position[0]] != null)
                        {
                            if (Echiquier[position[1] - 1, position[0]].Identifiant % 2 != 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] - 1);
                                }
                            }
                        }
                        else
                        {
                            if (!predoumat)
                            {
                                Mouvements[1]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] - 1);
                            }
                        }
                    }
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] - 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] - 1);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1] - 1))
                        {
                            if (Echiquier[position[1] - 1, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] - 1, position[0] + 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] - 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] - 1);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Ligne milieu
                if (position[1] < 8 && position[1] > -1)
                {
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1]))
                        {
                            if (Echiquier[position[1], position[0] - 1] != null)
                            {
                                if (Echiquier[position[1], position[0] - 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1]);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1]))
                        {
                            if (Echiquier[position[1], position[0] + 1] != null)
                            {
                                if (Echiquier[position[1], position[0] + 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1]);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1]);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Ligne inférieure
                if (position[1] + 1 < 7 && position[1] + 1 > -1)
                {
                    if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0], position[1] + 1))
                    {
                        if (Echiquier[position[1] + 1, position[0]] != null)
                        {
                            if (Echiquier[position[1] + 1, position[0]].Identifiant % 2 != 0)
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0], position[1] + 1);
                                }
                            }
                        }
                        else
                        {
                            if (!predoumat)
                            {
                                Mouvements[1]++;
                            }
                            else if (predoumat)
                            {
                                Graph.Bordure(position[0], position[1] + 1);
                            }
                        }
                    }
                    if (position[0] - 1 > 0 && position[0] - 1 < 8)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] - 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] - 1] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] - 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] - 1, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] - 1, position[1] + 1);
                                }
                            }
                        }
                    }
                    if (position[0] + 1 > 0 && position[0] + 1 < 7)
                    {
                        if (Pieces.EchecRoiNoir(Echiquier, position[0], position[1], position[0] + 1, position[1] + 1))
                        {
                            if (Echiquier[position[1] + 1, position[0] + 1] != null)
                            {
                                if (Echiquier[position[1] + 1, position[0] + 1].Identifiant % 2 != 0)
                                {
                                    if (!predoumat)
                                    {
                                        Mouvements[1]++;
                                    }
                                    else if (predoumat)
                                    {
                                        Graph.Bordure(position[0] + 1, position[1] + 1);
                                    }
                                }
                            }
                            else
                            {
                                if (!predoumat)
                                {
                                    Mouvements[1]++;
                                }
                                else if (predoumat)
                                {
                                    Graph.Bordure(position[0] + 1, position[1] + 1);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
        }
        #endregion
    }
}
