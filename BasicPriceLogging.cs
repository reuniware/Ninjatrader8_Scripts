#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Strategies in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Strategies
{	
	public class GLStrategy : Strategy
	{		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"GLStrategy";
				Name										= "GLStrategy";
				Calculate									= Calculate.OnEachTick;
				EntriesPerDirection							= 1;
				EntryHandling								= EntryHandling.AllEntries;
				IsExitOnSessionCloseStrategy				= false;
				ExitOnSessionCloseSeconds					= 30;
				IsFillLimitOnTouch							= false;
				MaximumBarsLookBack							= MaximumBarsLookBack.TwoHundredFiftySix;
				OrderFillResolution							= OrderFillResolution.Standard;
				Slippage									= 0;
				StartBehavior								= StartBehavior.ImmediatelySubmit;
				TimeInForce									= TimeInForce.Gtc;
				TraceOrders									= true;
				RealtimeErrorHandling						= RealtimeErrorHandling.StopCancelClose;
				StopTargetHandling							= StopTargetHandling.PerEntryExecution;
				BarsRequiredToTrade							= 20;
				// Disable this property for performance gains in Strategy Analyzer optimizations
				// See the Help Guide for additional information
				IsInstantiatedOnEachOptimizationIteration	= true;
				//this.ClearOutputWindow();
			}
			else if (State == State.Configure)
			{				
			}
			else if (State == State.DataLoaded)
			{
			}
		}		

		double mediumAsk = 0.0;
		double previousMediumAsk = 0.0;
		double mediumBid = 0.0;
		protected override void OnBarUpdate()
		{
			string spread = String.Format("{0:0.00000}", GetCurrentAsk() - GetCurrentBid());
			Print(State.ToString() + " Current bar = " + this.CurrentBar + " ask=" + GetCurrentAsk() + " bid=" + GetCurrentBid() + " spread=" + (spread) + " ask vol=" + GetCurrentAskVolume() + " bid vol=" + GetCurrentBidVolume());
			mediumAsk = mediumAsk + GetCurrentAsk();
			mediumAsk = mediumAsk/2;
			string mediumAskStr = String.Format("{0:0.00000}", mediumAsk);
			Print("medium ask = " + mediumAskStr);
		}
	}
}
