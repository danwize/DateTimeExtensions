using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Nager.Date;

namespace DateTimeExtensions
{
    public sealed class SystemTimeZone
    {
        private readonly string _windowsSystemTimeZoneName;

        public static readonly SystemTimeZone DateLineStandardTime = new SystemTimeZone("Dateline Standard Time");
        public static readonly SystemTimeZone UTCMinusEleven = new SystemTimeZone("UTC-11");
        public static readonly SystemTimeZone HawaiianStandardTime = new SystemTimeZone("Hawaiian Standard Time");
        public static readonly SystemTimeZone AlaskanStandardTime = new SystemTimeZone("Alaskan Standard Time");
        public static readonly SystemTimeZone PacificStandardTimeMexico = new SystemTimeZone("Pacific Standard Time (Mexico)");
        public static readonly SystemTimeZone PacificStandardTime = new SystemTimeZone("Pacific Standard Time");
        public static readonly SystemTimeZone MountainStandardTimeUS = new SystemTimeZone("US Mountain Standard Time");
        public static readonly SystemTimeZone MountainStandardTimeMexico = new SystemTimeZone("Mountain Standard Time (Mexico)");
        public static readonly SystemTimeZone MountainStandardTime = new SystemTimeZone("Mountain Standard Time");
        public static readonly SystemTimeZone CentralAmericaStandardTime = new SystemTimeZone("Central America Standard Time");
        public static readonly SystemTimeZone CentralStandardTime = new SystemTimeZone("Central Standard Time");
        public static readonly SystemTimeZone CentralStandardTimeMexico = new SystemTimeZone("Central Standard Time (Mexico)");
        public static readonly SystemTimeZone CentralStandardTimeCanada = new SystemTimeZone("Canada Central Standard Time");
        public static readonly SystemTimeZone SAPacificStandardTime = new SystemTimeZone("SA Pacific Standard Time");
        public static readonly SystemTimeZone EasternStandardTime = new SystemTimeZone("Eastern Standard Time");
        public static readonly SystemTimeZone EasternStandardTimeUS = new SystemTimeZone("US Eastern Standard Time");
        public static readonly SystemTimeZone VenezuelaStandardTime = new SystemTimeZone("Venezuela Standard Time");
        public static readonly SystemTimeZone ParaguayStandardTime = new SystemTimeZone("Paraguay Standard Time");
        public static readonly SystemTimeZone AtlanticStandardTime = new SystemTimeZone("Atlantic Standard Time");
        public static readonly SystemTimeZone CentralBrazilianStandardTime = new SystemTimeZone("Central Brazilian Standard Time");
        public static readonly SystemTimeZone SAWesternStandardTime = new SystemTimeZone("SA Western Standard Time");
        public static readonly SystemTimeZone PacificSAStandardTime = new SystemTimeZone("Pacific SA Standard Time");
        public static readonly SystemTimeZone NewFoundLandStandardTime = new SystemTimeZone("Newfoundland Standard Time");
        public static readonly SystemTimeZone EastSouthAmericaStandardTime = new SystemTimeZone("E. South America Standard Time");
        public static readonly SystemTimeZone ArgentinaStandardTime = new SystemTimeZone("Argentina Standard Time");
        public static readonly SystemTimeZone SAEasternStandardTime = new SystemTimeZone("SA Eastern Standard Time");
        public static readonly SystemTimeZone GreenlandStandardTime = new SystemTimeZone("Greenland Standard Time");
        public static readonly SystemTimeZone MontevideoStandardTime = new SystemTimeZone("Montevideo Standard Time");
        public static readonly SystemTimeZone BahiaStandardTime = new SystemTimeZone("Bahia Standard Time");
        public static readonly SystemTimeZone UTCMinus2 = new SystemTimeZone("UTC-02");
        public static readonly SystemTimeZone MidAtlanticStandardTime = new SystemTimeZone("Mid-Atlantic Standard Time");
        public static readonly SystemTimeZone AzoresStandardTime = new SystemTimeZone("Azores Standard Time");
        public static readonly SystemTimeZone CapeVerdeStandardTime = new SystemTimeZone("Cape Verde Standard Time");
        public static readonly SystemTimeZone MoroccoStandardTime = new SystemTimeZone("Morocco Standard Time");
        public static readonly SystemTimeZone UTC = new SystemTimeZone("UTC");
        public static readonly SystemTimeZone GMTStandardTime = new SystemTimeZone("GMT Standard Time");
        public static readonly SystemTimeZone GreenwichStandardTime = new SystemTimeZone("Greenwich Standard Time");
        public static readonly SystemTimeZone WEuropeStandardTime = new SystemTimeZone("W. Europe Standard Time");
        public static readonly SystemTimeZone CentralEuropeStandardTime = new SystemTimeZone("Central Europe Standard Time");
        public static readonly SystemTimeZone RomanceStandardTime = new SystemTimeZone("Romance Standard Time");
        public static readonly SystemTimeZone CentralEuropeanStandardTime = new SystemTimeZone("Central European Standard Time");
        public static readonly SystemTimeZone WCentralAfricaStandardTime = new SystemTimeZone("W. Central Africa Standard Time");
        public static readonly SystemTimeZone NamibiaStandardTime = new SystemTimeZone("Namibia Standard Time");
        public static readonly SystemTimeZone JordanStandardTime = new SystemTimeZone("Jordan Standard Time");
        public static readonly SystemTimeZone GTBStandardTime = new SystemTimeZone("GTB Standard Time");
        public static readonly SystemTimeZone MiddleEastStandardTime = new SystemTimeZone("Middle East Standard Time");
        public static readonly SystemTimeZone EgyptStandardTime = new SystemTimeZone("Egypt Standard Time");
        public static readonly SystemTimeZone SyriaStandardTime = new SystemTimeZone("Syria Standard Time");
        public static readonly SystemTimeZone EEuropeStandardTime = new SystemTimeZone("E. Europe Standard Time");
        public static readonly SystemTimeZone SouthAfricaStandardTime = new SystemTimeZone("South Africa Standard Time");
        public static readonly SystemTimeZone FLEStandardTime = new SystemTimeZone("FLE Standard Time");
        public static readonly SystemTimeZone TurkeyStandardTime = new SystemTimeZone("Turkey Standard Time");
        public static readonly SystemTimeZone IsraelStandardTime = new SystemTimeZone("Israel Standard Time");
        public static readonly SystemTimeZone KaliningradStandardTime = new SystemTimeZone("Kaliningrad Standard Time");
        public static readonly SystemTimeZone LibyaStandardTime = new SystemTimeZone("Libya Standard Time");
        public static readonly SystemTimeZone ArabicStandardTime = new SystemTimeZone("Arabic Standard Time");
        public static readonly SystemTimeZone ArabStandardTime = new SystemTimeZone("Arab Standard Time");
        public static readonly SystemTimeZone BelarusStandardTime = new SystemTimeZone("Belarus Standard Time");
        public static readonly SystemTimeZone RussianStandardTime = new SystemTimeZone("Russian Standard Time");
        public static readonly SystemTimeZone EAfricaStandardTime = new SystemTimeZone("E. Africa Standard Time");
        public static readonly SystemTimeZone IranStandardTime = new SystemTimeZone("Iran Standard Time");
        public static readonly SystemTimeZone ArabianStandardTime = new SystemTimeZone("Arabian Standard Time");
        public static readonly SystemTimeZone AzerbaijanStandardTime = new SystemTimeZone("Azerbaijan Standard Time");
        public static readonly SystemTimeZone RussiaTimeZone3 = new SystemTimeZone("Russia Time Zone 3");
        public static readonly SystemTimeZone MauritiusStandardTime = new SystemTimeZone("Mauritius Standard Time");
        public static readonly SystemTimeZone GeorgianStandardTime = new SystemTimeZone("Georgian Standard Time");
        public static readonly SystemTimeZone CaucasusStandardTime = new SystemTimeZone("Caucasus Standard Time");
        public static readonly SystemTimeZone AfghanistanStandardTime = new SystemTimeZone("Afghanistan Standard Time");
        public static readonly SystemTimeZone WestAsiaStandardTime = new SystemTimeZone("West Asia Standard Time");
        public static readonly SystemTimeZone EkaterinburgStandardTime = new SystemTimeZone("Ekaterinburg Standard Time");
        public static readonly SystemTimeZone PakistanStandardTime = new SystemTimeZone("Pakistan Standard Time");
        public static readonly SystemTimeZone IndiaStandardTime = new SystemTimeZone("India Standard Time");
        public static readonly SystemTimeZone SriLankaStandardTime = new SystemTimeZone("Sri Lanka Standard Time");
        public static readonly SystemTimeZone NepalStandardTime = new SystemTimeZone("Nepal Standard Time");
        public static readonly SystemTimeZone CentralAsiaStandardTime = new SystemTimeZone("Central Asia Standard Time");
        public static readonly SystemTimeZone BangladeshStandardTime = new SystemTimeZone("Bangladesh Standard Time");
        public static readonly SystemTimeZone NCentralAsiaStandardTime = new SystemTimeZone("N. Central Asia Standard Time");
        public static readonly SystemTimeZone MyanmarStandardTime = new SystemTimeZone("Myanmar Standard Time");
        public static readonly SystemTimeZone SEAsiaStandardTime = new SystemTimeZone("SE Asia Standard Time");
        public static readonly SystemTimeZone NorthAsiaStandardTime = new SystemTimeZone("North Asia Standard Time");
        public static readonly SystemTimeZone ChinaStandardTime = new SystemTimeZone("China Standard Time");
        public static readonly SystemTimeZone NorthAsiaEastStandardTime = new SystemTimeZone("North Asia East Standard Time");
        public static readonly SystemTimeZone SingaporeStandardTime = new SystemTimeZone("Singapore Standard Time");
        public static readonly SystemTimeZone WAustraliaStandardTime = new SystemTimeZone("W. Australia Standard Time");
        public static readonly SystemTimeZone TaipeiStandardTime = new SystemTimeZone("Taipei Standard Time");
        public static readonly SystemTimeZone UlaanbaatarStandardTime = new SystemTimeZone("");
        public static readonly SystemTimeZone TokyoStandardTime = new SystemTimeZone("Tokyo Standard Time");
        public static readonly SystemTimeZone KoreaStandardTime = new SystemTimeZone("Korea Standard Time");
        public static readonly SystemTimeZone YakutskStandardTime = new SystemTimeZone("Yakutsk Standard Time");
        public static readonly SystemTimeZone CenAustraliaStandardTime = new SystemTimeZone("Cen. Australia Standard Time");
        public static readonly SystemTimeZone AUSCentralStandardTime = new SystemTimeZone("AUS Central Standard Time");
        public static readonly SystemTimeZone EAustraliaStandardTime = new SystemTimeZone("E. Australia Standard Time");
        public static readonly SystemTimeZone AUSEasternStandardTime = new SystemTimeZone("");
        public static readonly SystemTimeZone WestPacificStandardTime = new SystemTimeZone("West Pacific Standard Time");
        public static readonly SystemTimeZone TasmaniaStandardTime = new SystemTimeZone("Tasmania Standard Time");
        public static readonly SystemTimeZone MagadanStandardTime = new SystemTimeZone("Magadan Standard Time");
        public static readonly SystemTimeZone VladivostokStandardTime = new SystemTimeZone("Vladivostok Standard Time");
        public static readonly SystemTimeZone RussiaTimeZone10 = new SystemTimeZone("Russia Time Zone 10");
        public static readonly SystemTimeZone CentralPacificStandardTime = new SystemTimeZone("Central Pacific Standard Time");
        public static readonly SystemTimeZone RussiaTimeZone11 = new SystemTimeZone("RussiaTimeZone11");
        public static readonly SystemTimeZone NewZealandStandardTime = new SystemTimeZone("New Zealand Standard Time");
        public static readonly SystemTimeZone UTCPlus12 = new SystemTimeZone("UTC+12");
        public static readonly SystemTimeZone FijiStandardTime = new SystemTimeZone("Fiji Standard Time");
        public static readonly SystemTimeZone KamchatkaStandardTime = new SystemTimeZone("Kamchatka Standard Time");
        public static readonly SystemTimeZone TongaStandardTime = new SystemTimeZone("Tonga Standard Time");
        public static readonly SystemTimeZone SamoaStandardTime = new SystemTimeZone("Samoa Standard Time");
        public static readonly SystemTimeZone LineIslandsStandardTime = new SystemTimeZone("Line Islands Standard Time");

        private SystemTimeZone(string windowsSystemTimeZoneName)
        {
            _windowsSystemTimeZoneName = windowsSystemTimeZoneName;
        }
    }

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