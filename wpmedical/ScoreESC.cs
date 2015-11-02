using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace wsmedical
{
    public class ScoreESC
    {
        Dictionary<int, Dictionary<int, Dictionary<int, int[,]>>> myArrays = new Dictionary<int, Dictionary<int, Dictionary<int, int[,]>>>();
        Dictionary<int, Dictionary<int, int[,]>> myWomenArrays = new Dictionary<int, Dictionary<int, int[,]>>();
        Dictionary<int, Dictionary<int, int[,]>> myMenArrays = new Dictionary<int, Dictionary<int, int[,]>>();


        Dictionary<int, int[,]> myWomenSmokerArrays = new Dictionary<int, int[,]>();
        Dictionary<int, int[,]> myWomenNonSmokerArrays = new Dictionary<int, int[,]>();
        Dictionary<int, int[,]> myMenSmokerArrays = new Dictionary<int, int[,]>();
        Dictionary<int, int[,]> myMenNonSmokerArrays = new Dictionary<int, int[,]>();

        // Tableau à 2 dimension [ligne,colonne]
        int[,] Array1 = new int[4, 5]; int[,] Array2 = new int[4, 5]; int[,] Array3 = new int[4, 5];
        int[,] Array4 = new int[4, 5]; int[,] Array5 = new int[4, 5]; int[,] Array6 = new int[4, 5];
        int[,] Array7 = new int[4, 5]; int[,] Array8 = new int[4, 5]; int[,] Array9 = new int[4, 5];
        int[,] Array10 = new int[4, 5]; int[,] Array11 = new int[4, 5]; int[,] Array12 = new int[4, 5];
        int[,] Array13 = new int[4, 5]; int[,] Array14 = new int[4, 5]; int[,] Array15 = new int[4, 5];
        int[,] Array16 = new int[4, 5]; int[,] Array17 = new int[4, 5]; int[,] Array18 = new int[4, 5];
        int[,] Array19 = new int[4, 5]; int[,] Array20 = new int[4, 5];



        public ScoreESC()
        {
            // La clé est le sexe, on accéde au tableau par myArrays.get(laValeurDuSexe)
            myArrays.Add(1, myMenArrays);
            myArrays.Add(2, myWomenArrays);

            // La clé est le tabac, on accéde au tableau par ((Hashtable)myArrays.get(laValeurDuSexe)).get(laValeurDuTabac)
            myWomenArrays.Add(1, myWomenSmokerArrays);
            myWomenArrays.Add(0, myWomenNonSmokerArrays);

            // La clé est le tabac, on accéde au tableau par ((Hashtable)myArrays.get(laValeurDuSexe)).get(laValeurDuTabac)
            myMenArrays.Add(1, myMenSmokerArrays);
            myMenArrays.Add(0, myMenNonSmokerArrays);

            // Matrice 1 = Women + Non Smoker + 40
            Array1[3, 0] = 0; Array1[3, 1] = 0; Array1[3, 2] = 0; Array1[3, 3] = 0; Array1[3, 4] = 0;
            Array1[2, 0] = 0; Array1[2, 1] = 0; Array1[2, 2] = 0; Array1[2, 3] = 0; Array1[2, 4] = 0;
            Array1[1, 0] = 0; Array1[1, 1] = 0; Array1[1, 2] = 0; Array1[1, 3] = 0; Array1[1, 4] = 0;
            Array1[0, 0] = 0; Array1[0, 1] = 0; Array1[0, 2] = 0; Array1[0, 3] = 0; Array1[0, 4] = 0;
            myWomenNonSmokerArrays.Add(40, Array1);

            // Matrice 2 = Women + Smoker + 40
            Array2[3, 0] = 0; Array2[3, 1] = 0; Array2[3, 2] = 0; Array2[3, 3] = 0; Array2[3, 4] = 0;
            Array2[2, 0] = 0; Array2[2, 1] = 0; Array2[2, 2] = 0; Array2[2, 3] = 0; Array2[2, 4] = 0;
            Array2[1, 0] = 0; Array2[1, 1] = 0; Array2[1, 2] = 0; Array2[1, 3] = 0; Array2[1, 4] = 0;
            Array2[0, 0] = 0; Array2[0, 1] = 0; Array2[0, 2] = 0; Array2[0, 3] = 0; Array2[0, 4] = 0;
            myWomenSmokerArrays.Add(40, Array2);

            // Matrice 3 = Men + Non Smoker + 40
            Array3[3, 0] = 0; Array3[3, 1] = 1; Array3[3, 2] = 1; Array3[3, 3] = 1; Array3[3, 4] = 1;
            Array3[2, 0] = 0; Array3[2, 1] = 0; Array3[2, 2] = 0; Array3[2, 3] = 1; Array3[2, 4] = 1;
            Array3[1, 0] = 0; Array3[1, 1] = 0; Array3[1, 2] = 0; Array3[1, 3] = 0; Array3[1, 4] = 0;
            Array3[0, 0] = 0; Array3[0, 1] = 0; Array3[0, 2] = 0; Array3[0, 3] = 0; Array3[0, 4] = 0;
            myMenNonSmokerArrays.Add(40, Array3);

            // Matrice 4 = Men + Smoker + 40
            Array4[3, 0] = 1; Array4[3, 1] = 1; Array4[3, 2] = 1; Array4[3, 3] = 2; Array4[3, 4] = 2;
            Array4[2, 0] = 1; Array4[2, 1] = 1; Array4[2, 2] = 1; Array4[2, 3] = 1; Array4[2, 4] = 1;
            Array4[1, 0] = 0; Array4[1, 1] = 1; Array4[1, 2] = 1; Array4[1, 3] = 1; Array4[1, 4] = 1;
            Array4[0, 0] = 0; Array4[0, 1] = 0; Array4[0, 2] = 0; Array4[0, 3] = 1; Array4[0, 4] = 1;
            myMenSmokerArrays.Add(40, Array4);

            // Matrice 5 = Women + Non Smoker + 50
            Array5[3, 0] = 1; Array5[3, 1] = 1; Array5[3, 2] = 1; Array5[3, 3] = 1; Array5[3, 4] = 1;
            Array5[2, 0] = 0; Array5[2, 1] = 0; Array5[2, 2] = 1; Array5[2, 3] = 1; Array5[2, 4] = 1;
            Array5[1, 0] = 0; Array5[1, 1] = 0; Array5[1, 2] = 0; Array5[1, 3] = 0; Array5[1, 4] = 0;
            Array5[0, 0] = 0; Array5[0, 1] = 0; Array5[0, 2] = 0; Array5[0, 3] = 0; Array5[0, 4] = 0;
            myWomenNonSmokerArrays.Add(50, Array5);

            // Matrice 6 = Women + Smoker + 50
            Array6[3, 0] = 1; Array6[3, 1] = 1; Array6[3, 2] = 2; Array6[3, 3] = 2; Array6[3, 4] = 2;
            Array6[2, 0] = 1; Array6[2, 1] = 1; Array6[2, 2] = 1; Array6[2, 3] = 1; Array6[2, 4] = 1;
            Array6[1, 0] = 1; Array6[1, 1] = 1; Array6[1, 2] = 1; Array6[1, 3] = 1; Array6[1, 4] = 1;
            Array6[0, 0] = 0; Array6[0, 1] = 0; Array6[0, 2] = 0; Array6[0, 3] = 1; Array6[0, 4] = 1;
            myWomenSmokerArrays.Add(50, Array6);

            // Matrice 7 = Men + NonSmoker + 50
            Array7[3, 0] = 2; Array7[3, 1] = 2; Array7[3, 2] = 3; Array7[3, 3] = 3; Array7[3, 4] = 4;
            Array7[2, 0] = 1; Array7[2, 1] = 1; Array7[2, 2] = 2; Array7[2, 3] = 2; Array7[2, 4] = 2;
            Array7[1, 0] = 1; Array7[1, 1] = 1; Array7[1, 2] = 1; Array7[1, 3] = 1; Array7[1, 4] = 2;
            Array7[0, 0] = 1; Array7[0, 1] = 1; Array7[0, 2] = 1; Array7[0, 3] = 1; Array7[0, 4] = 1;
            myMenNonSmokerArrays.Add(50, Array7);

            // Matrice 8 = Men + Smoker + 50
            Array8[3, 0] = 4; Array8[3, 1] = 4; Array8[3, 2] = 5; Array8[3, 3] = 6; Array8[3, 4] = 7;
            Array8[2, 0] = 2; Array8[2, 1] = 3; Array8[2, 2] = 3; Array8[2, 3] = 4; Array8[2, 4] = 5;
            Array8[1, 0] = 2; Array8[1, 1] = 2; Array8[1, 2] = 2; Array8[1, 3] = 3; Array8[1, 4] = 3;
            Array8[0, 0] = 1; Array8[0, 1] = 1; Array8[0, 2] = 2; Array8[0, 3] = 2; Array8[0, 4] = 2;
            myMenSmokerArrays.Add(50, Array8);

            // Matrice 9 = Women + Non Smoker + 55
            Array9[3, 0] = 1; Array9[3, 1] = 1; Array9[3, 2] = 2; Array9[3, 3] = 2; Array9[3, 4] = 2;
            Array9[2, 0] = 1; Array9[2, 1] = 1; Array9[2, 2] = 1; Array9[2, 3] = 1; Array9[2, 4] = 1;
            Array9[1, 0] = 1; Array9[1, 1] = 1; Array9[1, 2] = 1; Array9[1, 3] = 1; Array9[1, 4] = 1;
            Array9[0, 0] = 0; Array9[0, 1] = 0; Array9[0, 2] = 1; Array9[0, 3] = 1; Array9[0, 4] = 1;
            myWomenNonSmokerArrays.Add(55, Array9);

            // Matrice 10 = Women + Smoker + 55
            Array10[3, 0] = 3; Array10[3, 1] = 3; Array10[3, 2] = 3; Array10[3, 3] = 4; Array10[3, 4] = 4;
            Array10[2, 0] = 2; Array10[2, 1] = 2; Array10[2, 2] = 2; Array10[2, 3] = 3; Array10[2, 4] = 3;
            Array10[1, 0] = 1; Array10[1, 1] = 1; Array10[1, 2] = 1; Array10[1, 3] = 2; Array10[1, 4] = 2;
            Array10[0, 0] = 1; Array10[0, 1] = 1; Array10[0, 2] = 1; Array10[0, 3] = 1; Array10[0, 4] = 1;
            myWomenSmokerArrays.Add(55, Array10);

            // Matrice 11 = Men + Non Smoker + 55
            Array11[3, 0] = 3; Array11[3, 1] = 4; Array11[3, 2] = 4; Array11[3, 3] = 5; Array11[3, 4] = 6;
            Array11[2, 0] = 2; Array11[2, 1] = 2; Array11[2, 2] = 3; Array11[2, 3] = 3; Array11[2, 4] = 4;
            Array11[1, 0] = 1; Array11[1, 1] = 2; Array11[1, 2] = 2; Array11[1, 3] = 2; Array11[1, 4] = 3;
            Array11[0, 0] = 1; Array11[0, 1] = 1; Array11[0, 2] = 1; Array11[0, 3] = 2; Array11[0, 4] = 2;
            myMenNonSmokerArrays.Add(55, Array11);

            // Matrice 12 = Men + Smoker + 55
            Array12[3, 0] = 6; Array12[3, 1] = 7; Array12[3, 2] = 8; Array12[3, 3] = 10; Array12[3, 4] = 12;
            Array12[2, 0] = 4; Array12[2, 1] = 5; Array12[2, 2] = 6; Array12[2, 3] = 7; Array12[2, 4] = 8;
            Array12[1, 0] = 3; Array12[1, 1] = 3; Array12[1, 2] = 4; Array12[1, 3] = 5; Array12[1, 4] = 6;
            Array12[0, 0] = 2; Array12[0, 1] = 2; Array12[0, 2] = 3; Array12[0, 3] = 3; Array12[0, 4] = 4;
            myMenSmokerArrays.Add(55, Array12);

            // Matrice 13 = Women + Non Smoker + 60
            Array13[3, 0] = 3; Array13[3, 1] = 3; Array13[3, 2] = 3; Array13[3, 3] = 4; Array13[3, 4] = 4;
            Array13[2, 0] = 2; Array13[2, 1] = 2; Array13[2, 2] = 2; Array13[2, 3] = 2; Array13[2, 4] = 3;
            Array13[1, 0] = 1; Array13[1, 1] = 1; Array13[1, 2] = 1; Array13[1, 3] = 2; Array13[1, 4] = 2;
            Array13[0, 0] = 1; Array13[0, 1] = 1; Array13[0, 2] = 1; Array13[0, 3] = 1; Array13[0, 4] = 1;
            myWomenNonSmokerArrays.Add(60, Array13);

            // Matrice 14 = Women + Smoker + 60
            Array14[3, 0] = 5; Array14[3, 1] = 5; Array14[3, 2] = 6; Array14[3, 3] = 7; Array14[3, 4] = 8;
            Array14[2, 0] = 3; Array14[2, 1] = 4; Array14[2, 2] = 4; Array14[2, 3] = 5; Array14[2, 4] = 5;
            Array14[1, 0] = 2; Array14[1, 1] = 2; Array14[1, 2] = 3; Array14[1, 3] = 3; Array14[1, 4] = 4;
            Array14[0, 0] = 1; Array14[0, 1] = 2; Array14[0, 2] = 2; Array14[0, 3] = 2; Array14[0, 4] = 3;
            myWomenSmokerArrays.Add(60, Array14);

            // Matrice 15 = Men + Non Smoker + 60
            Array15[3, 0] = 5; Array15[3, 1] = 6; Array15[3, 2] = 7; Array15[3, 3] = 8; Array15[3, 4] = 9;
            Array15[2, 0] = 3; Array15[2, 1] = 4; Array15[2, 2] = 5; Array15[2, 3] = 5; Array15[2, 4] = 6;
            Array15[1, 0] = 2; Array15[1, 1] = 3; Array15[1, 2] = 3; Array15[1, 3] = 4; Array15[1, 4] = 4;
            Array15[0, 0] = 2; Array15[0, 1] = 2; Array15[0, 2] = 2; Array15[0, 3] = 3; Array15[0, 4] = 3;
            myMenNonSmokerArrays.Add(60, Array15);

            // Matrice 16 = Men + Smoker + 60
            Array16[3, 0] = 10; Array16[3, 1] = 11; Array16[3, 2] = 13; Array16[3, 3] = 15; Array16[3, 4] = 18;
            Array16[2, 0] = 7; Array16[2, 1] = 8; Array16[2, 2] = 9; Array16[2, 3] = 11; Array16[2, 4] = 13;
            Array16[1, 0] = 5; Array16[1, 1] = 5; Array16[1, 2] = 6; Array16[1, 3] = 7; Array16[1, 4] = 9;
            Array16[0, 0] = 3; Array16[0, 1] = 4; Array16[0, 2] = 4; Array16[0, 3] = 5; Array16[0, 4] = 6;
            myMenSmokerArrays.Add(60, Array16);

            // Matrice 17 = Women + Non Smoker + 65
            Array17[3, 0] = 4; Array17[3, 1] = 5; Array17[3, 2] = 6; Array17[3, 3] = 6; Array17[3, 4] = 7;
            Array17[2, 0] = 3; Array17[2, 1] = 3; Array17[2, 2] = 4; Array17[2, 3] = 4; Array17[2, 4] = 5;
            Array17[1, 0] = 2; Array17[1, 1] = 2; Array17[1, 2] = 2; Array17[1, 3] = 3; Array17[1, 4] = 3;
            Array17[0, 0] = 1; Array17[0, 1] = 1; Array17[0, 2] = 2; Array17[0, 3] = 2; Array17[0, 4] = 2;
            myWomenNonSmokerArrays.Add(65, Array17);

            // Matrice 18 = Women + Smoker + 65
            Array18[3, 0] = 9; Array18[3, 1] = 9; Array18[3, 2] = 11; Array18[3, 3] = 12; Array18[3, 4] = 14;
            Array18[2, 0] = 6; Array18[2, 1] = 6; Array18[2, 2] = 7; Array18[2, 3] = 8; Array18[2, 4] = 10;
            Array18[1, 0] = 4; Array18[1, 1] = 4; Array18[1, 2] = 5; Array18[1, 3] = 6; Array18[1, 4] = 7;
            Array18[0, 0] = 3; Array18[0, 1] = 3; Array18[0, 2] = 3; Array18[0, 3] = 4; Array18[0, 4] = 4;
            myWomenSmokerArrays.Add(65, Array18);

            // Matrice 19 = Men + Non Smoker + 65
            Array19[3, 0] = 8; Array19[3, 1] = 9; Array19[3, 2] = 10; Array19[3, 3] = 12; Array19[3, 4] = 14;
            Array19[2, 0] = 5; Array19[2, 1] = 6; Array19[2, 2] = 7; Array19[2, 3] = 8; Array19[2, 4] = 10;
            Array19[1, 0] = 4; Array19[1, 1] = 4; Array19[1, 2] = 5; Array19[1, 3] = 6; Array19[1, 4] = 7;
            Array19[0, 0] = 2; Array19[0, 1] = 3; Array19[0, 2] = 3; Array19[0, 3] = 4; Array19[0, 4] = 5;
            myMenNonSmokerArrays.Add(65, Array19);

            // Matrice 20 = Men + Smoker + 65
            Array20[3, 0] = 15; Array20[3, 1] = 17; Array20[3, 2] = 20; Array20[3, 3] = 23; Array20[3, 4] = 26;
            Array20[2, 0] = 10; Array20[2, 1] = 12; Array20[2, 2] = 14; Array20[2, 3] = 16; Array20[2, 4] = 19;
            Array20[1, 0] = 7; Array20[1, 1] = 8; Array20[1, 2] = 9; Array20[1, 3] = 11; Array20[1, 4] = 13;
            Array20[0, 0] = 5; Array20[0, 1] = 5; Array20[0, 2] = 6; Array20[0, 3] = 8; Array20[0, 4] = 9;
            myMenSmokerArrays.Add(65, Array20);



        }


        public int calculateScoreCVD(int Sexe, int Tabac, int cAge, int cPAS, float cCT)
        {
            int AgeArrondi = -1;

            //if(cAge >= 40 && cAge <= 49) AgeArrondi = 40;
            // [fsb] les plus jeunes ont droit à un score à 0 et pas NA
            if (cAge <= 49) AgeArrondi = 40;
            if (cAge >= 50 && cAge <= 54) AgeArrondi = 50;
            if (cAge >= 55 && cAge <= 59) AgeArrondi = 55;
            if (cAge >= 60 && cAge <= 64) AgeArrondi = 60;
            if (cAge >= 65) AgeArrondi = 65;

            int iCT, iPAS;

            if (cCT < 4) iCT = 0; // CT = 4 -> donc premiere case
            else
            {
                if (cCT > 8) iCT = 4; // CT > 8 donc derniere case
                else iCT = (int)cCT - 4;  // arrondi(X) - 4 pour obtenir l'indice entier
            }

            if (cPAS < 120)
            {
                iPAS = 0;
            }
            else
            {
                if (cPAS > 180) iPAS = 3;
                else iPAS = (cPAS - 120) / 20;
            }

            //System.out.println("AgeArrondi : " + AgeArrondi + " Sexe : " + Sexe + " Tabac : " + Tabac + " PAS: " + iPAS + " CT: " + iCT);

            if (AgeArrondi > 0)
            {
                try
                {
                    Dictionary<int, Dictionary<int, int[,]>> myTabacArray = myArrays[Sexe];
                    Dictionary<int, int[,]> myAgeArray = myTabacArray[Tabac];
                    int[,] myScoreArray = myAgeArray[AgeArrondi];

                    return myScoreArray[iPAS, iCT];
                }
                catch (Exception e)
                {
                    //e.printStackTrace();
                    return 0;
                }
            }
            else
            {
                //System.out.println("Vide");
                return 0;
            }
        }

        public Color getColorFromScore(int ScoreCVD)
        {
            try
            {

                if (ScoreCVD >= 15) return Color.FromArgb(255, 124, 25, 20);
                if (ScoreCVD >= 10 && ScoreCVD <= 14) return Color.FromArgb(255, 183, 52, 32);
                if (ScoreCVD >= 5 && ScoreCVD <= 9) return Color.FromArgb(255, 233, 68, 20);
                if (ScoreCVD >= 3 && ScoreCVD <= 4) return Color.FromArgb(255, 246, 150, 37);
                if (ScoreCVD == 2) return Color.FromArgb(255, 253, 189, 63);
                if (ScoreCVD == 1) return Color.FromArgb(255, 177, 207, 59);
                if (ScoreCVD < 1) return Color.FromArgb(255, 66, 194, 55);
            }
            catch (Exception e)
            {
                return Colors.White;
            }
            return Colors.White;
        }
    }
}