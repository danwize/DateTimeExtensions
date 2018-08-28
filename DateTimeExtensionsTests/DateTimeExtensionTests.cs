using System;
using System.Collections.Generic;
using System.Globalization;
using DateTimeExtensions;
using NUnit.Framework;

namespace DateTimeExtensionsTests
{
	[TestFixture()]
	public class DateTimeExtensionTests
	{
		[TestCase("MDT")]
		[TestCase("CST")]
		[TestCase("Mountain Standard Tim")]
		public void InvalidTimeZoneName(string timeZoneName)
		{
			Assert.Throws<TimeZoneNotFoundException>(() =>
			{
				var utcTime = DateTime.UtcNow;
				utcTime.Local(timeZoneName);
			});
		}

		/// <summary>
		/// These time zones are standard on windows machines.  All of these time zones should
		/// be found unless someone has changed the available time zones on the system.  None of theses
		/// test cases should throw an exception.
		/// </summary>
		/// <param name="timeZoneName"></param>
		[TestCase("Dateline Standard Time")]
		[TestCase("UTC-11")]
		[TestCase("Hawaiian Standard Time")]
		[TestCase("Alaskan Standard Time")]
		[TestCase("Pacific Standard Time (Mexico)")]
		[TestCase("Pacific Standard Time")]
		[TestCase("US Mountain Standard Time")]
		[TestCase("Mountain Standard Time (Mexico)")]
		[TestCase("Mountain Standard Time")]
		[TestCase("Central America Standard Time")]
		[TestCase("Central Standard Time")]
		[TestCase("Central Standard Time (Mexico)")]
		[TestCase("Canada Central Standard Time")]
		[TestCase("SA Pacific Standard Time")]
		[TestCase("Eastern Standard Time")]
		[TestCase("US Eastern Standard Time")]
		[TestCase("Venezuela Standard Time")]
		[TestCase("Paraguay Standard Time")]
		[TestCase("Atlantic Standard Time")]
		[TestCase("Central Brazilian Standard Time")]
		[TestCase("SA Western Standard Time")]
		[TestCase("Pacific SA Standard Time")]
		[TestCase("Newfoundland Standard Time")]
		[TestCase("E. South America Standard Time")]
		[TestCase("Argentina Standard Time")]
		[TestCase("SA Eastern Standard Time")]
		[TestCase("Greenland Standard Time")]
		[TestCase("Montevideo Standard Time")]
		[TestCase("Bahia Standard Time")]
		[TestCase("UTC-02")]
		[TestCase("Mid-Atlantic Standard Time")]
		[TestCase("Azores Standard Time")]
		[TestCase("Cape Verde Standard Time")]
		[TestCase("Morocco Standard Time")]
		[TestCase("UTC")]
		[TestCase("GMT Standard Time")]
		[TestCase("Greenwich Standard Time")]
		[TestCase("W. Europe Standard Time")]
		[TestCase("Central Europe Standard Time")]
		[TestCase("Romance Standard Time")]
		[TestCase("Central European Standard Time")]
		[TestCase("W. Central Africa Standard Time")]
		[TestCase("Namibia Standard Time")]
		[TestCase("Jordan Standard Time")]
		[TestCase("GTB Standard Time")]
		[TestCase("Middle East Standard Time")]
		[TestCase("Egypt Standard Time")]
		[TestCase("Syria Standard Time")]
		[TestCase("E. Europe Standard Time")]
		[TestCase("South Africa Standard Time")]
		[TestCase("FLE Standard Time")]
		[TestCase("Turkey Standard Time")]
		[TestCase("Israel Standard Time")]
		[TestCase("Kaliningrad Standard Time")]
		[TestCase("Libya Standard Time")]
		[TestCase("Arabic Standard Time")]
		[TestCase("Arab Standard Time")]
		[TestCase("Belarus Standard Time")]
		[TestCase("Russian Standard Time")]
		[TestCase("E. Africa Standard Time")]
		[TestCase("Iran Standard Time")]
		[TestCase("Arabian Standard Time")]
		[TestCase("Azerbaijan Standard Time")]
		[TestCase("Russia Time Zone 3")]
		[TestCase("Mauritius Standard Time")]
		[TestCase("Georgian Standard Time")]
		[TestCase("Caucasus Standard Time")]
		[TestCase("Afghanistan Standard Time")]
		[TestCase("West Asia Standard Time")]
		[TestCase("Ekaterinburg Standard Time")]
		[TestCase("Pakistan Standard Time")]
		[TestCase("India Standard Time")]
		[TestCase("Sri Lanka Standard Time")]
		[TestCase("Nepal Standard Time")]
		[TestCase("Central Asia Standard Time")]
		[TestCase("Bangladesh Standard Time")]
		[TestCase("N. Central Asia Standard Time")]
		[TestCase("Myanmar Standard Time")]
		[TestCase("SE Asia Standard Time")]
		[TestCase("North Asia Standard Time")]
		[TestCase("China Standard Time")]
		[TestCase("North Asia East Standard Time")]
		[TestCase("Singapore Standard Time")]
		[TestCase("W. Australia Standard Time")]
		[TestCase("Taipei Standard Time")]
		[TestCase("Ulaanbaatar Standard Time")]
		[TestCase("Tokyo Standard Time")]
		[TestCase("Korea Standard Time")]
		[TestCase("Yakutsk Standard Time")]
		[TestCase("Cen. Australia Standard Time")]
		[TestCase("AUS Central Standard Time")]
		[TestCase("E. Australia Standard Time")]
		[TestCase("AUS Eastern Standard Time")]
		[TestCase("West Pacific Standard Time")]
		[TestCase("Tasmania Standard Time")]
		[TestCase("Magadan Standard Time")]
		[TestCase("Vladivostok Standard Time")]
		[TestCase("Russia Time Zone 10")]
		[TestCase("Central Pacific Standard Time")]
		[TestCase("Russia Time Zone 11")]
		[TestCase("New Zealand Standard Time")]
		[TestCase("UTC+12")]
		[TestCase("Fiji Standard Time")]
		[TestCase("Kamchatka Standard Time")]
		[TestCase("Tonga Standard Time")]
		[TestCase("Samoa Standard Time")]
		[TestCase("Line Islands Standard Time")]
		public void ValidTimeZoneName(string timeZoneName)
		{
			var utcTime = DateTime.UtcNow;
			var localDateTime = utcTime.Local(timeZoneName);
			Assert.AreNotEqual(DateTime.MaxValue, localDateTime);
			Assert.AreNotEqual(DateTime.MinValue, localDateTime);
		}

		[Test]
		public void FromDateTimeIsNull()
		{
			DateTime? nullDateTime = null;

			// ReSharper disable once ExpressionIsAlwaysNull
			//Specifically testing the fact that a null date time won't throw an error.
			Assert.AreEqual(null, nullDateTime.Local("Samoa Standard Time"));
		}

		[Test]
		public void WorksWithNullableDateTime()
		{
			DateTime? nullableDateTime = DateTime.UtcNow;
			Assert.AreEqual(nullableDateTime, nullableDateTime.Local("UTC"));
			Assert.AreEqual(nullableDateTime, nullableDateTime.Local("Greenwich Standard Time"));
		}

		[TestCase("MDT")]
		[TestCase("CST")]
		[TestCase("Mountain Standard Tim")]
		public void ToUniversalTime_InvalidTimeZoneName(string timeZoneName)
		{
			Assert.Throws<TimeZoneNotFoundException>(() =>
			{
				var local = DateTime.Now;
				local.ToUniversalTime(timeZoneName);
			});
		}

		/// <summary>
		/// These time zones are standard on windows machines.  All of these time zones should
		/// be found unless someone has changed the available time zones on the system.  None of theses
		/// test cases should throw an exception.
		/// </summary>
		/// <param name="timeZoneName"></param>
		[TestCase("Dateline Standard Time")]
		[TestCase("UTC-11")]
		[TestCase("Hawaiian Standard Time")]
		[TestCase("Alaskan Standard Time")]
		[TestCase("Pacific Standard Time (Mexico)")]
		[TestCase("Pacific Standard Time")]
		[TestCase("US Mountain Standard Time")]
		[TestCase("Mountain Standard Time (Mexico)")]
		[TestCase("Mountain Standard Time")]
		[TestCase("Central America Standard Time")]
		[TestCase("Central Standard Time")]
		[TestCase("Central Standard Time (Mexico)")]
		[TestCase("Canada Central Standard Time")]
		[TestCase("SA Pacific Standard Time")]
		[TestCase("Eastern Standard Time")]
		[TestCase("US Eastern Standard Time")]
		[TestCase("Venezuela Standard Time")]
		[TestCase("Paraguay Standard Time")]
		[TestCase("Atlantic Standard Time")]
		[TestCase("Central Brazilian Standard Time")]
		[TestCase("SA Western Standard Time")]
		[TestCase("Pacific SA Standard Time")]
		[TestCase("Newfoundland Standard Time")]
		[TestCase("E. South America Standard Time")]
		[TestCase("Argentina Standard Time")]
		[TestCase("SA Eastern Standard Time")]
		[TestCase("Greenland Standard Time")]
		[TestCase("Montevideo Standard Time")]
		[TestCase("Bahia Standard Time")]
		[TestCase("UTC-02")]
		[TestCase("Mid-Atlantic Standard Time")]
		[TestCase("Azores Standard Time")]
		[TestCase("Cape Verde Standard Time")]
		[TestCase("Morocco Standard Time")]
		[TestCase("UTC")]
		[TestCase("GMT Standard Time")]
		[TestCase("Greenwich Standard Time")]
		[TestCase("W. Europe Standard Time")]
		[TestCase("Central Europe Standard Time")]
		[TestCase("Romance Standard Time")]
		[TestCase("Central European Standard Time")]
		[TestCase("W. Central Africa Standard Time")]
		[TestCase("Namibia Standard Time")]
		[TestCase("Jordan Standard Time")]
		[TestCase("GTB Standard Time")]
		[TestCase("Middle East Standard Time")]
		[TestCase("Egypt Standard Time")]
		[TestCase("Syria Standard Time")]
		[TestCase("E. Europe Standard Time")]
		[TestCase("South Africa Standard Time")]
		[TestCase("FLE Standard Time")]
		[TestCase("Turkey Standard Time")]
		[TestCase("Israel Standard Time")]
		[TestCase("Kaliningrad Standard Time")]
		[TestCase("Libya Standard Time")]
		[TestCase("Arabic Standard Time")]
		[TestCase("Arab Standard Time")]
		[TestCase("Belarus Standard Time")]
		[TestCase("Russian Standard Time")]
		[TestCase("E. Africa Standard Time")]
		[TestCase("Iran Standard Time")]
		[TestCase("Arabian Standard Time")]
		[TestCase("Azerbaijan Standard Time")]
		[TestCase("Russia Time Zone 3")]
		[TestCase("Mauritius Standard Time")]
		[TestCase("Georgian Standard Time")]
		[TestCase("Caucasus Standard Time")]
		[TestCase("Afghanistan Standard Time")]
		[TestCase("West Asia Standard Time")]
		[TestCase("Ekaterinburg Standard Time")]
		[TestCase("Pakistan Standard Time")]
		[TestCase("India Standard Time")]
		[TestCase("Sri Lanka Standard Time")]
		[TestCase("Nepal Standard Time")]
		[TestCase("Central Asia Standard Time")]
		[TestCase("Bangladesh Standard Time")]
		[TestCase("N. Central Asia Standard Time")]
		[TestCase("Myanmar Standard Time")]
		[TestCase("SE Asia Standard Time")]
		[TestCase("North Asia Standard Time")]
		[TestCase("China Standard Time")]
		[TestCase("North Asia East Standard Time")]
		[TestCase("Singapore Standard Time")]
		[TestCase("W. Australia Standard Time")]
		[TestCase("Taipei Standard Time")]
		[TestCase("Ulaanbaatar Standard Time")]
		[TestCase("Tokyo Standard Time")]
		[TestCase("Korea Standard Time")]
		[TestCase("Yakutsk Standard Time")]
		[TestCase("Cen. Australia Standard Time")]
		[TestCase("AUS Central Standard Time")]
		[TestCase("E. Australia Standard Time")]
		[TestCase("AUS Eastern Standard Time")]
		[TestCase("West Pacific Standard Time")]
		[TestCase("Tasmania Standard Time")]
		[TestCase("Magadan Standard Time")]
		[TestCase("Vladivostok Standard Time")]
		[TestCase("Russia Time Zone 10")]
		[TestCase("Central Pacific Standard Time")]
		[TestCase("Russia Time Zone 11")]
		[TestCase("New Zealand Standard Time")]
		[TestCase("UTC+12")]
		[TestCase("Fiji Standard Time")]
		[TestCase("Kamchatka Standard Time")]
		[TestCase("Tonga Standard Time")]
		[TestCase("Samoa Standard Time")]
		[TestCase("Line Islands Standard Time")]
		public void ToUniversalTime_ValidTimeZoneName(string timeZoneName)
		{
			var localTime = DateTime.UtcNow.Local("Mountain Standard Time");
			var utcDateTime = localTime.ToUniversalTime(timeZoneName);
			Assert.AreNotEqual(DateTime.MaxValue, utcDateTime);
			Assert.AreNotEqual(DateTime.MinValue, utcDateTime);
		}

		[TestCase("Line Islands Standard Time")]
		public void ValidTimeZoneNameToUtc(string timeZoneName)
		{
			var localTime = DateTime.Now;
			Assert.Throws<ArgumentException>(() => localTime.ToUniversalTime(timeZoneName), "The conversion could not be completed because the supplied DateTime did not have the Kind property set correctly.  For example, when the Kind property is DateTimeKind.Local, the source time zone must be TimeZoneInfo.Local.");
		}

		[Test]
		public void ToUniversalTime_FromDateTimeIsNull()
		{
			DateTime? nullDateTime = null;
			// ReSharper disable once ExpressionIsAlwaysNull
			//Specifically testing the fact that a null date time won't throw an error.
			Assert.AreEqual(null, nullDateTime.ToUniversalTime("Samoa Standard Time"));
		}

		[Test]
		public void ToUniversalTime_WorksWithNullableDateTime()
		{
			DateTime? utcTime = DateTime.UtcNow;
			var mountainTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
			var mountainTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime.Value, mountainTimeZone);
			Assert.AreEqual(utcTime, mountainTime.ToUniversalTime("Mountain Standard Time"));
		}

		[TestCase("Dateline Standard Time")]
		[TestCase("UTC-11")]
		[TestCase("Hawaiian Standard Time")]
		[TestCase("Alaskan Standard Time")]
		[TestCase("Pacific Standard Time (Mexico)")]
		[TestCase("Pacific Standard Time")]
		[TestCase("US Mountain Standard Time")]
		[TestCase("Mountain Standard Time (Mexico)")]
		[TestCase("Mountain Standard Time")]
		[TestCase("Central America Standard Time")]
		[TestCase("Central Standard Time")]
		[TestCase("Central Standard Time (Mexico)")]
		[TestCase("Canada Central Standard Time")]
		[TestCase("SA Pacific Standard Time")]
		[TestCase("Eastern Standard Time")]
		[TestCase("US Eastern Standard Time")]
		[TestCase("Venezuela Standard Time")]
		[TestCase("Paraguay Standard Time")]
		[TestCase("Atlantic Standard Time")]
		[TestCase("Central Brazilian Standard Time")]
		[TestCase("SA Western Standard Time")]
		[TestCase("Pacific SA Standard Time")]
		[TestCase("Newfoundland Standard Time")]
		[TestCase("E. South America Standard Time")]
		[TestCase("Argentina Standard Time")]
		[TestCase("SA Eastern Standard Time")]
		[TestCase("Greenland Standard Time")]
		[TestCase("Montevideo Standard Time")]
		[TestCase("Bahia Standard Time")]
		[TestCase("UTC-02")]
		[TestCase("Mid-Atlantic Standard Time")]
		[TestCase("Azores Standard Time")]
		[TestCase("Cape Verde Standard Time")]
		[TestCase("Morocco Standard Time")]
		[TestCase("UTC")]
		[TestCase("GMT Standard Time")]
		[TestCase("Greenwich Standard Time")]
		[TestCase("W. Europe Standard Time")]
		[TestCase("Central Europe Standard Time")]
		[TestCase("Romance Standard Time")]
		[TestCase("Central European Standard Time")]
		[TestCase("W. Central Africa Standard Time")]
		[TestCase("Namibia Standard Time")]
		[TestCase("Jordan Standard Time")]
		[TestCase("GTB Standard Time")]
		[TestCase("Middle East Standard Time")]
		[TestCase("Egypt Standard Time")]
		[TestCase("Syria Standard Time")]
		[TestCase("E. Europe Standard Time")]
		[TestCase("South Africa Standard Time")]
		[TestCase("FLE Standard Time")]
		[TestCase("Turkey Standard Time")]
		[TestCase("Israel Standard Time")]
		[TestCase("Kaliningrad Standard Time")]
		[TestCase("Libya Standard Time")]
		[TestCase("Arabic Standard Time")]
		[TestCase("Arab Standard Time")]
		[TestCase("Belarus Standard Time")]
		[TestCase("Russian Standard Time")]
		[TestCase("E. Africa Standard Time")]
		[TestCase("Iran Standard Time")]
		[TestCase("Arabian Standard Time")]
		[TestCase("Azerbaijan Standard Time")]
		[TestCase("Russia Time Zone 3")]
		[TestCase("Mauritius Standard Time")]
		[TestCase("Georgian Standard Time")]
		[TestCase("Caucasus Standard Time")]
		[TestCase("Afghanistan Standard Time")]
		[TestCase("West Asia Standard Time")]
		[TestCase("Ekaterinburg Standard Time")]
		[TestCase("Pakistan Standard Time")]
		[TestCase("India Standard Time")]
		[TestCase("Sri Lanka Standard Time")]
		[TestCase("Nepal Standard Time")]
		[TestCase("Central Asia Standard Time")]
		[TestCase("Bangladesh Standard Time")]
		[TestCase("N. Central Asia Standard Time")]
		[TestCase("Myanmar Standard Time")]
		[TestCase("SE Asia Standard Time")]
		[TestCase("North Asia Standard Time")]
		[TestCase("China Standard Time")]
		[TestCase("North Asia East Standard Time")]
		[TestCase("Singapore Standard Time")]
		[TestCase("W. Australia Standard Time")]
		[TestCase("Taipei Standard Time")]
		[TestCase("Ulaanbaatar Standard Time")]
		[TestCase("Tokyo Standard Time")]
		[TestCase("Korea Standard Time")]
		[TestCase("Yakutsk Standard Time")]
		[TestCase("Cen. Australia Standard Time")]
		[TestCase("AUS Central Standard Time")]
		[TestCase("E. Australia Standard Time")]
		[TestCase("AUS Eastern Standard Time")]
		[TestCase("West Pacific Standard Time")]
		[TestCase("Tasmania Standard Time")]
		[TestCase("Magadan Standard Time")]
		[TestCase("Vladivostok Standard Time")]
		[TestCase("Russia Time Zone 10")]
		[TestCase("Central Pacific Standard Time")]
		[TestCase("Russia Time Zone 11")]
		[TestCase("New Zealand Standard Time")]
		[TestCase("UTC+12")]
		[TestCase("Fiji Standard Time")]
		[TestCase("Kamchatka Standard Time")]
		[TestCase("Tonga Standard Time")]
		[TestCase("Samoa Standard Time")]
		[TestCase("Line Islands Standard Time")]
		public void ServerToLocalTime_Test(string timeZoneId)
		{
			var thisComputerTimeZone = TimeZone.CurrentTimeZone;
			var specifiedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
			var testDateTime = new DateTime(2006, 6, 12, 11, 0, 0);
			var pcUtcOffset = thisComputerTimeZone.GetUtcOffset(testDateTime);
			var timeZoneOffset = specifiedTimeZone.GetUtcOffset(testDateTime);
			var expectedTimeDifference = timeZoneOffset - pcUtcOffset;

			var expectedTime = testDateTime.ServerTimeToLocalTime(timeZoneId);
			Assert.AreEqual(expectedTimeDifference, expectedTime - testDateTime);
		}

		[TestCase("Dateline Standard Time")]
		[TestCase("UTC-11")]
		[TestCase("Hawaiian Standard Time")]
		[TestCase("Alaskan Standard Time")]
		[TestCase("Pacific Standard Time (Mexico)")]
		[TestCase("Pacific Standard Time")]
		[TestCase("US Mountain Standard Time")]
		[TestCase("Mountain Standard Time (Mexico)")]
		[TestCase("Mountain Standard Time")]
		[TestCase("Central America Standard Time")]
		[TestCase("Central Standard Time")]
		[TestCase("Central Standard Time (Mexico)")]
		[TestCase("Canada Central Standard Time")]
		[TestCase("SA Pacific Standard Time")]
		[TestCase("Eastern Standard Time")]
		[TestCase("US Eastern Standard Time")]
		[TestCase("Venezuela Standard Time")]
		[TestCase("Paraguay Standard Time")]
		[TestCase("Atlantic Standard Time")]
		[TestCase("Central Brazilian Standard Time")]
		[TestCase("SA Western Standard Time")]
		[TestCase("Pacific SA Standard Time")]
		[TestCase("Newfoundland Standard Time")]
		[TestCase("E. South America Standard Time")]
		[TestCase("Argentina Standard Time")]
		[TestCase("SA Eastern Standard Time")]
		[TestCase("Greenland Standard Time")]
		[TestCase("Montevideo Standard Time")]
		[TestCase("Bahia Standard Time")]
		[TestCase("UTC-02")]
		[TestCase("Mid-Atlantic Standard Time")]
		[TestCase("Azores Standard Time")]
		[TestCase("Cape Verde Standard Time")]
		[TestCase("Morocco Standard Time")]
		[TestCase("UTC")]
		[TestCase("GMT Standard Time")]
		[TestCase("Greenwich Standard Time")]
		[TestCase("W. Europe Standard Time")]
		[TestCase("Central Europe Standard Time")]
		[TestCase("Romance Standard Time")]
		[TestCase("Central European Standard Time")]
		[TestCase("W. Central Africa Standard Time")]
		[TestCase("Namibia Standard Time")]
		[TestCase("Jordan Standard Time")]
		[TestCase("GTB Standard Time")]
		[TestCase("Middle East Standard Time")]
		[TestCase("Egypt Standard Time")]
		[TestCase("Syria Standard Time")]
		[TestCase("E. Europe Standard Time")]
		[TestCase("South Africa Standard Time")]
		[TestCase("FLE Standard Time")]
		[TestCase("Turkey Standard Time")]
		[TestCase("Israel Standard Time")]
		[TestCase("Kaliningrad Standard Time")]
		[TestCase("Libya Standard Time")]
		[TestCase("Arabic Standard Time")]
		[TestCase("Arab Standard Time")]
		[TestCase("Belarus Standard Time")]
		[TestCase("Russian Standard Time")]
		[TestCase("E. Africa Standard Time")]
		[TestCase("Iran Standard Time")]
		[TestCase("Arabian Standard Time")]
		[TestCase("Azerbaijan Standard Time")]
		[TestCase("Russia Time Zone 3")]
		[TestCase("Mauritius Standard Time")]
		[TestCase("Georgian Standard Time")]
		[TestCase("Caucasus Standard Time")]
		[TestCase("Afghanistan Standard Time")]
		[TestCase("West Asia Standard Time")]
		[TestCase("Ekaterinburg Standard Time")]
		[TestCase("Pakistan Standard Time")]
		[TestCase("India Standard Time")]
		[TestCase("Sri Lanka Standard Time")]
		[TestCase("Nepal Standard Time")]
		[TestCase("Central Asia Standard Time")]
		[TestCase("Bangladesh Standard Time")]
		[TestCase("N. Central Asia Standard Time")]
		[TestCase("Myanmar Standard Time")]
		[TestCase("SE Asia Standard Time")]
		[TestCase("North Asia Standard Time")]
		[TestCase("China Standard Time")]
		[TestCase("North Asia East Standard Time")]
		[TestCase("Singapore Standard Time")]
		[TestCase("W. Australia Standard Time")]
		[TestCase("Taipei Standard Time")]
		[TestCase("Ulaanbaatar Standard Time")]
		[TestCase("Tokyo Standard Time")]
		[TestCase("Korea Standard Time")]
		[TestCase("Yakutsk Standard Time")]
		[TestCase("Cen. Australia Standard Time")]
		[TestCase("AUS Central Standard Time")]
		[TestCase("E. Australia Standard Time")]
		[TestCase("AUS Eastern Standard Time")]
		[TestCase("West Pacific Standard Time")]
		[TestCase("Tasmania Standard Time")]
		[TestCase("Magadan Standard Time")]
		[TestCase("Vladivostok Standard Time")]
		[TestCase("Russia Time Zone 10")]
		[TestCase("Central Pacific Standard Time")]
		[TestCase("Russia Time Zone 11")]
		[TestCase("New Zealand Standard Time")]
		[TestCase("UTC+12")]
		[TestCase("Fiji Standard Time")]
		[TestCase("Kamchatka Standard Time")]
		[TestCase("Tonga Standard Time")]
		[TestCase("Samoa Standard Time")]
		[TestCase("Line Islands Standard Time")]
		public void LocalToServerTime_Test(string timeZoneId)
		{
			var thisComputerTimeZone = TimeZone.CurrentTimeZone;
			var specifiedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
			var testDateTime = new DateTime(2006, 6, 12, 11, 0, 0);
			var pcUtcOffset = thisComputerTimeZone.GetUtcOffset(testDateTime);
			var timeZoneOffset = specifiedTimeZone.GetUtcOffset(testDateTime);
			var expectedTimeDifference = pcUtcOffset - timeZoneOffset;

			var expectedTime = testDateTime.LocalTimeToServerTime(timeZoneId);
			Assert.AreEqual(expectedTimeDifference, expectedTime - testDateTime);
		}

		[TestCase("2018/01/01", 1U, "2018/01/02")]
		[TestCase("2017/12/31", 1U, "2018/01/02")]
		[TestCase("2018/02/16", 1U, "2018/02/20")]
		[TestCase("2018/01/01", 251U, "2018/12/31")]
		public void AddBusinessDays_Test(string date, uint daysToAdd, string expectedResult)
		{
			var dateTime = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			var holidays = new List<DateTime>
			{
				new DateTime(2018, 1, 1), //NewYearsDay
                new DateTime(2018, 1, 15), //MartinLutherKingJrDay
                new DateTime(2018, 2, 19),//PresidentsDay
                new DateTime(2018, 5, 28),//MemorialDay
                new DateTime(2018, 7, 4),//IndependenceDay
                new DateTime(2018, 9, 4),//LaborDay
                new DateTime(2018, 10, 8),//ColumbusDay
                new DateTime(2018, 11, 12),//VeteransDay
                new DateTime(2018, 11, 22),//ThanksgivingDay
                new DateTime(2018, 12, 25)//ChristmasDay
            };

			var expectedDateTime = DateTime.ParseExact(expectedResult, "yyyy/MM/dd", CultureInfo.InvariantCulture);

			Assert.AreEqual(expectedDateTime, dateTime.AddBusinessDays(daysToAdd, holidays));

		}

		[TestCase("2018/01/01", 1U, "2018/01/02")]
		[TestCase("2017/12/31", 1U, "2018/01/02")]
		[TestCase("2018/01/01", 251U, "2018/12/31")] //See https://www.calendar-12.com/working_days/2018 for number of working days in 2018.
		public void AddBusinessDaysNoHolidayList_Test(string date, uint daysToAdd, string expectedResult)
		{
			var dateTime = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);

			var expectedDateTime = DateTime.ParseExact(expectedResult, "yyyy/MM/dd", CultureInfo.InvariantCulture);

			Assert.AreEqual(expectedDateTime, dateTime.AddBusinessDays(daysToAdd));

		}

		[Test]
		public void AddBusinessDaysNoHolidayList_ArgumentOutOfRange_Test()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DateTime.Today.AddBusinessDays(366));
		}
	}
}