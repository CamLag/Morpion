using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] morp = { { " ", " ", " "}, { " ", " ", " " }, { " ", " ", " " } };
            int I = 0, J = 0;
            string campGagnant= "Match nul!";
            Boolean traitJoueur = true;

            Grid(morp);

            while (!(VerifyVictory(morp,ref campGagnant)) && !(VerifyFull(morp)))
            {
                if (traitJoueur == true)
                {
                    do
                    {
                        Console.WriteLine("Rentrez la coordonnée de la ligne (entre 0 et 2)");
                        I = PlayerCoord();
                        Console.WriteLine("Rentrez la coordonnée de la colonne (entre 0 et 2)");
                        J = PlayerCoord();
                        if (VerifyCoord(I, J, morp))
                        {
                            Console.WriteLine("Il y a déjà un symbole ici");
                        }
                        else
                        {
                            morp[I, J] = "X";
                            break;
                        }
                    } while (VerifyCoord(I, J, morp));
                    traitJoueur = false;
                    Grid(morp);
                }
                else
                {
                    MorpionIA(morp);

                    traitJoueur = true;
                    Grid(morp);
                }
            }
            Console.WriteLine(campGagnant);
        }

        //Fonction qui demande une coord au joueur
        static int PlayerCoord()
        {
            int a = -1;

            while ((a < 0) || (a > 2))
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ce n'est pas un nombre!");
                }
                if ((a < -1) || (a > 2)) Console.WriteLine("Votre coordonnée doit être comprise entre 0 et 2!");
            }
            return a;
        }

        //Fonction qui fait choisir une coordonnée à l'ordi
        static int CompCoord()
        {
            Random rand = new Random();
            return rand.Next(0, 3);
        }

        //Fonction d'affichage de la grille en strings
        static void Grid(string[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write("|");
                    Console.Write(tab[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("");
        }

        //Fonction d'affichage de la grille en float
        static void Grid(float[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write("|");
                    Console.Write(tab[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("");
        }

        //Fonction qui vérifie si un un élément de la grille est plein
        static bool VerifyCoord(int a, int b, string[,] tab)
        {
            if (tab[a, b] == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Fonction qui vérifie si un joueur a gagné
        static bool VerifyVictory(string[,] tab, ref string campGagnant)
        {
            int comptX = 0;
            int comptO = 0;
            Boolean retour = false;
            campGagnant = "Match nul!";
            // Lignes
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == "X") { comptX++; }
                    if (tab[i, j] == "O") { comptO++; }
                }

                if (comptX == tab.GetLength(1))
                {
                    campGagnant = "Vous avez gagné!";
                    retour = true;
                }
                if (comptO == tab.GetLength(1))
                {
                    campGagnant = "J'ai gagné!";
                    retour = true;
                }
                comptX = 0;
                comptO = 0;
            }
            // Colonnes
            for (int j = 0; j < tab.GetLength(0); j++)
            {
                for (int i = 0; i < tab.GetLength(1); i++)
                {
                    if (tab[i, j] == "X") { comptX++; }
                    if (tab[i, j] == "O") { comptO++; }
                }
                if (comptX == tab.GetLength(1))
                {
                    campGagnant = "Vous avez gagné!";
                    retour = true;
                }
                if (comptO == tab.GetLength(1))
                {
                    campGagnant = "J'ai gagné!";
                    retour = true;
                }
                comptX = 0;
                comptO = 0;
            }
            //Diagonale 1
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, i] == "X") { comptX++; }
                if (tab[i, i] == "O") { comptO++; }
            }
            if (comptX == tab.GetLength(1))
            {
                campGagnant = "Vous avez gagné!";
                retour = true;
            }
            if (comptO == tab.GetLength(1))
            {
                campGagnant = "J'ai gagné!";
                retour = true;
            }

            comptX = 0;
            comptO = 0;

            //Diagonale 2
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, tab.GetLength(0) - i - 1] == "X") { comptX++; }
                if (tab[i, tab.GetLength(0) - i - 1] == "O") { comptO++; }
            }
            if (comptX == tab.GetLength(1))
            {
                campGagnant = "Vous avez gagné!";
                retour = true;
            }
            if (comptO == tab.GetLength(1))
            {
                campGagnant = "J'ai gagné!";
                retour = true;
            }

            comptX = 0;
            comptO = 0;

            return retour;
        }

        //Fonction qui vérifie si la grille est pleine
        static bool VerifyFull(string[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == " ") return false;
                }
            }
            return true;
        }

        //Affichage de fullList (pour l'IA)
        static void ListAffiche(List<List<int[]>> doubleListe)
        {
            Console.WriteLine("Voici fullList:");
            foreach (List<int[]> A in doubleListe)
            {
                Console.Write("{");
                foreach (int[] B in A)
                {
                    Console.Write("[{0}, {1}] ", B[0], B[1]);
                }
                Console.Write("}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //IA
        static void MorpionIA(string[,] tab)
        {
            float[,] probTableWin = new float[tab.GetLength(0), tab.GetLength(1)];
            float[,] probTableDraw = new float[tab.GetLength(0), tab.GetLength(1)];
            String[,] testTable = new string[tab.GetLength(0), tab.GetLength(1)];
            List<int[]> possibleCoord = new List<int[]>();

            int I=0, J=0;
            String campGagnant = "";
            String trait = "O";

            Array.Copy(tab, testTable, tab.GetLength(0) * tab.GetLength(1));

            //On créé une liste des coordonnées vides de la table
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i,j] == " ")
                    {
                        possibleCoord.Add(new int[] {i,j});
                    }
                }
            }

            /*foreach (int[] A in possibleCoord)
            {
                Console.WriteLine("[{0}, {1}]", A[0], A[1]);
            }*/

            //on créé l'ensemble des combinaisons d'ordres possibles des éléments de cette liste 
            List<List<int[]>> fullList = new List<List<int[]>>();

            fullList.Add(possibleCoord.GetRange(0,1));

            int compt = fullList.Count;
            for (int i = 1; i < possibleCoord.Count; i++)
            {
                int l = 0;
                while (l < i)
                {
                    for (int j = 0; j < compt; j++)
                    {
                        fullList.Add(fullList[j].GetRange(0, fullList[j].Count));
                    }
                    l++;
                }
                
                int pos = 0;
                int compteur = 0;

                for (int k = 0; k < fullList.Count; k++)
                {
                    fullList[k].Insert(pos, possibleCoord[i]); 
                    compteur++;
                    if (compteur == compt)
                    {
                        pos++;
                        compteur = 0;
                    }
                }
                compt = fullList.Count;
            }

            //On simule des parties selon toutes les combinaisons
            for (int i = 0; i < fullList.Count; i++)
            {
                Array.Copy(tab, testTable, tab.GetLength(0) * tab.GetLength(1));

                trait = "O";
                for (int j = 0; j < fullList[0].Count; j++)
                {

                    testTable[fullList[i][j][0], fullList[i][j][1]] = trait;
                    trait = trait == "X" ? "O" : "X";
                    if (VerifyVictory(testTable, ref campGagnant))
                    {
                        if (campGagnant == "J'ai gagné!")
                        {
                            probTableWin[fullList[i][0][0], fullList[i][0][1]]++;

                        }
                        if (campGagnant == "Match nul!")
                        {
                            probTableDraw[fullList[i][0][0], fullList[i][0][1]]++;

                        }
                        break;
                    }
                }
            }

            float maxProbWin = 0;

            for (int i = 0; i < probTableWin.GetLength(0); i++)
            {
                for (int j = 0; j < probTableWin.GetLength(0); j++)
                {
                    if (probTableWin[i, j] > maxProbWin)
                    {
                        maxProbWin = probTableWin[i, j];
                    }
                }
            }

            for (int i = 0; i < probTableWin.GetLength(0); i++)
            {
                for (int j = 0; j < probTableWin.GetLength(0); j++)
                {
                    if ((probTableWin[i, j] == maxProbWin)&&(!VerifyCoord(i, j, tab)))
                    {
                        I = i;
                        J = j;
                    }
                }
            }

            float maxProbDraw = 0;

            for (int i = 0; i < probTableDraw.GetLength(0); i++)
            {
                for (int j = 0; j < probTableDraw.GetLength(0); j++)
                {
                    if (probTableDraw[i, j] > maxProbDraw)
                    {
                        maxProbDraw = probTableDraw[i, j];
                    }
                }
            }

            for (int i = 0; i < probTableDraw.GetLength(0); i++)
            {
                for (int j = 0; j < probTableDraw.GetLength(0); j++)
                {
                    if ((probTableDraw[i, j] == maxProbDraw) && (!VerifyCoord(i, j, tab)))
                    {
                        I = i;
                        J = j;
                    }
                }
            }
            Grid(probTableWin);
            Grid(probTableDraw);
            tab[I, J] = "O";
        }

    }
    
}
