/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 8/19/2021
 * Time: 11:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pairwise
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*string[] items = { "one", "two", "three" };
string temp = items[1]; // temp = "two"
items[1] = items[2]; // items[1] = "three"
items[2] = temp; // items[2] = "two"

// items is now
// { "one", "three", "two" }*/
			
			Console.Write("Enter array size :");
			int n = int.Parse(Console.ReadLine());
			int [] array = new int[n];
			
			Console.WriteLine("Enter "+ n + " positve whole number:");
			for(int i=0; i<n ; i++){
				array[i] = int.Parse(Console.ReadLine());
			}
			
			int length = array.Length;
			
			firstsum(length);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		static int  firstsum(int length) // add the original data entry
		{
			int[] sum ={ };
			int maxtotal = 0 ;
			int values = 0;
			
			for (int i= 0; i<length;i++)
			{	
				values =sum[i];
				if(values>)
				for(int j = i+1 ; j<length;j++)
				{
					array[j]=array[i]+array[j];
					sum[i]= array[j];
				}		
			}
			
			return sum;
		}
		
		
		static int compare(int length)
		{
			
		}
		
		
	}
}