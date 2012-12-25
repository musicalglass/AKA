// copyright 2004,  Microgold Software Inc.
// All rights reserved
// This code should be used for educational purposes and not for
// commercial use without written permission from the author


using System;
using GeneticAlgorithm;
using System.Threading;

namespace MEPAlgorithm
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1
	{
		public static EquationGenome EquationGenomeToIllustrate = null;
		public static AutoResetEvent ev = null;
		public static bool ContinueProgram = true;

		public static void WaitThreadFunc(object s, bool bTest)
		{
			ContinueProgram = false;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{

			MultiPopulationController mpc = new MultiPopulationController();
			mpc.AddPopulationThread("pop1");
//			mpc.AddPopulationThread("pop2");
//	 	    mpc.AddPopulationThread("pop3");
//			mpc.AddPopulationThread("pop4");
//			mpc.AddPopulationThread("pop5");

			ev = new AutoResetEvent(false);
			ThreadPool.RegisterWaitForSingleObject(
				ev,
				new WaitOrTimerCallback(Class1.WaitThreadFunc),
				"Hi",
				20000,
				false
				);



			while (true)
			{
				Thread.Sleep(50);
				if (mpc.AllPopulationsFinished())
				{
					break;
				}
			}
		}

	}
}
