﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Nager.Date;
using TimeZoneConverter;

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
            var tzi = TZConvert.GetTimeZoneInfo(timeZoneName);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tzi);
        }

        public static DateTime Local(this DateTime utcDate, SystemTimeZone systemTimeZone)
        {
            return Local(utcDate, systemTimeZone.ToString());
        }

        public static DateTime? Local(this DateTime? utcDate, string timeZoneName)
        {
            return utcDate?.Local(timeZoneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utcDate">The date time in UTC to convert to local.</param>
        /// <param name="localTimeZone">The time zone to convert to.</param>
        /// <returns></returns>
        public static DateTime? Local(this DateTime? utcDate, SystemTimeZone localTimeZone)
        {
            return utcDate?.Local(localTimeZone);
        }

        public static DateTime ToUniversalTime(this DateTime localTime, string localTimeZoneName, DateTimeKind? localTimeType = null)
        {
            var localTzi = TZConvert.GetTimeZoneInfo(localTimeZoneName);
            if (localTimeType != null)
            {
                localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Unspecified);
            }
            return TimeZoneInfo.ConvertTimeToUtc(localTime, localTzi);
        }

        public static DateTime ToUniversalTime(this DateTime localTime, SystemTimeZone localTimeZone)
        {
            return ToUniversalTime(localTime, localTimeZone.ToString());
        }

        public static DateTime? ToUniversalTime(this DateTime? localTime, string localTimeZoneName)
        {
            return localTime?.ToUniversalTime(localTimeZoneName);
        }


        public static DateTime? ToUniversalTime(this DateTime? localTime, SystemTimeZone localTimeZone)
        {
            return localTime?.ToUniversalTime(localTimeZone.ToString());
        }

        public static DateTime ServerTimeToLocalTime(this DateTime serverTime, string timeZoneId)
        {

            var serverTimeZone = TimeZone.CurrentTimeZone; //TODO:  TimeZone is obsolete.  Look into using the new class.
            var dateTimeInUtc = serverTimeZone.ToUniversalTime(serverTime);
            return dateTimeInUtc.Local(timeZoneId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverTime"></param>
        /// <param name="localTimeZone"></param>
        /// <example>
        /// var localTimeZone = SystemTimeZone.DateLineStandardTime;
        /// var serverTime = DateTime.Now;
        /// var localTime = serverTime.ServerTimeToLocalTime(localTimeZone);</example>
        /// <returns></returns>
        public static DateTime ServerTimeToLocalTime(this DateTime serverTime, SystemTimeZone localTimeZone)
        {
            return ServerTimeToLocalTime(serverTime, localTimeZone.ToString());
        }

        public static string ServerTimeToLocalTime(this string serverTime, string timeZoneName, string formatToReturn = "M/dd/yyyy h:mm tt")
        {
            return DateTime.Parse(serverTime).ServerTimeToLocalTime(timeZoneName).ToString(formatToReturn);
        }

        public static string ServerTimeToLocalTime(this string serverTime, SystemTimeZone localTimeZone, string formatToReturn = "M/dd/yyyy h:mm tt")
        {
            return DateTime.Parse(serverTime).ServerTimeToLocalTime(localTimeZone).ToString(formatToReturn);
        }

        public static DateTime LocalTimeToServerTime(this DateTime localTime, string timeZoneName)
        {

            var serverTimeZone = TimeZone.CurrentTimeZone;
            var dateTimeInUtc = localTime.ToUniversalTime(timeZoneName);
            return serverTimeZone.ToLocalTime(dateTimeInUtc);
        }

        public static DateTime LocalTimeToServerTime(this DateTime localTime, SystemTimeZone serverTimeZone)
        {
            return LocalTimeToServerTime(localTime, serverTimeZone.ToString());
        }

        public static string LocalTimeToServerTime(this string localTime, string serverTimeZoneName, string formatToReturn = "M/dd/yyyy h:mm tt")
        {
            return DateTime.Parse(localTime).LocalTimeToServerTime(serverTimeZoneName).ToString(formatToReturn);
        }

        public static string LocalTimeToServerTime(this string localTime, SystemTimeZone serverTimeZone, string formatToReturn = "M/dd/yyyy h:mm tt")
        {
            return DateTime.Parse(localTime).LocalTimeToServerTime(serverTimeZone).ToString(formatToReturn);
        }

        public static DateTime ToNewTimeZone(this DateTime @this, SystemTimeZone fromTimeZone, SystemTimeZone toTimeZone)
        {
            return @this.ToNewTimeZone(fromTimeZone.ToString(), toTimeZone.ToString());
        }

        public static DateTime ToNewTimeZone(this DateTime @this, string fromTimeZone, string toTimeZone)
        {
            // var serverTimeZone = TimeZone.CurrentTimeZone; //TODO:  TimeZone is obsolete.  Look into using the new class.
            // var dateTimeInUtc = serverTimeZone.ToUniversalTime(serverTime);
            var universalTime = @this.ToUniversalTime(fromTimeZone, DateTimeKind.Unspecified);
            var destinationTimeZone = TZConvert.GetTimeZoneInfo(toTimeZone);
            return TimeZoneInfo.ConvertTime(universalTime, destinationTimeZone);
        }

        public static string ToNewTimeZone(this string @this, string fromTimeZone, string toTimeZone, string formatToReturn = "M/dd/yyyy h:mm tt")
        {
            return DateTime.Parse(@this).ToNewTimeZone(fromTimeZone, toTimeZone).ToString(formatToReturn);
        }

        /// <summary>
        /// Calculates the offset from UTC of the specified date where date is of the time zone specified in dateTimeZone
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        public static TimeSpan GetUtcOffset(this DateTime date, SystemTimeZone dateTimeZone)
        {
            return GetUtcOffset(date, dateTimeZone.ToString());
        }

        public static TimeSpan GetUtcOffset(this DateTime date, string dateTimeZoneName)
        {
            var tzi = TZConvert.GetTimeZoneInfo(dateTimeZoneName);
            return tzi.GetUtcOffset(date);
        }

        public static int GetUtcOffsetInteger(this DateTime date, string dateTimeZoneName)
        {
            return GetUtcOffset(date, dateTimeZoneName).Hours;
        }

        public static int GetUtcOffsetInteger(this DateTime date, SystemTimeZone dateTimeZone)
        {
            return GetUtcOffsetInteger(date, dateTimeZone.ToString());
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