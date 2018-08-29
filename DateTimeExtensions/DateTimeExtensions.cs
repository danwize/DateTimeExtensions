using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Nager.Date;

namespace DateTimeExtensions
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Converts a utc time to local time based on the time zone name
		/// </summary>
		/// <param name="utcDate"></param>
		/// <param name="timeZoneName">The time zone id.  This must be a valid Windows system date time id.
		///Dateline Standard Time
		///UTC-11
		///Hawaiian Standard Time
		///Alaskan Standard Time
		///Pacific Standard Time (Mexico)
		///Pacific Standard Time
		///US Mountain Standard Time
		///Mountain Standard Time (Mexico)
		///Mountain Standard Time
		///Central America Standard Time
		///Central Standard Time
		///Central Standard Time (Mexico)
		///Canada Central Standard Time
		///SA Pacific Standard Time
		///Eastern Standard Time
		///US Eastern Standard Time
		///Venezuela Standard Time
		///Paraguay Standard Time
		///Atlantic Standard Time
		///Central Brazilian Standard Time
		///SA Western Standard Time
		///Pacific SA Standard Time
		///Newfoundland Standard Time
		///E. South America Standard Time
		///Argentina Standard Time
		///SA Eastern Standard Time
		///Greenland Standard Time
		///Montevideo Standard Time
		///Bahia Standard Time
		///UTC-02
		///Mid-Atlantic Standard Time
		///Azores Standard Time
		///Cape Verde Standard Time
		///Morocco Standard Time
		///UTC
		///GMT Standard Time
		///Greenwich Standard Time
		///W. Europe Standard Time
		///Central Europe Standard Time
		///Romance Standard Time
		///Central European Standard Time
		///W. Central Africa Standard Time
		///Namibia Standard Time
		///Jordan Standard Time
		///GTB Standard Time
		///Middle East Standard Time
		///Egypt Standard Time
		///Syria Standard Time
		///E. Europe Standard Time
		///South Africa Standard Time
		///FLE Standard Time
		///Turkey Standard Time
		///Israel Standard Time
		///Kaliningrad Standard Time
		///Libya Standard Time
		///Arabic Standard Time
		///Arab Standard Time
		///Belarus Standard Time
		///Russian Standard Time
		///E. Africa Standard Time
		///Iran Standard Time
		///Arabian Standard Time
		///Azerbaijan Standard Time
		///Russia Time Zone 3
		///Mauritius Standard Time
		///Georgian Standard Time
		///Caucasus Standard Time
		///Afghanistan Standard Time
		///West Asia Standard Time
		///Ekaterinburg Standard Time
		///Pakistan Standard Time
		///India Standard Time
		///Sri Lanka Standard Time
		///Nepal Standard Time
		///Central Asia Standard Time
		///Bangladesh Standard Time
		///N. Central Asia Standard Time
		///Myanmar Standard Time
		///SE Asia Standard Time
		///North Asia Standard Time
		///China Standard Time
		///North Asia East Standard Time
		///Singapore Standard Time
		///W. Australia Standard Time
		///Taipei Standard Time
		///Ulaanbaatar Standard Time
		///Tokyo Standard Time
		///Korea Standard Time
		///Yakutsk Standard Time
		///Cen. Australia Standard Time
		///AUS Central Standard Time
		///E. Australia Standard Time
		///AUS Eastern Standard Time
		///West Pacific Standard Time
		///Tasmania Standard Time
		///Magadan Standard Time
		///Vladivostok Standard Time
		///Russia Time Zone 10
		///Central Pacific Standard Time
		///Russia Time Zone 11
		///New Zealand Standard Time
		///UTC+12
		///Fiji Standard Time
		///Kamchatka Standard Time
		///Tonga Standard Time
		///Samoa Standard Time
		///Line Islands Standard Time
		/// </param>
		/// <returns></returns>
		public static DateTime Local(this DateTime utcDate, string timeZoneName)
		{
			var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
			return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tzi);
		}

		public static DateTime? Local(this DateTime? utcDate, string timeZoneName)
		{
			return utcDate?.Local(timeZoneName);
		}

		public static DateTime ToUniversalTime(this DateTime localTime, string localTimeZoneName)
		{
			var localTzi = TimeZoneInfo.FindSystemTimeZoneById(localTimeZoneName);
			return TimeZoneInfo.ConvertTimeToUtc(localTime, localTzi);
		}

		public static DateTime? ToUniversalTime(this DateTime? localTime, string localTimeZoneName)
		{
			return localTime?.ToUniversalTime(localTimeZoneName);
		}

		public static DateTime ServerTimeToLocalTime(this DateTime serverTime, string timeZoneId)
		{

			var serverTimeZone = TimeZone.CurrentTimeZone;
			var dateTimeInUtc = serverTimeZone.ToUniversalTime(serverTime);
			return dateTimeInUtc.Local(timeZoneId);
		}

		public static string ServerTimeToLocalTime(this string serverTime, string timeZoneId, string formatToReturn = "M/dd/yyyy h:mm tt")
		{
			return DateTime.Parse(serverTime).ToString(formatToReturn);
		}

		public static DateTime LocalTimeToServerTime(this DateTime localTime, string timeZoneName)
		{

			var serverTimeZone = TimeZone.CurrentTimeZone;
			var dateTimeInUtc = localTime.ToUniversalTime(timeZoneName);
			return serverTimeZone.ToLocalTime(dateTimeInUtc);
		}

		public static string LocalTimeToServerTime(this string localTime, string timeZoneName, string formatToReturn = "M/dd/yyyy h:mm tt")
		{
			return DateTime.Parse(localTime).ToString(formatToReturn);
		}

		public static DateTime AddBusinessDays(this DateTime date, [Range(uint.MinValue, 365)]uint daysToAdd)
		{
			if (daysToAdd > 365)
			{
				throw new ArgumentOutOfRangeException(nameof(daysToAdd));
			}
			var holidays = DateSystem.GetPublicHoliday(CountryCode.US, date, date.AddYears(1)).Select(x => x.Date);
			return AddBusinessDays(date, daysToAdd, holidays);
		}


		public static DateTime AddBusinessDays(this DateTime date, uint daysToAdd, IEnumerable<DateTime> holidays)
		{
			var holidaysList = holidays.ToList(); //use as list to avoid multiple enumerations.
			for (var i = 0; i < daysToAdd; i++)
			{
				switch (date.DayOfWeek)
				{
					case DayOfWeek.Friday:
						date = date.AddDays(3);
						if (holidaysList.Contains(date))
						{
							date = date.AddDays(1);
						}
						break;
					default:
						date = date.AddDays(1);
						if (holidaysList.Contains(date))
						{
							date = date.AddDays(date.DayOfWeek == DayOfWeek.Friday ? 3 : 1);
						}
						break;
				}
			}
			return date;
		}
	}
}