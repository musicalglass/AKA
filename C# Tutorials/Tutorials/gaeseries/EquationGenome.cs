using System;
using System.Collections;
using MEPAlgorithm;

// copyright 2004,  Microgold Software Inc.
// All rights reserved
// This code should be used for educational purposes and not for
// commercial use with out permission from the author

namespace GeneticAlgorithm
{
	/// <summary>
	/// Summary description for EquationNode.
	/// Equation node represents a symbolic equation that solves a problem
	/// In this case we'll use the following keys to represent our node
	/// 0: x[i] 1: x[i-1] 2: i  3: + 4: - 5: *  6: /  7: 0 8: 1 9: mod
	/// 
	/// 
	/// </summary>
	/// 
	public class EquationGenome : Genome
	{
		public const int NumSymbols = 3;
		public const int NumFunctions = 6;


		public struct Gene
		{
			public int instruction1;
			public int instruction2;
			public int operation;
		};

		ArrayList TheArray = new ArrayList();
		public static Random TheSeed = new Random((int)DateTime.Now.Ticks);
		int TheMin = 0;
		int TheMax = 6;
		int CurrentXPos = 0;
		int CurrentYPos = 0;
		int PreviousSeed = 2;
		public bool TrialFitness; // this needs to be perfect or else we have to throw out the gene

		public static bool PerfectFitness = false;
		public static EquationGenome PerfectGenome = null;

		public override int CompareTo(object a)
		{
			EquationGenome Gene1 = this;
			EquationGenome Gene2 = (EquationGenome)a;
			return Math.Sign(Gene2.CurrentFitness  -  Gene1.CurrentFitness);
		}


		public override void SetCrossoverPoint(int crossoverPoint)
		{
			CrossoverPoint = 	crossoverPoint;
		}

		public EquationGenome()
		{
		}


		public EquationGenome(long length, object min, object max)
		{
			//
			// TODO: Add constructor logic here
			//
			Length = length;
			TheMin = (int)min;
			TheMax = (int)max;
			CurrentXPos = 0;
			CurrentYPos = 0;

			for (int i = 0; i < Length; i++)
			{
				Gene nextValue = (Gene)GenerateGeneValue(min, max, i);
				TheArray.Add(nextValue);
			}
		}

		public override void Initialize()
		{

		}

		public override bool CanDie(double fitness)
		{
			return false; // no deaths

			if (CurrentFitness <= (int)(fitness * 100.0f))
			{
				return true;
			}

			return false;
		}


		public override bool CanReproduce(double fitness)
		{
			if (EquationGenome.TheSeed.Next(100) >= (int)(fitness * 100.0f))
			{
				return true;
			}

			return false;
		}


		public override object GenerateGeneValue(object min, object max, int position)
		{
			Gene g = new Gene();
			int nextSeed = 0;
			nextSeed = TheSeed.Next((int)min, (int)max);
			g.operation = nextSeed;

			if (position == 0) // special case, want to generate a symbol for first one
			{
				g.operation = TheSeed.Next(0, NumSymbols);  // generate 0 or 1, for a and b
				return g;
			}

			if (nextSeed > 1) // we have an operation, need postion
			{
				nextSeed = TheSeed.Next((int)min, position);
				g.instruction1 = nextSeed;
				nextSeed = TheSeed.Next((int)min, position);
				g.instruction2 = nextSeed;
			}
			
			return g;
		}

		#region GenerateSmartGene
		/*
				public override object GenerateGeneValue(object min, object max)
				{
					bool hasWall = true;
					int nextSeed = 0;
					int counter = 0;
					while (hasWall)
					{
						nextSeed = TheSeed.Next((int)min, (int)max);
						switch (nextSeed)
						{
							case 0:  // up
								if (PreviousSeed == 2)
								{	
									break; // don't backtrack
								}
								hasWall = TheMaze.HasWall(CurrentXPos, this.CurrentYPos, CurrentXPos, CurrentYPos - 1);
								if (hasWall == false)
								{
								 CurrentYPos--;
								}
								break;
							case 1:  // left
								if (PreviousSeed == 3)
								{	
									break; // don't backtrack
								}

								hasWall = TheMaze.HasWall(CurrentXPos, this.CurrentYPos, CurrentXPos - 1, CurrentYPos);
								if (hasWall == false)
								{
									CurrentXPos--;
								}
								break;
							case 2:  // down
								if (PreviousSeed == 0)
								{	
									break; // don't backtrack
								}
								hasWall = TheMaze.HasWall(CurrentXPos, this.CurrentYPos, CurrentXPos, CurrentYPos + 1);
								if (hasWall == false)
								{
									CurrentYPos++;
								}
								break;
							case 3:  // right
								if (PreviousSeed == 1)
								{	
									break; // don't backtrack
								}

								hasWall = TheMaze.HasWall(CurrentXPos, this.CurrentYPos, CurrentXPos + 1, CurrentYPos);
								if (hasWall == false)
								{
									CurrentXPos++;
								}
								break;
						}

						counter++;
						if (counter > 10)
							break;

					}

					return nextSeed;

				}

		*/

		#endregion 



		public override void Mutate()
		{
			int AffectedGenes = TheSeed.Next((int)3); // determine how many genes to mutate
			for (int i = 0; i < AffectedGenes; i++)
			{
				MutationIndex = TheSeed.Next(0, (int)Length);
				//				int val = (int)GenerateGeneValue(TheMin, TheMax);
				TheArray[MutationIndex] = this.GenerateGeneValue(TheMin, TheMax, MutationIndex);
			}

		}


		// This fitness function calculates the fitness of distance travelled
		// from upper left to lower right



		#region fitness2

		// This fitness function calculates the fitness of distance travelled
		/*		// from upper left to lower right
				private double CalculateMazeDistanceFitness()
				{
					double sum = 0.0f;
					int cellPreviousPosX = 0;
					int cellPreviousPosY = 0;
					int cellPosX = 0;
					int cellPosY = 0;
					int trialnumber = 0;
					int backTrack = 0;
					int hasWall = 0;
					int maxConsecutiveNoWalls = 0;
					int consecutiveNoWalls = 0;
					int previousDirection = 0;
					for (int i = 0; i < Length; i++)
					{
						switch ((int)TheArray[i])
						{
							case 0:  // up
								cellPosY--;
								break;
							case 1:  // left
								cellPosX--;
								break;
							case 2:  // down
								cellPosY++;
								break;
							case 3:  // right
								cellPosX++;
								break;
						}

						if ( (previousDirection + 2) % 4 == (int)TheArray[i])
						{
							backTrack++;
						}

						previousDirection = (int)TheArray[i];

						if (maxConsecutiveNoWalls < consecutiveNoWalls)
								maxConsecutiveNoWalls = consecutiveNoWalls;

						if (TheMaze.HasWall(cellPreviousPosX, cellPreviousPosY, cellPosX, cellPosY))
						{
							consecutiveNoWalls = 0;
						}
						else
						{
							consecutiveNoWalls++;
						}

		//				trialnumber++;


						cellPreviousPosX = cellPosX;
						cellPreviousPosY = cellPosY;
					}

					// the score is the distance squared from the origin
					// since the greatest distance is the distance to the destination
					// the lower right hand corner
		//			sum = ((double)(cellPosX*cellPosX + cellPosY*cellPosY))/((double)(Maze.kDimension*Maze.kDimension));  

					sum = sum + ((double)(maxConsecutiveNoWalls))/((double)this.Length);
					sum = sum + ((double)(Length - backTrack))/((double)this.Length);

					sum = sum/2;

					return sum;
				}
		*/

		#endregion 



		public string GetOperationString(int operation)
		{
			string result = "";
			switch(operation)
			{
				case 3: // addition
					result = "+";
					break;
				case 4: // subtraction 
					result = "-";
					break;
				case 5: // multiplication 
					result = "*";
					break;
				case 6: // division 
					result = "/";
					break;
				case 7: // mod 
					result = " mod ";
					break;
				case 8:
					result = "0";
					break;
				case 9:
					result = "1";
					break;
				case 10:
					result = "2";
					break;
				case 11:
					result = "3";
					break;
				default:
					// +
					result = operation.ToString() + "xx";
					break;
			} // end switch

			return result;

		}


		public float DoOperation(float a, float b, int operation, int index)
		{
			float result = 0;
			switch(operation)
			{
				case 3: // add
					result = a + b;
					break;
				case 4: // subtract
					result = (a - b);
					break;
				case 5: // mult
					result = (a * b);
					break;
				case 6: // divide
					if (b == 0)
						result = 1000000.0f;
					else
						result = (a / b);
					break;
				case 7:
					result = a % b;
					if ( float.IsNaN(a%b))
					{
						result = 1000000f;
					}
					break;
				case 8:
					result = 0;
					break;
				case 9:
					result = 1;
					break;
				case 10:
					result = 2;
					break;
				case 11:
					result = 3;
					break;
				default:
					// +
					break;
			} // end switch

			return result;

		}

		string[] CalculationStringArray = new string[Population.kLength];

		public string FormStepsString()
		{
			string _result = "\n";

			int count = 0;
			foreach (Gene g in TheArray)
			{
				if (g.operation < NumSymbols)
				{
					// a or b, assign value
					if (g.operation == 0)
						_result += count.ToString() +": " + "a\n";
					else
						_result += count.ToString() +": " + "b\n";
				}
				else if (g.operation == 8)
				{
					_result += count.ToString() +": " + "PI\n";
				}
				else
				{
					// operation, use it to fill calculation in array
					_result += count.ToString() +": " + GetOperationString(g.operation) + " " + g.instruction1.ToString() + ", " + g.instruction2.ToString() + "\n";
				}

				count++;
			}

			_result += "\n\n";
			return _result;
		}


		public string FormEquationString()
		{
			string _result = "";

			int count = 0;
			foreach (Gene g in TheArray)
			{
				if (g.operation < NumSymbols)
				{
					if (g.operation == 1)
						CalculationStringArray[count] = "x[i-1]";
					else if (g.operation == 2)
						CalculationStringArray[count] = "i";
					else
						CalculationStringArray[count] = "x[i]";
				}
				else
				{
					if (g.operation == 8)
					{
						CalculationStringArray[count] = "0";
					}
					else if (g.operation == 9)
					{
						CalculationStringArray[count] = "1";
					}
					else if (g.operation == 10)
					{
						CalculationStringArray[count] = "2";
					}
					else if (g.operation == 11)
					{
						CalculationStringArray[count] = "3";
					}
					else
					{
						// operation, use it to fill calculation in array
						CalculationStringArray[count] = "(" + CalculationStringArray[g.instruction1] + GetOperationString(g.operation) + CalculationStringArray[g.instruction2] + ")";
					}
				}

				count++;
			}

			_result = CalculationStringArray[Population.kLength - 1];

			return _result;
		}

		float[] CalculationArray = new float[Population.kLength];

		/// <summary>
		/// Perform a calculation based on the value in the series
		/// and the index of the value in that series
		/// </summary>
		/// <param name="measure"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public float PerformCalculation(double measure, int index)
		{
			int count = 0;


			foreach (Gene g in TheArray)
			{
				// if its a symbol (0,1 or 2), it's either x[i], x[i-1], or i itself
				if (g.operation < NumSymbols)
				{
					
					if (g.operation == 1)  // 1: x[i-1]
						CalculationArray[count] = SeriesValues[index - 1];
					else if (g.operation == 2)  // 2: i
						CalculationArray[count] = index;
					else
						CalculationArray[count] = (float)measure; // 0: x[i]

				}
				else if  (g.operation == 7)
				{
					// its the number zero
					CalculationArray[count] = 0;
				}
				else if (g.operation == 8)
				{
					// its the number 0ne
					CalculationArray[count] = 1;
				}
				else
				{
					// operation (+, -, * or /), use it to fill calculation in array
					CalculationArray[count] = DoOperation(CalculationArray[g.instruction1], CalculationArray[g.instruction2], g.operation, index);
				}

				count++;
			}

			return CalculationArray[TheArray.Count - 1];  // return last calculation
		}

		
									
		//		float[] SeriesValues = new float[] {0, 1, 4, 9, 16, 25, 36, 49, 64, 81}; // squares
		//		float[] SeriesValues = new float[] {1, -1, 1, -1, 1, -1, 1, -1, 1}; // -1
		//		float[] SeriesValues = new float[] {1, -.5f, .25f, -.125f, .0625f, -.03125f, .015625f}; // halfed and negative
		//		float[] SeriesValues = new float[] {1,2,3,5,7,11,13,17,19,23,29,31,37,41}; // primes  {unsolved}
        //		float[] SeriesValues = new float[] {0,1,1,2,3,5,8,13,21,34,55}; // fibanocci
		//		float[] SeriesValues = new float[] {0,1,8,27,64,125,216,343,512,729,1000}; // cubes {unsolved}
		//		float[] SeriesValues = new float[] {1,2,3,4,5,6,7,8,9,10}; // ints
		//		float[] SeriesValues = new float[] {1,2,2,4,8,32,256}; // multiples
		//		float[] SeriesValues = new float[] {0,3,6,9,12,15,18, 21, 24, 27}; // 3x series
//				float[] SeriesValues = new float[] {0, 1, 1, 2, 5, 29, 866}; // sum of squares
		//		float[] SeriesValues = new float[] {1, 2, 8, 28, 100, 356}; // x[i-1] * 2 + x[i] * 3
		//		float[] SeriesValues = new float[] {-3, -2, 1, 6, 13, 22}; // x[i]^2 - 3
				float[] SeriesValues = new float[] {1, 2, 3, 5, 16, 231}; // x[i]^2 - x[i-1]^2
//				float[] SeriesValues = new float[] {1, 2, 1.5f, 1.75f, 1.625f, 1.6875f}; // (x[i] + x[i-1])/2  (average series)
//				float[] SeriesValues = new float[] {1, 2, 3, 6, 12, 24}; // sum of all previous values 
//				float[] SeriesValues = new float[] {1, -1, 0, -1, -1, -2, -3, -5}; // sum of x[i] + x[i-1] 
//				float[] SeriesValues = new float[] {1, 2, 3, 2, 1, 2, 3, 2, 1}; // simple triangle wave 
//				float[] SeriesValues = new float[] {-1, -1, 1, 1, -1, -1, 1, 1}; //  simple square wave
//				float[] SeriesValues = new float[] {0, 1, 10, 11, 100, 101, 110, 111}; //  binary numbers
//				float[] SeriesValues = new float[] {1, 10, 100, 1000, 10000, 100000}; //  multiples of 10
//				float[] SeriesValues = new float[] {0, 1, 2, 5, 10, 19}; //  x[i] + x[i-1] + i
//				float[] SeriesValues = new float[] {1, (1f/2f), (1f/3f), (1f/4f), (1f/5f), (1f/6f)}; //  1/i  
//				float[] SeriesValues = new float[] {1, (1f/4f), (1f/9f), (1f/16f), (1f/25f), (1f/36f)}; //  1/(i^2)
//				float[] SeriesValues = new float[] {42, 26, 18, 14, 12, 11, 10.5f};  
//				float[] SeriesValues = new float[] {7, 0, 5, 8, 8, 2, 3};
				


		public double CalculateNextValue()
		{
			double nextValue = PerformCalculation(SeriesValues[SeriesValues.Length - 1], SeriesValues.Length - 1);
			return nextValue;
		}

		public double CalculateSeriesFitness()
		{
			CurrentFitness = 0.0f;
			// cycle through all values in the series (each x[i])
			for (int i = 1; i < SeriesValues.Length-1; i++)
			{
				// perform the calculation on the current value in
				// the series and its index
				double calc = PerformCalculation(SeriesValues[i], i);

				// compare the calculation to the next
				// value in the series to determine a fitness
				// measurement between the two values
				double measure = SeriesValues[i+1];
				CurrentFitness += Math.Exp(-Math.Abs(measure-calc));
			}

			// produce a normalized fitness by dividing by
			// 2 less than all the numbers in the series
			// (since we cycle through the second and second to last values)
			CurrentFitness /= SeriesValues.Length - 2; // we chopped off both ends so subtract 2

			return CurrentFitness;
		}

		public override double CalculateFitness()
		{
			try
			{
				lock(this)
				{
					// CurrentFitness = CalculateClosestProductSum();
					//			CurrentFitness =  CalculateClosestSumTo10();
					//			CurrentFitness = CalculateMazeDistanceFitness();
					CurrentFitness = CalculateSeriesFitness();
					if (CurrentFitness < 0.0f)
						CurrentFitness = 0.01f;

					if (CurrentFitness == 1)
					{
						PerfectFitness = true;
						PerfectGenome = this;
					}
				}
			}
			catch (Exception ex)
			{
				CurrentFitness = .01f;  // ignore occasional exception
			}
			return CurrentFitness;
		}


		public override string ToString()
		{
			string strResult = "";
			//			for (int i = 0; i < Length; i++)
			//			{
			//			  strResult = strResult + ((int)TheArray[i]).ToString() + " ";
			//			}

			int index = 0;
			//			TheArray[0] = 5;			
			//			TheArray[1] = 3;			
			//			TheArray[2] = 1;			
			//			TheArray[3] = 0;			
			//			TheArray[4] = 2;		
//			strResult += " -->  " + this.FormStepsString();
			lock (this)
			{
					strResult += " -->  " + this.FormEquationString();
			}

				strResult += " --> " + CurrentFitness.ToString();

			strResult += " --> " + CalculateNextValue().ToString();

				return strResult;
		}

		public override void CopyGeneInfo(Genome dest)
		{
			EquationGenome theGene = (EquationGenome)dest;
			theGene.Length = Length;
			theGene.TheMin = TheMin;
			theGene.TheMax = TheMax;
		}

		public override Genome UniformCrossover(Genome g)
		{
			EquationGenome aGene1 = new EquationGenome();
			EquationGenome aGene2 = new EquationGenome();
			g.CopyGeneInfo(aGene1);
			g.CopyGeneInfo(aGene2);

// swap genes randomly

			EquationGenome CrossingGene = (EquationGenome)g;
			for (int i = 0; i < Length; i++)
			{
				if (TheSeed.Next(100) % 2 == 0)
				{
					aGene1.TheArray.Add(CrossingGene.TheArray[i]);
					aGene2.TheArray.Add(TheArray[i]);
				}
				else
				{
					aGene1.TheArray.Add(TheArray[i]);
					aGene2.TheArray.Add(CrossingGene.TheArray[i]);
				}

			}



			// 50/50 chance of returning gene1 or gene2
			EquationGenome aGene = null;
			if (TheSeed.Next(2) == 1)			
			{
				aGene = aGene1;
			}
			else
			{
				aGene = aGene2;
			}

			return aGene;
		}


		public override Genome Crossover2Point(Genome g)
		{
			EquationGenome aGene1 = new EquationGenome();
			EquationGenome aGene2 = new EquationGenome();
			g.CopyGeneInfo(aGene1);
			g.CopyGeneInfo(aGene2);

			// Pick a random crossover point
			int CrossoverPoint1 = TheSeed.Next(1, (int)Length);
			int CrossoverPoint2 = TheSeed.Next(CrossoverPoint1, (int)Length);
			// normalize
			if (CrossoverPoint1 > CrossoverPoint2)
			{
				int temp = CrossoverPoint1;
				CrossoverPoint1 = CrossoverPoint2;
				CrossoverPoint2 = temp;
			}

			EquationGenome CrossingGene = (EquationGenome)g;

			for (int j = 0; j < CrossoverPoint1; j++)
			{
				aGene1.TheArray.Add(TheArray[j]);
				aGene2.TheArray.Add(CrossingGene.TheArray[j]);
			}

			for (int j = CrossoverPoint1; j < CrossoverPoint2; j++)
			{
				aGene1.TheArray.Add(CrossingGene.TheArray[j]);
				aGene2.TheArray.Add(TheArray[j]);
			}


			for (int j = CrossoverPoint2; j < Length; j++)
			{
				aGene1.TheArray.Add(TheArray[j]);
				aGene2.TheArray.Add(CrossingGene.TheArray[j]);
			}


			// 50/50 chance of returning gene1 or gene2
			EquationGenome aGene = null;
			if (TheSeed.Next(2) == 1)			
			{
				aGene = aGene1;
			}
			else
			{
				aGene = aGene2;
			}

			return aGene;
		}



		public override Genome Crossover(Genome g)
		{
			EquationGenome aGene1 = new EquationGenome();
			EquationGenome aGene2 = new EquationGenome();
			g.CopyGeneInfo(aGene1);
			g.CopyGeneInfo(aGene2);

			// Pick a random crossover point
			CrossoverPoint = TheSeed.Next(1, (int)Length);

			EquationGenome CrossingGene = (EquationGenome)g;
			for (int i = 0; i < CrossoverPoint; i++)
			{
				aGene1.TheArray.Add(CrossingGene.TheArray[i]);
				aGene2.TheArray.Add(TheArray[i]);
			}

			for (int j = CrossoverPoint; j < Length; j++)
			{
				aGene1.TheArray.Add(TheArray[j]);
				aGene2.TheArray.Add(CrossingGene.TheArray[j]);
			}

			// 50/50 chance of returning gene1 or gene2
			EquationGenome aGene = null;
			if (TheSeed.Next(2) == 1)			
			{
				aGene = aGene1;
			}
			else
			{
				aGene = aGene2;
			}

			return aGene;
		}

		public int this[int arrayindex]
		{
			get
			{
				return (int)TheArray[arrayindex];
			}
		}

		public override void CopyGeneFrom(Genome src)
		{
			EquationGenome theGene = (EquationGenome)src;
			for (int i = 0; i < TheArray.Count; i++)
			{
				TheArray[i] = (Gene)theGene.TheArray[i];			
			}

			Length = theGene.Length;
			TheMin = theGene.TheMin;
			TheMax = theGene.TheMax;
			CurrentFitness = theGene.CurrentFitness;

		}


	}
}
