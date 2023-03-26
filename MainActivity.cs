using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Widget;
using System;
using Android.Content;
using Android.Text;
using System.Collections.Generic;
using System.Linq;


namespace MyPassword
{
    [Activity(Label = "@string/app_name" , MainLauncher = false)]

    public class MainActivity : AppCompatActivity
    {
        public int cplx;
        public string subj;
        public TextView tv1;
        public TextView tv3;
        public TextView tv4;
        public int x;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            cplx = Intent.GetIntExtra("Complexite", 8);
            subj = Intent.GetStringExtra("Nom");
            //Creation du dictionnaire contenant les valeurs des lettres en majuscules
            Dictionary<Char, int> val = new Dictionary<Char, int>
            {
                { 'A', 0 },
                { 'B', 1 },
                { 'C', 2 },
                { 'D', 3 },
                { 'E', 4 },
                { 'F', 5 },
                { 'G', 6 },
                { 'H', 7 },
                { 'I', 8 },
                { 'J', 9 },
                { 'K', 10 },
                { 'L', 11 },
                { 'M', 12 },
                { 'N', 13 },
                { 'O', 14 },
                { 'P', 15 },
                { 'Q', 16 },
                { 'R', 17 },
                { 'S', 18 },
                { 'T', 19 },
                { 'U', 20 },
                { 'V',21 },
                { 'W', 22 },
                { 'X', 23 },
                { 'Y', 24 },
                { 'Z', 25 }
            };

            //Fin du dictionnaire

            tv1 = FindViewById<TextView>(Resource.Id.textView1);
            tv3 = FindViewById<TextView>(Resource.Id.textView3);
            tv4 = FindViewById<TextView>(Resource.Id.textView4) ;
            tv1.Text = "Complexité: " + cplx;
            tv4.Text = "Le password de" + " " + subj + " " +"est :";
            EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            et1.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            Button b1 = FindViewById<Button>(Resource.Id.button1);
            b1.Click += delegate
            {
              
                if (cplx == 9)
                {
                    //Matrice clé de valeur
                    int[][] m = new int[][]
                        {
                        new int[] { 1, 2, 1},
                        new int[] { 2, 1, 3},
                        new int[] { 2, 4,2 }
                        };
                    List<char> lettres = new List<char>();
                    List<char> valchar = new List<char>();
                    List<int> numb = new List<int>();
                    //Initialisation de la matrice venant du mot donné
                    Console.WriteLine(et1.Text.ToString());

                    foreach (char mt in ((et1.Text.ToString()).ToUpper()).Trim())
                    {
                               
                      numb.Add(val[mt]);

                    }
                    Console.WriteLine(numb.Count);
                         
                    int[][] w = new int[][]
                    {
                         new int[] {numb[0], numb[1],  numb[2]},
                         new int[] { numb[3], numb[4],  numb[5]},
                         new int[] { numb[6] , numb[7], numb[8]}
                    };
                        

                    //Fin de l'initialisation de la matrice

                    //Produit de Matrice
                    int[][] wm = MatrixProduct(w,m);
                    for (int c = 0; c < wm.Length; ++c)
                    {
                        for (int d = 0; d < wm[c].Length; ++d)
                        {
                            bool ValueExists =val.ContainsValue(wm[c][d] % 26);
                            if (ValueExists ==true)
                            {
                                char key = val.FindKeyByValue(wm[c][d] % 26);
                                valchar.Add(key);
                            }  
                        }
                            
                    }
                    //Fin du produit de matrices
                   
                    
                    tv3.Text = "" + valchar[0] + valchar[1] + valchar[2] + valchar[3] + valchar[4] + valchar[5] + valchar[6] + valchar[7] + valchar[8];


                }
              
                
            };
        }
        //Methode permettant d'instancier des tableaux
        static int[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s
            // do error checking here?
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new int[cols]; // auto init to 0.0
            return result;
        }
        //Méthode de calcul de produit de 2 matrices
        static int[][] MatrixProduct(int[][] matrixA,int[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
             int[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
            return result;
        }
       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public static class Extensions
    {
        public static K FindKeyByValue<K, V>(this Dictionary<K, V> dict, V value)
        {
            Dictionary<V, K> revDict = dict.ToDictionary(pair => pair.Value, pair => pair.Key);
            return revDict[value];
        }
    }
}