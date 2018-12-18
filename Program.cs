using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] morp = { { "X", "X", " " }, { " ", "X", "O" }, { " ", " ", " " } };
            int I = 0, J = 0;
            string campGagnant="personne";

            grid(morp);



            while (!(verifyVictory(morp,ref campGagnant)) || !(verifyFull(morp)))
            {
                do
                {
                    Console.WriteLine("verifyVictory vaut : {0}", verifyVictory(morp, ref campGagnant));
                    Console.WriteLine("verifyFull vaut : {0}", verifyFull(morp));
                    Console.WriteLine("Rentrez votre première coordonnée (entre 0 et 2)");
                    I = playerCoord();
                    Console.WriteLine("Rentrez votre deuxième coordonnée (entre 0 et 2)");
                    J = playerCoord();
                    if (verifyCoord(I, J, morp))
                    {
                        Console.WriteLine("Il y a déjà un symbole ici");
                    }
                    else
                    {
                        morp[I, J] = "X";
                        break;
                    }
                } while (verifyCoord(I, J, morp));

                grid(morp);

                do
                {
                    I = compCoord();
                    J = compCoord();
                    if (verifyCoord(I, J, morp))
                    {
                        Console.WriteLine("je rééssaye");
                    }
                    else
                    {
                        morp[I, J] = "O";
                        break;
                    }
                } while (verifyCoord(I, J, morp));

                grid(morp);

            }
            Console.WriteLine("Le gagna");

        }
        //Fonction qui demande une coord au joueur
        static int playerCoord()
        {
            int a = -1;

            while ((a < 0) || (a > 2))
            {
                a = Convert.ToInt32(Console.ReadLine());
            }
            return a;
        }

        //Fonction qui fait choisir une coordonnée à l'ordi
        static int compCoord()
        {
            Random rand = new Random();
            return rand.Next(0, 3);
        }

        //Fonction d'affichage de la grille
        static void grid(string[,] tab)
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
        }

        //Fonction qui vérifie si un un élément de la grille est plein
        static bool verifyCoord(int a, int b, string[,] tab)
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
        static bool verifyVictory(string[,] tab, ref string campGagnant)
        {
            int comptX = 0;
            int comptO = 0;

            // Lignes
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == "X") { comptX++; }
                    if (tab[i, j] == "O") { comptO++; }
                }
                Console.WriteLine("sur la ligne {0}", i);
                Console.WriteLine("comptX vaut :{0}", comptX);
                Console.WriteLine("comptO vaut :{0}", comptO);

                if (comptX == tab.GetLength(1))
                {
                    campGagnant = "X";
                    return true;
                }
                if (comptO == tab.GetLength(1))
                {
                    campGagnant = "O";
                    return true;
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
                Console.WriteLine("sur la colonne {0}", j);
                Console.WriteLine("comptX vaut :{0}", comptX);
                Console.WriteLine("comptO vaut :{0}", comptO);

                if (comptX == tab.GetLength(1))
                {
                    campGagnant = "X";
                    return true;
                }
                if (comptO == tab.GetLength(1))
                {
                    campGagnant = "O";
                    return true;
                }
                comptX = 0;
                comptO = 0;
            }
            //Diagonales à implémenter
            return false;
        }

        //Fonction qui vérifie si la grille est pleine
        static bool verifyFull(string[,] tab)
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
