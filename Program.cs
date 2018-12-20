using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] morp = { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            int I = 0, J = 0;
            string campGagnant="match nul!";
            Boolean traitJoueur = true;

            Grid(morp);



            while (!(VerifyVictory(morp,ref campGagnant)) && !(VerifyFull(morp)))
            {
                if (traitJoueur == true)
                {
                    do
                    {
                        Console.WriteLine("Rentrez votre première coordonnée (entre 0 et 2)");
                        I = PlayerCoord();
                        Console.WriteLine("Rentrez votre deuxième coordonnée (entre 0 et 2)");
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
                    do
                    {
                        I = CompCoord();
                        J = CompCoord();
                        if (VerifyCoord(I, J, morp))
                        {
                            Console.WriteLine("je rééssaye");
                        }
                        else
                        {
                            morp[I, J] = "O";
                            break;
                        }
                    } while (VerifyCoord(I, J, morp));
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

        //Fonction d'affichage de la grille
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
    }
}
