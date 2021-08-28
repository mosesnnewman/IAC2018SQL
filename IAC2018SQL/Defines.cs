using System;

namespace IAC2021SQL
{
	/// <summary>
	/// This file contains defines for use with the TValueEngine.
	/// </summary>

	public struct TValueDefines
	{
		// Maximum total number of events.
		public const int TV_MAX_EVENTS = 1800;
		public const int TV_MAX_EVENTS_PER_LINE = 999;

		//Defines for "Unknown", "Min" and "Max" amounts.
		public const decimal TV_UNKNOWN_AMOUNT = -10000000000;
		public const decimal TV_MIN_AMOUNT = -999999999.99m;
		public const decimal TV_MAX_AMOUNT = 999999999.99m;
	
		//Defines for a weighted unknown.
		public const double TV_NOT_WEIGHTED = -10000000000;
		public const double TV_MIN_UNKNOWN_AMOUNT_WEIGHT = 0.1;
		public const double TV_MAX_UNKNOWN_AMOUNT_WEIGHT = 99;
	
		//Defines for rates.
		public const double TV_UNKNOWN_RATE = -10000000000;
		public const double TV_UNDEFINED_RATE = -10000000001;
		public const double TV_MIN_NOMINAL_RATE = -0.9999000;
		public const double TV_MAX_EFFECTIVE_RATE = 9.99990001;
		public const double TV_MAX_EXISTING_FIXED_RATE = 2.4;
	
		//Defines for "Unknown", "Min" and "Max" event number.
		public const int TV_UNKNOWN_EVENT_NUMBER = -1;
		public const int TV_MIN_EVENT_NUMBER = 1;
		public const int TV_MAX_EVENT_NUMBER = TV_MAX_EVENTS_PER_LINE;

		//Defines for Dates.
		public static readonly DateTime TV_NO_DATE = DateTime.FromOADate(-2);
		public static readonly DateTime TV_PENDING_DATE = DateTime.FromOADate(-1);
		public static readonly DateTime TV_TODAYS_DATE = DateTime.FromOADate(0);
		public static readonly DateTime TV_MIN_YEAR = DateTime.FromOADate(1940);
		public static readonly DateTime TV_MAX_YEAR = DateTime.FromOADate(2098);
	
		//Amortization dataArray Indexes.
		public const short AmortLoan1Index = 0;
		public const short AmortLoan2Index = 1;
		public const short AmortLoan3Index = 2;
		public const short AmortPayment1Index = 3;
		public const short AmortPayment2Index = 4;
		public const short AmortPayment3Index = 5;
		public const short AmortInterestAccruedIndex = 6;
		public const short AmortInterestPaidIndex = 7;
		public const short AmortPrincipalPaidIndex = 8;
		public const short AmortUnpaidInterestBalanceIndex = 9;
		public const short AmortPrincipalBalanceIndex = 10;
		public const short AmortTotalBalanceIndex = 11;
		public const short AmortNetChangeIndex = 12;

		//Error codes.
		public const int TVERR_Base  = -10000000;
		public const int TVERR_UserBase  = TVERR_Base - 1000;
	
		//System Errors.
		public const int TVERR_UnableToCreateRate  = TVERR_Base - 1;
		public const int TVERR_UnableToGetEffectiveRate  = TVERR_Base;
		public const int TVERR_UnableToGetPeriodicRate  = TVERR_Base - 3;
		public const int TVERR_UnableToGetDailyRate  = TVERR_Base - 4;
		public const int TVERR_UnableToGetNominalFromEffectiveRate  = TVERR_Base - 5;
		public const int TVERR_UnableToGetNominalFromPeriodicRate  = TVERR_Base - 6;
		public const int TVERR_UnableToGetNominalFromDailyRate  = TVERR_Base - 7;
		public const int TVERR_UnableToCreateCalculationCFM  = TVERR_Base - 8;
		public const int TVERR_UnableToDestroyCalculationCFM  = TVERR_Base - 9;
		public const int TVERR_UnableToSetYearLength  = TVERR_Base - 10;
		public const int TVERR_UnableToSetAmortMethod  = TVERR_Base - 11;
		public const int TVERR_UnableToSetCanadianBasis  = TVERR_Base - 12;
		public const int TVERR_Calculation_SetLine_Failed  = TVERR_Base - 20;
		public const int TVERR_Calculation_SetEvent_Failed  = TVERR_Base - 21;
		public const int TVERR_Calculation_SetDate_Failed  = TVERR_Base - 22;
		public const int TVERR_Calculation_SetAmountUnknown_Failed  = TVERR_Base - 23;
		public const int TVERR_Calculation_SetAmount_Failed  = TVERR_Base - 24;
		public const int TVERR_Calculation_SetUnknownNumber_Failed  = TVERR_Base - 25;
		public const int TVERR_Calculation_SetPaymentNumber_Failed  = TVERR_Base - 26;
		public const int TVERR_Calculation_SetPeriod_Failed  = TVERR_Base - 27;
		public const int TVERR_Calculation_RateCreate_Failed  = TVERR_Base - 28;
		public const int TVERR_Calculation_SetRate_Failed  = TVERR_Base - 29;
		public const int TVERR_Calculation_SetRateUnknown_Failed  = TVERR_Base - 30;
		public const int TVERR_Calculation_SetSeries_Failed  = TVERR_Base - 31;
		public const int TVERR_Calculation_SetSeriesData_Failed  = TVERR_Base - 32;
		public const int TVERR_Calculation_SetPIAType_Failed  = TVERR_Base - 33;
		public const int TVERR_AmortizeFailed  = TVERR_Base - 40;
		public const int TVERR_AmortizeGetSizeFailed  = TVERR_Base - 41;
		public const int TVERR_AmortizeSetLineFailed  = TVERR_Base - 42;
		public const int TVERR_AmortizeGetDataFailed  = TVERR_Base - 43;
		public const int TVERR_AmortizeSetFiscalYearFailed  = TVERR_Base - 44;
	
		public const int TVERR_Fire_NewEventAdded_Failed  = TVERR_Base - 46;
		public const int TVERR_Fire_EventDeleted_Failed  = TVERR_Base - 47;
		public const int TVERR_Fire_AllEventsDeleted_Failed  = TVERR_Base - 48;
		public const int TVERR_Fire_WasSorted_Failed  = TVERR_Base - 49;
		public const int TVERR_Fire_WasExpanded_Failed  = TVERR_Base - 50;
		public const int TVERR_Fire_WasCompressed_Failed  = TVERR_Base - 51;
		public const int TVERR_Fire_LabelChanged_Failed  = TVERR_Base - 52;
		public const int TVERR_Fire_CompoundPeriodChanged_Failed  = TVERR_Base - 53;
		public const int TVERR_Fire_NominalAnnualRateChanged_Failed  = TVERR_Base - 54;
		public const int TVERR_Fire_EventTypeChanged_Failed  = TVERR_Base - 55;
		public const int TVERR_Fire_EventDateChanged_Failed  = TVERR_Base - 56;
		public const int TVERR_Fire_EventAmountChanged_Failed  = TVERR_Base - 57;
		public const int TVERR_Fire_EventNumberChanged_Failed  = TVERR_Base - 58;
		public const int TVERR_Fire_EventPeriodChanged_Failed  = TVERR_Base - 59;
		public const int TVERR_Fire_EventEndDateChanged_Failed  = TVERR_Base - 60;
		public const int TVERR_Fire_EventNoteChanged_Failed  = TVERR_Base - 61;
		public const int TVERR_Fire_EventRateCompoundChanged_Failed  = TVERR_Base - 62;
		public const int TVERR_Fire_EventRateChanged_Failed  = TVERR_Base - 63;
	
		public const int TVERR_Calculation_GetLabels_Failed  = TVERR_Base - 75;
		public const int TVERR_Calculation_GetRate_Failed  = TVERR_Base - 76;
		public const int TVERR_Calculation_RateVP_Failed  = TVERR_Base - 77;
		public const int TVERR_Calculation_GetEvent_Failed  = TVERR_Base - 78;
		public const int TVERR_Calculation_GetStartDate_Failed  = TVERR_Base - 79;
		public const int TVERR_Calculation_GetAmount_Failed  = TVERR_Base - 80;
		public const int TVERR_Calculation_GetPaymentNumber_Failed  = TVERR_Base - 81;
		public const int TVERR_Calculation_GetPeriod_Failed  = TVERR_Base - 82;
		public const int TVERR_Calculation_GetSeries_Failed  = TVERR_Base - 83;
		public const int TVERR_Calculation_GetUnknownField_Failed  = TVERR_Base - 84;
		public const int TVERR_Calculation_GetAmortMethod_Failed  = TVERR_Base - 85;
		public const int TVERR_Calculation_GetYearLength_Failed  = TVERR_Base - 86;
		public const int TVERR_Calculation_GetCanadianQuotation_Failed  = TVERR_Base - 87;
		public const int TVERR_Calculation_GetDailyMode_Failed  = TVERR_Base - 88;
		public const int TVERR_Calculation_UnknownWeight_Failed  = TVERR_Base - 89;
		public const int TVERR_Calculation_GetLoanDetail_Failed  = TVERR_Base - 90;
		public const int TVERR_Calculation_GetUnknownRow_Failed  = TVERR_Base - 91;
		public const int TVERR_Calculation_GetSeriesData_Failed  = TVERR_Base - 92;
		public const int TVERR_Calculation_GetUserEvents_Failed  = TVERR_Base - 93;
		public const int TVERR_Calculation_Compress_Failed  = TVERR_Base - 94;
		public const int TVERR_Calculation_Expand_Failed  = TVERR_Base - 95;
		public const int TVERR_Calculation_Sort_Failed  = TVERR_Base - 96;
		public const int TVERR_Calculation_GetMaxLine_Failed  = TVERR_Base - 97;
		public const int TVERR_Calculation_SetAmountUnknownWeight_Failed  = TVERR_Base - 98;
		public const int TVERR_Calculation_GetUnknownPayment_Failed  = TVERR_Base - 99;
		public const int TVERR_Calculation_CompressLine_Failed  = TVERR_Base - 100;
		public const int TVERR_Calculation_ExpandLine_Failed  = TVERR_Base - 101;
		public const int TVERR_Calculation_SetEventTypeID_Failed  = TVERR_Base - 102;
		public const int TVERR_Calculation_GetEventTypeID_Failed  = TVERR_Base - 103;
		public const int TVERR_Calculation_ComputeAPR_Failed  = TVERR_Base - 104;
		public const int TVERR_Calculation_SetLoanDetail_Failed  = TVERR_Base - 105;
		public const int TVERR_Calculation_GetReportOptions_Failed  = TVERR_Base - 106;
	
		public const int TVERR_Calculation_GetFooter_Failed  = TVERR_Base - 108;
		public const int TVERR_Calculation_GetHeaders_Failed  = TVERR_Base - 109;
		public const int TVERR_Calculation_GetPIAType_Failed  = TVERR_Base - 110;
		public const int TVERR_Calculation_InvalidMonthlySkipSequence  = TVERR_Base - 111;
		public const int TVERR_Calculation_Insert_Failed  = TVERR_Base - 112;
		public const int TVERR_Calculation_AddPeriod_Failed  = TVERR_Base - 113;
		public const int TVERR_Calculation_SetNumberUnknown_Failed  = TVERR_Base - 114;
		public const int TVERR_Calculation_RateSetEffective_Failed  = TVERR_Base - 115;
		public const int TVERR_Calculation_RateSetPeriodic_Failed  = TVERR_Base - 116;
		public const int TVERR_Calculation_RateSetDaily_Failed  = TVERR_Base - 117;
		public const int TVERR_Calculation_RateNominal_Failed  = TVERR_Base - 118;
		public const int TVERR_Calculation_WriteToFile_Failed  = TVERR_Base - 119;
		public const int TVERR_Calculation_SetLabels_Failed  = TVERR_Base - 120;
		public const int TVERR_Calculation_SetHeaders_Failed  = TVERR_Base - 121;
		public const int TVERR_Calculation_SetFooter_Failed  = TVERR_Base - 122;
		public const int TVERR_Calculation_SetReportOptions_Failed  = TVERR_Base - 123;
	
		public const int TVERR_NewFailed_OutOfRamMemory  = TVERR_Base - 150;
		public const int TVERR_OldTValueDll  = TVERR_Base - 151;
	
	
		//User Errors.
		public const int TVERR_DateLessThenMinimum  = TVERR_UserBase - 0;
		public const int TVERR_DateGreaterThenMaximum  = TVERR_UserBase - 1;
		public const int TVERR_EndDateLessThenMinimum  = TVERR_UserBase - 2;
		public const int TVERR_EndDateGreaterThenMaximum  = TVERR_UserBase - 3;
		public const int TVERR_CanNotCalculateNoUnknowns  = TVERR_UserBase - 4;
		public const int TVERR_CanNotCalculateMoreThan1UnknownType  = TVERR_UserBase - 5;
		public const int TVERR_CanNotCalculateNotSolvable  = TVERR_UserBase - 6;
		public const int TVERR_AmountTooSmall  = TVERR_UserBase - 7;
		public const int TVERR_AmountTooLarge  = TVERR_UserBase - 8;
		public const int TVERR_RateTooSmall  = TVERR_UserBase - 9;
		public const int TVERR_RateTooLarge  = TVERR_UserBase - 10;
		public const int TVERR_EventNumberTooSmall  = TVERR_UserBase - 11;
		public const int TVERR_EventNumberTooLarge  = TVERR_UserBase - 12;
		public const int TVERR_EventPeriodInvalidWithCurrentCompoundPeriod  = TVERR_UserBase - 13;
		public const int TVERR_CompoundPeriodInvalidWithCurrentEventPeriods  = TVERR_UserBase - 14;
		public const int TVERR_UnknownNominalAnnualRateAlreadySet  = TVERR_UserBase - 15;
		public const int TVERR_UnknownEventRateAlreadySet  = TVERR_UserBase - 16;
		public const int TVERR_UnknownEventNumberAlreadySet  = TVERR_UserBase - 17;
		public const int TVERR_UnknownEventAmountAlreadySet  = TVERR_UserBase - 18;
		public const int TVERR_InvalidMethodCall  = TVERR_UserBase - 19;
		public const int TVERR_InvalidEventType  = TVERR_UserBase - 20;
		public const int TVERR_InvalidEventTypeForTheCurrentCFM  = TVERR_UserBase - 21;
		public const int TVERR_AmountUnknownWeightTooSmall  = TVERR_UserBase - 23;
		public const int TVERR_AmountUnknownWeightTooLarge  = TVERR_UserBase - 24;
		public const int TVERR_CFMNotEmptyCantSetdecimalPlaces  = TVERR_UserBase - 25;
		public const int TVERR_decimalPlacesTooSmall  = TVERR_UserBase - 26;
		public const int TVERR_decimalPlacesTooLarge  = TVERR_UserBase - 27;
		public const int TVERR_InvalidNullParameter  = TVERR_UserBase - 28;
		public const int TVERR_NoPaymentEventInCFM  = TVERR_UserBase - 29;
		public const int TVERR_NoLoanEventInCFM  = TVERR_UserBase - 30;
		public const int TVERR_InvalidIndex  = TVERR_UserBase - 31;
		public const int TVERR_UserName1NotSet  = TVERR_UserBase - 32;
		public const int TVERR_UserName2NotSet  = TVERR_UserBase - 33;
		public const int TVERR_UserName3NotNull  = TVERR_UserBase - 34;
		public const int TVERR_UserName2NotNull  = TVERR_UserBase - 35;
		public const int TVERR_InvalidEmptyString  = TVERR_UserBase - 36;
		public const int TVERR_UnknownEventName  = TVERR_UserBase - 37;
		public const int TVERR_Event0CanNotBeRateChange  = TVERR_UserBase - 38;
		public const int TVERR_AfterSortEvent0WouldBeRateChange  = TVERR_UserBase - 39;
		public const int TVERR_RateChangeEventDoesNotHaveAnAmount  = TVERR_UserBase - 41;
		public const int TVERR_RateChangeEventDoesNotHaveAnUnknownWeight  = TVERR_UserBase - 42;
		public const int TVERR_RateChangeEventDoesNotHaveAnEventNumber  = TVERR_UserBase - 43;
		public const int TVERR_RateChangeEventDoesNotHaveAnEventPeriod  = TVERR_UserBase - 44;
		public const int TVERR_ChangeWouldCauseInvalidEventPeriod  = TVERR_UserBase - 45;
		public const int TVERR_SpecificLineCanNotBeRateChangeEvent  = TVERR_UserBase - 46;
		public const int TVERR_RuleOf78DoesNotAllowOpenBalance  = TVERR_UserBase - 47;
		public const int TVERR_RuleOf78RequiresFirstEventToBeALoan  = TVERR_UserBase - 48;
		public const int TVERR_RuleOf78DoesNotAllowMultipleLoans  = TVERR_UserBase - 49;
		public const int TVERR_RuleOf78DoesNotAllowRateChangeEvents  = TVERR_UserBase - 50;
		public const int TVERR_RuleOf78DoesNotAllowSpecialSeriesEvents  = TVERR_UserBase - 51;
		public const int TVERR_RuleOf78OnlyAllowsLoanAndPaymentEvents  = TVERR_UserBase - 52;
		public const int TVERR_CanadianComputeDoesNotAllowExactDayCompounding  = TVERR_UserBase - 53;
		public const int TVERR_CanadianComputeDoesNotAllowContinuousCompounding  = TVERR_UserBase - 54;
		public const int TVERR_CanadianComputeDoesNotAllowPrincipalFirst  = TVERR_UserBase - 55;
		public const int TVERR_CanadianComputeDoesNotAllowNoCompoundingRateChange  = TVERR_UserBase - 56;
		public const int TVERR_UnknownRateNotAllowed  = TVERR_UserBase - 57;
		public const int TVERR_UnknownAmountNotAllowed  = TVERR_UserBase - 58;
		public const int TVERR_UnknownEventNumberNotAllowed  = TVERR_UserBase - 59;
		public const int TVERR_InvalidMonth  = TVERR_UserBase - 60;
		public const int TVERR_InvalidDay  = TVERR_UserBase - 61;
		public const int TVERR_RoundingNotAllowedWithThisSpecialSeriesEvent  = TVERR_UserBase - 62;
		public const int TVERR_FirstOrAllRoundingNotAllowedWithAmountStep  = TVERR_UserBase - 63;
		public const int TVERR_FirstOrAllRoundingNotAllowedWithPercentStep  = TVERR_UserBase - 64;
		public const int TVERR_FirstOrAllRoundingNotAllowedWithMonthlySkip  = TVERR_UserBase - 65;
		public const int TVERR_PrincipalFirstSeriesOnlyAllowedWithUSRuleCompute  = TVERR_UserBase - 66;
		public const int TVERR_FirstEventIsNotALoan  = TVERR_UserBase - 67;
		public const int TVERR_PointsFeesAndChargesGreaterThanLoanAmount  = TVERR_UserBase - 68;
		public const int TVERR_CanNotInsertBeforeLoanLineWithPointsAndFees  = TVERR_UserBase - 69;
		public const int TVERR_CouldNotReadVersion3or4File  = TVERR_UserBase - 70;
		public const int TVERR_DateIsOutOfSequence  = TVERR_UserBase - 71;
		public const int TVERR_Only1LoanCanHavePointsAndFees  = TVERR_UserBase - 72;
		public const int TVERR_UnknownAmountNotAllowedWithExistingFixedSeries  = TVERR_UserBase - 73;
		public const int TVERR_UnknownEventNumberNotAllowedWithExistingFixedSeries  = TVERR_UserBase - 74;
		public const int TVERR_CalculateRequiresAtLeastOneEvent  = TVERR_UserBase - 75;
		public const int TVERR_CanNotSelectAnEventTypeWhoseEventNameIsNull  = TVERR_UserBase - 76;
		public const int TVERR_InvalidAmortizationLineNumber  = TVERR_UserBase - 77;
		public const int TVERR_EventDatesOutOfOrder  = TVERR_UserBase - 78;
	
		public const int TVERR_CanNotRestoreUnknownsWhenNewUnknownsExist  = TVERR_UserBase - 80;
		public const int TVERR_NoCashFlowLines  = TVERR_UserBase - 81;
		public const int TVERR_USRuleComputeDoesNotAllowDailyCompounding  = TVERR_UserBase - 82;
		public const int TVERR_USRuleComputeDoesNotAllowContinuousCompounding  = TVERR_UserBase - 83;
		public const int TVERR_CanadianComputeDoesNotAllowContinousCompounding  = TVERR_UserBase - 84;
		public const int TVERR_CouldNotOpenFile  = TVERR_UserBase - 85;
		public const int TVERR_RemainingBalanceTooLarge  = TVERR_UserBase - 86;
		public const int TVERR_RemainingBalanceTooSmall  = TVERR_UserBase - 87;
		public const int TVERR_EventNameInUseCanNotBeSetToNull  = TVERR_UserBase - 88;
		public const int TVERR_SpecialSeriesNotAllowedWithLoansOrRateChange  = TVERR_UserBase - 89;
		public const int TVERR_PrePaidInterestDaysMakeEvent1DateInvalid  = TVERR_UserBase - 90;
		public const int TVERR_MonthlySkipInvalidWithCurrentCompoundPeriod  = TVERR_UserBase - 91;
		public const int TVERR_MonthlySkipSeriesRequiresMonthlyPeriod  = TVERR_UserBase - 92;
		public const int TVERR_InvalidDatePastEndOfMonth  = TVERR_UserBase - 93;
		public const int TVERR_ExpandNotAllowedWhenSpecialSeriesHasUnknown  = TVERR_UserBase - 94;
		public const int TVERR_SortWouldPutEventInMiddleOfSpecialSeriesWithUnknown  = TVERR_UserBase - 95;
		public const int TVERR_ExpandWouldCreateTooManyCashFlowLines  = TVERR_UserBase - 96;
		public const int TVERR_CannotSwitchFromUSRuleWhenPrincipalFirstExists  = TVERR_UserBase - 97;
		public const int TVERR_InRule78NoRateChangeSpecialSeriesMultipleLoansOpenBalanceDepositsWithdrawals  = TVERR_UserBase - 98;
		public const int TVERR_InUSRuleNoDepositsWithdrawalsDailyOrContinousCompoundNoCompoundRateChange  = TVERR_UserBase - 99;
		public const int TVERR_InCanadianCompoundingNoDailyOrContinousCompoundOrNoCompoundRateChange  = TVERR_UserBase - 100;
		public const int TVERR_CompoundingCanNotBeNoneExceptInRateChange  = TVERR_UserBase - 101;
		public const int TVERR_ContinousCompoundNotAllowedWithNoCompoundRateChange  = TVERR_UserBase - 102;
		public const int TVERR_NegativeRateNotAllowedWithContinuousCompound  = TVERR_UserBase - 103;
		public const int TVERR_DailyExactDaysAndContinuousNotAllowedWithExistingFixedSeries  = TVERR_UserBase - 104;
		public const int TVERR_LastEventCannotBeRateChange  = TVERR_UserBase - 105;
		public const int TVERR_FixedPrincipalAmountCanNotBeZeroUseInterestOnly  = TVERR_UserBase - 106;
		public const int TVERR_FileCouldNotBeOpened  = TVERR_UserBase - 107;
		public const int TVERR_FileAccessError  = TVERR_UserBase - 108;
		public const int TVERR_NotATValueFile  = TVERR_UserBase - 109;
		public const int TVERR_MallocFailed  = TVERR_UserBase - 110;
		public const int TVERR_FileWriteFailed  = TVERR_UserBase - 111;
		public const int TVERR_CompoundPeriodWouldMakeRateTooHigh  = TVERR_UserBase - 112;
		public const int TVERR_BalanceDateIsBeforeStartDate  = TVERR_UserBase - 113;
		public const int TVERR_DepositsCanNotHaveFixedPrincipalOrInterestOnlySeries  = TVERR_UserBase - 114;
		public const int TVERR_NumberBeforeChangeMustBeZeroOrGreater  = TVERR_UserBase - 115;
		public const int TVERR_NumberBeforeChangeIsTooLarge  = TVERR_UserBase - 116;
		public const int TVERR_NumberToMakeOrSkipMustBeZeroOrGreater  = TVERR_UserBase - 117;
		public const int TVERR_NumberToMakeOrSkipIsTooLarge  = TVERR_UserBase - 118;
		public const int TVERR_CannotCalculateBalanceAmount  = TVERR_UserBase - 119;
		public const int TVERR_CannotCalculateBalanceDate  = TVERR_UserBase - 120;
		public const int TVERR_UnknownNumberNotAllowedWithLoansThatHavePointsAndFees  = TVERR_UserBase - 121;
		public const int TVERR_SortWouldCreateTooManyCashFlowLines  = TVERR_UserBase - 122;
		public const int TVERR_InsertWouldExceedTheMaximumNumberOfCashFlowLines  = TVERR_UserBase - 123;
		public const int TVERR_DuplicateEventName  = TVERR_UserBase - 124;
		public const int TVERR_InvalidVariantType  = TVERR_UserBase - 125;
		public const int TVERR_NoDateEntered  = TVERR_UserBase - 126;
		public const int TVERR_DailyCompoundNotAllowedWithCanadianOddDaysStraightLine  = TVERR_UserBase - 127;
		public const int TVERR_UserCanceled  = TVERR_UserBase - 128;
		public const int TVERR_CalculateWouldProduceNegativeRateWithContinuousCompounding  = TVERR_UserBase - 129;
		public const int TVERR_CalculateWouldProduceAnAmountThatIsTooLarge  = TVERR_UserBase - 130;
		public const int TVERR_AfterSortLoanWithPointsAndFeesWouldNoLongerBeEvent0  = TVERR_UserBase - 131;
		public const int TVERR_Version4CannotHaveMoreThan400CashFlowLines  = TVERR_UserBase - 132;
		public const int TVERR_PastDllExpirationDate  = TVERR_UserBase - 133;
		public const int TVERR_CalculateWouldProduceARateThatIsTooLarge  = TVERR_UserBase - 134;
		public const int TVERR_CalculateWouldProduceAnEventNumberThatIsTooLarge  = TVERR_UserBase - 135;
		public const int TVERR_CfmObjectHasBeenDeleted  = TVERR_UserBase - 136;
		public const int TVERR_InvalidCompoundPeriod  = TVERR_UserBase - 137;
		public const int TVERR_InvalidEventPeriod  = TVERR_UserBase - 138;
		public const int TVERR_InvalidComputeMethod  = TVERR_UserBase - 139;
		public const int TVERR_InvalidYearLength  = TVERR_UserBase - 140;
		public const int TVERR_InvalidCanadianYearBasis  = TVERR_UserBase - 141;
		public const int TVERR_InvalidCanadianOddDays  = TVERR_UserBase - 142;

	}
}
