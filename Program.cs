/*
 * Vytvořeno aplikací SharpDevelop.
 * Uživatel: Edge
 * Datum: 20.11.2014
 * Čas: 20:45
 * 
 * Tento template můžete změnit pomocí Nástroje | Možnosti | Psaní kódu | Upravit standardní hlavičky souborů.
 */
using System;

namespace Dimenze_matice
{
	class Program
	{
		public static void Main(string[] args)
		{
			char konec;
			do{
//				char homog;
//				Console.WriteLine("Typ matice: (H)homogenní (N)nehomogenní");
//				do{
//					homog = Console.ReadKey().KeyChar;
//				}while(homog!='h' && homog!='n' && homog!='H' && homog!='N');
//				
//				if (homog=='h' || homog=='H') {
//					Console.Clear();
//					Console.ForegroundColor=ConsoleColor.Green;
//					Console.WriteLine("Homogenní");
//					Console.ForegroundColor=ConsoleColor.White;
//				}
//				
				Console.WriteLine("matice M x N");
				Console.Write("M = ");
				int m = Convert.ToInt32(Console.ReadLine());
				Console.Write("N = ");
				int n = Convert.ToInt32(Console.ReadLine());
				double[,] matice;
					
				matice = new double[m,n];
				
				Console.WriteLine("Vložte data po řádcích (používejte desetinou čárku)");
				for (int i = 0; i < m; i++) {
					for (int j = 0; j < n; j++) {
						Console.Write("{0}x{1}:", i+1,j+1);
						matice[i,j] = Convert.ToDouble(Console.ReadLine());
					}
				} //vstup dat
				Console.Clear();
				Console.WriteLine("vstup: matice {0}x{1}\n",m,n);
				
				for (int i = 0; i < m; i++) {
					for (int j = 0; j < n; j++) {
						Console.Write("{0}\t", matice[i,j]);
					}
					Console.WriteLine("");
				} //vypsání matice
				Console.WriteLine("\n-----------------");
				
				/*BEGIN Uprava matice*/
				double[] vektor;
				vektor = new double[n];
								
				for (int k = 0; k < n; k++) {
					double max=0;
					int maxint=0;
					for (int l = k; l < m; l++) {
						if (max<Math.Abs(matice[l,k])) {
							max=matice[l,k];
							maxint = l;
						}
					} //nalezení vedoucího prvnku
															
					if (k<m && maxint!=0) {
						for (int i = 0; i < n; i++) {
							vektor[i]=matice[k,i];
							matice[k,i]=matice[maxint,i];
							matice[maxint,i]=vektor[i];
							
						}
					} //umístění největšího vedoucího prvku na první řádek
					
					for (int i = k+1; i < m; i++) {
						double a = matice[i,k];
						for (int j = k; j < n; j++) {
							matice[i,j]=matice[k,j]*a-matice[i,j]*matice[k,k];
						}
					} //samotná úprava v matici
				}
				/*END Uprava matice*/
				
				int dimenze = m;
				bool rovno=true;
												
				Console.WriteLine();
				for (int i = 0; i < m; i++) {
					for (int j = 0; j < n; j++) {
						Console.Write("{0}\t", matice[i,j]);
						vektor[j]=matice[i,j];
					}
					Console.WriteLine();
					rovno=true;
					for (int j = 0; j < n; j++) {
						rovno &= vektor[j] == 0;
					}
					if (rovno == true) {
						dimenze--;
					}
				}
				
				
				Console.WriteLine("  dim(A) = {0}",dimenze);
				Console.Write("\n  Ukončit? (Esc) Opakovat? (Enter) :");
				
				do{
					konec = Console.ReadKey().KeyChar;
					
				}while(konec!=13 && konec!=27);
				//konec = Console.ReadLine();
				Console.Clear();
				
				}
			while(konec != 27);
		}
	}
}