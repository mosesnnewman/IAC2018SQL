//********************************************************************************
//* Copyright 2017-2021 TimeValue Software. All Rights Reserved.
//********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using TValue6Engine2;

namespace TValue6SDK
{
	//********************************************************************************
	//* Note: This file contains two classes:
	//*			1. TValue6Methods
	//*			2. AmSchedule_LoanPayment
	//********************************************************************************

	//********************************************************************************
	//* class TValue6Methods
	//********************************************************************************

    public class TValue6Methods
    {
		//********************************************************************************
		//* Compute LoanPayment.
		//********************************************************************************

		public double LoanPayment(
			long customerId,
			DateTime loanDate,
			double loanAmount,
			DateTime paymentStartDate,
			int numberOfPayments,
			double interestRate)
		{
			TVWorkspace		tvWorkspace;
			TVDocument		tvDocument;
			double			result;
			
			//****************************************
			//* Create Workspace, create a Document
			//****************************************

			tvWorkspace = new TVWorkspace(customerId);
			tvDocument = new TVDocument(tvWorkspace);

			tvDocument.CashFlowMatrix.SetPeriodAndRate(TVConstants.TVPeriod.Monthly, interestRate);

			//****************************************
			//* Line 1 - Loan
			//****************************************

			tvDocument.CashFlowMatrix.AddLine();
			tvDocument.CashFlowMatrix.SetEvent    (1, TVConstants.TVEventType.Loan, 0);
			tvDocument.CashFlowMatrix.SetStartDate(1, TVDate.Create(loanDate));
			tvDocument.CashFlowMatrix.SetAmount   (1, loanAmount * 100);		// Convert amount to cents
			tvDocument.CashFlowMatrix.SetNumber   (1, 1);

			//****************************************
			//* Line 2 - Payment
			//****************************************

			tvDocument.CashFlowMatrix.AddLine();
			tvDocument.CashFlowMatrix.SetEvent        (2, TVConstants.TVEventType.Payment, 0);
			tvDocument.CashFlowMatrix.SetStartDate    (2, TVDate.Create(paymentStartDate));
			tvDocument.CashFlowMatrix.SetAmountUnknown(2);
			tvDocument.CashFlowMatrix.SetNumber       (2, numberOfPayments);
			tvDocument.CashFlowMatrix.SetEventPeriod  (2, TVConstants.TVEventPeriod.Monthly);

			//****************************************
			//* Calculate - Get Amount
			//****************************************

			tvDocument.Solve();

			result = tvDocument.CashFlowMatrix.GetAmount(2);
			result = result / 100;												// Convert result to dollars

			//****************************************
			//* Cleanup and exit.
			//****************************************

			tvDocument.Delete();
			tvWorkspace.Delete();
			return result;
		}

		//********************************************************************************
		//* Compute LoanPayment with Am Schedule.
		//********************************************************************************

		public double LoanPaymentAmSchedule(
			long customerId,
			DateTime loanDate,
			double loanAmount,
			DateTime paymentStartDate,
			int numberOfPayments,
			double interestRate,
			out List<AmSchedule_LoanPayment> listAmSchedule)
		{
			TVWorkspace		tvWorkspace;
			TVDocument		tvDocument;
			double			result;
			
			//****************************************
			//* Create Workspace, create a Document
			//****************************************

			tvWorkspace = new TVWorkspace(customerId);
			tvDocument = new TVDocument(tvWorkspace);

			tvDocument.CashFlowMatrix.SetPeriodAndRate(TVConstants.TVPeriod.Monthly, interestRate);

			//****************************************
			//* Line 1 - Loan
			//****************************************

			tvDocument.CashFlowMatrix.AddLine();
			tvDocument.CashFlowMatrix.SetEvent    (1, TVConstants.TVEventType.Loan, 0);
			tvDocument.CashFlowMatrix.SetStartDate(1, TVDate.Create(loanDate));
			tvDocument.CashFlowMatrix.SetAmount   (1, loanAmount * 100);		// Convert amount to cents
			tvDocument.CashFlowMatrix.SetNumber   (1, 1);

			//****************************************
			//* Line 2 - Payment
			//****************************************

			tvDocument.CashFlowMatrix.AddLine();
			tvDocument.CashFlowMatrix.SetEvent        (2, TVConstants.TVEventType.Payment, 0);
			tvDocument.CashFlowMatrix.SetStartDate    (2, TVDate.Create(paymentStartDate));
			tvDocument.CashFlowMatrix.SetAmountUnknown(2);
			tvDocument.CashFlowMatrix.SetNumber       (2, numberOfPayments);
			tvDocument.CashFlowMatrix.SetEventPeriod  (2, TVConstants.TVEventPeriod.Monthly);

			//****************************************
			//* Calculate - Get Amount
			//****************************************

			tvDocument.Solve();

			result = tvDocument.CashFlowMatrix.GetAmount(2);
			result = result / 100;												// Convert result to dollars

			//****************************************
			//* Amortization Schedule
			//****************************************

			tvDocument.AmortizationSchedule.GenerateSchedule();

			listAmSchedule = FormatAmSchedule(tvDocument.AmortizationSchedule.AmortizationLines);

			//****************************************
			//* Cleanup and exit.
			//****************************************

			tvDocument.Delete();
			tvWorkspace.Delete();
			return result;
		}

		//********************************************************************************
		//* Extract data from AmSchedule lines.
		//********************************************************************************

		private List<AmSchedule_LoanPayment> FormatAmSchedule(SerializableObservableCollection<AmortizationLine> lines)
		{
			List<AmSchedule_LoanPayment>	listAmSchedule;
			AmSchedule_LoanPayment			amSchedule_LoanPayment;
			AmortizationLine				line;

			listAmSchedule = new List<AmSchedule_LoanPayment>();
			for (int i=0; i<lines.Count; i++)
			{
				line = lines[i];
				switch (line.CustomEventBaseType)
				{
					case (int) TVConstants.TVEventType.Loan:
						amSchedule_LoanPayment = new AmSchedule_LoanPayment();
						amSchedule_LoanPayment.Event		= line.CustomEventName;
						amSchedule_LoanPayment.EventDate	= string.Format("{0:MM/dd/yyyy}", line.Date);
						amSchedule_LoanPayment.Payment		= "";
						amSchedule_LoanPayment.Interest		= "";
						amSchedule_LoanPayment.Principal	= "";
						amSchedule_LoanPayment.Balance		= string.Format("{0:N2}", line.Balance / 100);				// Convert to dollars
						listAmSchedule.Add(amSchedule_LoanPayment);
						break;

					case (int) TVConstants.TVEventType.Payment:
						amSchedule_LoanPayment = new AmSchedule_LoanPayment();
						amSchedule_LoanPayment.Event		= line.CustomEventName;
						amSchedule_LoanPayment.EventDate	= string.Format("{0:MM/dd/yyyy}", line.Date);
						amSchedule_LoanPayment.Payment		= string.Format("{0:N2}", line.NegativeCashFlowSum / 100);	// Convert to dollars
						amSchedule_LoanPayment.Interest		= string.Format("{0:N2}", line.InterestPaid / 100);			// Convert to dollars
						amSchedule_LoanPayment.Principal	= string.Format("{0:N2}", line.Principal / 100);			// Convert to dollars
						amSchedule_LoanPayment.Balance		= string.Format("{0:N2}", line.Balance / 100);				// Convert to dollars
						listAmSchedule.Add(amSchedule_LoanPayment);
						break;

					case (int) TVConstants.TVEventType.AnnualTotal:
						amSchedule_LoanPayment = new AmSchedule_LoanPayment();
						amSchedule_LoanPayment.Event		= line.CustomEventName;
						amSchedule_LoanPayment.EventDate	= "";
						amSchedule_LoanPayment.Payment		= string.Format("{0:N2}", line.NegativeCashFlowSum / 100);	// Convert to dollars
						amSchedule_LoanPayment.Interest		= string.Format("{0:N2}", line.InterestPaid / 100);			// Convert to dollars
						amSchedule_LoanPayment.Principal	= string.Format("{0:N2}", line.Principal / 100);			// Convert to dollars
						amSchedule_LoanPayment.Balance		= "";
						listAmSchedule.Add(amSchedule_LoanPayment);
						break;

					case (int) TVConstants.TVEventType.GrandTotal:
						amSchedule_LoanPayment = new AmSchedule_LoanPayment();
						amSchedule_LoanPayment.Event		= line.CustomEventName;
						amSchedule_LoanPayment.EventDate	= "";
						amSchedule_LoanPayment.Payment		= string.Format("{0:N2}", line.NegativeCashFlowSum / 100);	// Convert to dollars
						amSchedule_LoanPayment.Interest		= string.Format("{0:N2}", line.InterestPaid / 100);			// Convert to dollars
						amSchedule_LoanPayment.Principal	= string.Format("{0:N2}", line.Principal / 100);			// Convert to dollars
						amSchedule_LoanPayment.Balance		= "";
						listAmSchedule.Add(amSchedule_LoanPayment);
						break;

					//case "Rounding":
					//	tempLine = string.Format("Rounding, Interest = {0}\r\n", line.InterestPaid);
					//	amSchedule += tempLine;
					//	break;

					default:
						string debug = line.CustomEventName;
						break;
				}
			}
			return listAmSchedule;
		}

		//********************************************************************************
    }

	//********************************************************************************
	//* class AmSchedule_LoanPayment
	//********************************************************************************

	public class AmSchedule_LoanPayment
	{
		public string Event		{ get; set; }
		public string EventDate	{ get; set; }
		public string Payment	{ get; set; }
		public string Interest	{ get; set; }
		public string Principal	{ get; set; }
		public string Balance	{ get; set; }

		public AmSchedule_LoanPayment()
		{
			Event		= "";
			EventDate	= "";
			Payment		= "";
			Interest	= "";
			Principal	= "";
			Balance		= "";
		}
	}

	//********************************************************************************
}
