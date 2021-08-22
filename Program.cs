/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 8/19/2021
 * Time: 11:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Pairwise
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<int> arr = new List<int>(); //input array
			List<int> sums = new List<int>(); //initialised array to contain sums
			Dictionary<int, List<int>> sumsAndArrangements = new Dictionary<int, List<int>>(); //init  a dic to map sums to array arrangement
			
			Console.WriteLine("Please enter number of array elements");
			int arrSize = Convert.ToInt32(Console.ReadLine());
			
			while(arrSize != 0)
			{
				Console.WriteLine("Please Enter a nonzero number {0} :" ,arrSize);
				int value = Convert.ToInt32(Console.ReadLine());
				
				//Console.WriteLine("Round "+ arrSize);
				
				arr.Add(value);
				
				arrSize--;
			
			}
			
			List<int>arr1 = new List<int>(); //make a copy of input array
			int counter =0; 
			
			counter = forwardSwap(arr,sums,counter,sumsAndArrangements); //swap left to right
			counter = backwardSwap(arr1,sums,counter,sumsAndArrangements); //swap right to left
			
			arrowHeadBuilder(arr,arr1); // make array arrangement with larger values closer to middle
			
			counter = forwardSwap(arr,sums,counter,sumsAndArrangements); //repeat swap
			counter = backwardSwap(arr1,sums,counter,sumsAndArrangements); //swap reverse swaps
			
			Console.WriteLine("Number of arrangements:"+ counter+"\nNumber of unique arrangements: "+sumsAndArrangements.Count);
			int highestsum = sumsAndArrangements.Keys.Max();
			Console.WriteLine("Highest sum is: "+highestsum +"\nArray arrangement with this sum: "+sumsAndArrangements[highestsum]);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		 
		private static int backwardSwap (List<int>arr1, List <int> sums, int counter, Dictionary<int,List<int>>sumsAndArrangements)
		{
			for(int j = arr1.Count - 1; j>0;j--,++counter)
			{
				sums.Add(summingWhatever(arr1)); //perform exhaustive summing operation
				sumsAndArrangements[sums[counter]]=arr1; //map sum to array arrangment
				toSwap(arr1,j,j-1);//change array arrangement
				//Console.WriteLine(arr1 +"," +sums[counter]);
			}
			
			return counter;
		
		}
		
		
		private static int forwardSwap(List<int>arr, List<int>sums,int counter,Dictionary<int,List<int>>sumsAndArrangements)
		{
			for(int i =0 ; i >arr.Count - 1;i++,++counter)
			{
				sums.Add(summingWhatever(arr)); //perform exhaustive summing operation
				sumsAndArrangements[sums[counter]]=arr; //map sum to array arrangment
				toSwap(arr,i,i-1);//change array arrangement
				//Console.WriteLine(arr +"," +sums[counter]);				
			}
			
			return counter;
		
		}
		
		private static void arrowHeadBuilder (List<int>arr, List<int>arr1)
		{
			arr.Sort();
			arr1.Reverse();
			arr1.Sort();
			int j;
			int midpoint;
			if(arr.Count % 2 ==0) //find midpoint
			{
				midpoint = (arr.Count/2);
			}else{
			
				midpoint =(arr.Count/2)+1;
			}	
			//Console.WriteLine(arr +"," +arr1);
			
			for(j = midpoint; j<arr.Count;j++){
				arr1[j]=arr[j-midpoint];
			}	
		}
		
		
		private static int summingWhatever (List <int>values) // performs exhaustive sum
		{
			List<int>total = new List<int>();
			int sum =0;
			int counter=0;
			
			for (int i =0; i<values.Count-1;i++)
			{
				total.Add(values[i]+values[i+1]);
			
			}		
			while(counter < total.Count)
			{
				sum+=total[counter];
				counter++;
			}			
			return sum;
		}
		
		
		private static void toSwap (List<int> values, int indexA,int indexB)
		{
			int tmp = values[indexA];
			values[indexA] = values[indexB];
			values[indexB] = tmp;
		}
		
		
	}
}