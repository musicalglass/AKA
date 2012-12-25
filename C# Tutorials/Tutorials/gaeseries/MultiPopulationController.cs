// copyright 2004,  Microgold Software Inc.
// All rights reserved
// This code should be used for educational purposes and not for
// commercial use with out permission from the author


using System;
using System.Collections;
using System.Threading;
using MEPAlgorithm;

namespace GeneticAlgorithm
{
	/// <summary>
	/// Summary description for MultiPopulationController.
	/// </summary>
	public class MultiPopulationController
	{

		public MultiPopulationController()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		ArrayList Populations = new ArrayList();
		Population TestPopulation = null;

		public void AddPopulationThread(string name)
		{
			TestPopulation = new Population(name); 
			Populations.Add(TestPopulation);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.RunPopulation), (object)TestPopulation);
		}


		public bool  AllPopulationsFinished()
		{
			foreach (Population p in Populations)
			{
				if (p.FinishedRunning == false)
					return false;
			}

			return true;
		}

		public void RunPopulation(object thePopulationObject)
		{
			Population thePopulation = (Population)thePopulationObject;
			int NumberOfGenerations = 50000;

			for (int i = 0; i < NumberOfGenerations; i++)
			{
				thePopulation.NextGeneration();
				if (i % (NumberOfGenerations/20)  == 0)
				{
					thePopulation.WriteNextGenerationTop(10);
					if (EquationGenome.PerfectFitness == true)
					{
						NumberOfGenerations = i;
						break;
					}
				}

				if (i % (NumberOfGenerations/4)  == 0)
				{
					EquationGenome[] EquationGenomesBest = (EquationGenome[])thePopulation.GetHighestScoreGenomes(Population.kNumberOfChoiceGenomes);
					CopyHighestFitnessToOtherPopulations(EquationGenomesBest);
				}
			}

			thePopulation.FinishedRunning = true;

			thePopulation.CalculateFitnessForAll();

			EquationGenome EquationGenomeToIllustrate = (EquationGenome)thePopulation.GetHighestScoreGenome();
			Console.WriteLine("");
			Console.WriteLine("Best Genome in {1} after {0} Generations", NumberOfGenerations, thePopulation.Name);
			Console.WriteLine(EquationGenomeToIllustrate.ToString());
			EquationGenomeToIllustrate = GetBestGeneFromAllPopulations();
			Console.WriteLine("The next value in the series = {0}", EquationGenomeToIllustrate.CalculateNextValue());
			Class1.EquationGenomeToIllustrate = EquationGenomeToIllustrate;
			//			Console.ReadLine();

		}

		EquationGenome GetBestGeneFromAllPopulations()
		{
			float topFitness = -1;
			EquationGenome BestGenome = null;
			foreach (Population p in Populations)
			{
				EquationGenome g = (EquationGenome)p.GetHighestScoreGenome();
				if (g.CurrentFitness > topFitness)
				{
					BestGenome = g;
					topFitness = (float)g.CurrentFitness;
				}
			}

			return BestGenome;
		}

		void CopyHighestFitnessToOtherPopulations(EquationGenome[] BestGenomes)
		{
			// inject the genomes into all the populations
			foreach (Population p in Populations)
			{
				for (int i = 0; i < BestGenomes.Length; i++)
				{
					int randomnum = EquationGenome.TheSeed.Next(p.Count);
					p.InjectGenome(BestGenomes[i], randomnum);
				}
			}
		}


	}
}
