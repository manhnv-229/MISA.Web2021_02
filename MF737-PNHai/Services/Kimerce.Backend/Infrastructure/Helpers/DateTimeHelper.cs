using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Kimerce.Backend.Infrastructure.Helpers
{
    public static class DateTimeHelper
    {

        public static DateTimeOffset StartOfDay(this DateTimeOffset theDate)
        {
            return theDate.Date;
        }

        public static DateTimeOffset EndOfDay(this DateTimeOffset theDate)
        {
            return theDate.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime StartOfDay(this DateTime theDate)
        {
            return theDate.Date;
        }


        public static DateTime EndOfDay(this DateTime theDate)
        {
            return theDate.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTimeOffset StartOfDayForAzure(this DateTimeOffset theDate)
        {
            return theDate.Date.AddHours(-7);
        }

        public static DateTimeOffset EndOfDayForAzure(this DateTimeOffset theDate)
        {
            return theDate.Date.AddDays(1).AddHours(-7).AddTicks(-1);
        }
        public static DateTime StartOfDayForAzure(this DateTime theDate)
        {
            return theDate.Date.AddHours(-7);
        }

        public static DateTime EndOfDayForAzure(this DateTime theDate)
        {
            return theDate.Date.AddDays(1).AddHours(-7).AddTicks(-1);
        }


        //public static double GetBusinessDays(DateTimeOffset startD, DateTimeOffset endD)
        //{
        //    double calcBusinessDays =
        //        1 + ((endD - startD).TotalDays * 5 -
        //             (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

        //    //if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
        //    if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

        //    return calcBusinessDays;
        //}

        //public static int GetBusinessDays(DateTimeOffset from, DateTimeOffset to)
        //{
        //    var dayDifference = (int)to.Subtract(from).TotalDays;
        //    return Enumerable
        //        .Range(1, dayDifference)
        //        .Select(x => from.AddDays(x))
        //        .Count(x => x.DayOfWeek != DayOfWeek.Sunday);
        //}

        public static int GetBusinessDays(DateTimeOffset endDate, DateTimeOffset startDate)
        {
            int count = 0;
            endDate = endDate.StartOfDay();
            startDate = startDate.EndOfDay();
            var arrayOfHolidays = new List<DateTime>();
            var year = DateTime.Now.Date.Year;
            arrayOfHolidays.Add(new DateTime(year, 04, 30));
            arrayOfHolidays.Add(new DateTime(year, 05, 01));
            arrayOfHolidays.Add(new DateTime(year, 09, 02));
            arrayOfHolidays.Add(new DateTime(year, 01, 01));
            arrayOfHolidays.Add(new DateTime(year + 1, 01, 01));
            while (DateTimeOffset.Compare(startDate, endDate) <= 0)
            {
                string holiday = (from date in arrayOfHolidays where DateTime.Compare(startDate.Date, date.Date) == 0 select "Holiday").FirstOrDefault();

                if (startDate.DayOfWeek == DayOfWeek.Sunday || holiday == "Holiday")
                {
                    count++;
                    startDate = startDate.AddDays(1);
                }
                else
                    startDate = startDate.AddDays(1);
            }
            return count;
        }

        public static int GetDplus(DateTimeOffset endDate, DateTimeOffset startDate)
        {
            int dplus = 0;
            endDate = endDate.StartOfDay();
            startDate = startDate.EndOfDay();
            if (DateTimeOffset.Compare(startDate, endDate) == 0)
            {
                return 0;
            }
            var numberOfHolidays = GetBusinessDays(endDate, startDate);
            while (DateTimeOffset.Compare(startDate, endDate) <= 0)
            {
                dplus += 1;
                startDate = startDate.AddDays(1);
            }
            if (numberOfHolidays > 0)
            {
                dplus = dplus - numberOfHolidays;
            }
            return dplus;
        }


        public static bool IsWorkingDays(DateTimeOffset date, int year)
        {
            var listHolidays = new List<DateTime>();
            listHolidays.Add(new DateTime(year, 04, 30));
            listHolidays.Add(new DateTime(year, 05, 01));
            listHolidays.Add(new DateTime(year, 09, 02));
            listHolidays.Add(new DateTime(year, 01, 01));
            listHolidays.Add(new DateTime(year + 1, 01, 01));
            foreach (var item in listHolidays)
            {
                if (DateTime.Compare(date.Date, item.Date) == 0)
                {
                    return true;
                }
            }
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        public static bool IsApplyFixedSalary(DateTimeOffset startWorkDate, DateTimeOffset currentSalaryMonth)
        {
            // 1 -> 15/11/2019 => hưởng 2 tháng 11, 12/2019
            // 16 -> cuối tháng hưởng 3 tháng 11,12,1
            // 1/7/2019 -> 31/10/2019 hưởng hết tháng 12/2019
            DateTimeOffset startApplyDate = new DateTimeOffset(2019, 7, 1, 0, 0, 0, new TimeSpan(1, 0, 0)).StartOfDay();
            DateTime endApplyDate = new DateTime(2019, 10, DateTime.DaysInMonth(2019, 10)).EndOfDay();
            if (startWorkDate >= startApplyDate)
            {
                DateTimeOffset maxApplyMonth = startWorkDate;
                if (startWorkDate <= endApplyDate) // nhỏ hơn 1/11/2019
                    maxApplyMonth = new DateTimeOffset(2019, 12, 31, 23, 59, 59, new TimeSpan(1, 0, 0)).EndOfDay();
                else // lớn hơn 1/11/2019
                {
                    if (startWorkDate.Day > 15)
                    {
                        DateTimeOffset newMaxApplyMonth = maxApplyMonth.AddMonths(2).EndOfDay();
                        maxApplyMonth = new DateTime(newMaxApplyMonth.Year, newMaxApplyMonth.Month, DateTime.DaysInMonth(newMaxApplyMonth.Year, newMaxApplyMonth.Month)).EndOfDay();
                    }
                    else
                    {
                        DateTimeOffset newMaxApplyMonth = maxApplyMonth.AddMonths(1).EndOfDay();
                        maxApplyMonth = new DateTime(newMaxApplyMonth.Year, newMaxApplyMonth.Month, DateTime.DaysInMonth(newMaxApplyMonth.Year, newMaxApplyMonth.Month)).EndOfDay();
                    }
                }
                if (currentSalaryMonth <= maxApplyMonth)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static string GetLeadTime(DateTimeOffset endDate, DateTimeOffset startDate)
        {
            string leadtime = "";
            var betweenTime = new TimeSpan();

            // Nếu startDate, endDate cùng 1 ngày và vào ngày chủ nhật/lễ
            if (endDate.Date == startDate.Date && IsWorkingDays(startDate, startDate.Year))
            {
                betweenTime = endDate.Subtract(startDate);
            }
            else
            {
                // Nếu startDate vào chủ nhật/lễ thì startDate sẽ được tính từ 7h sáng hôm sau của ngày chủ nhật/lễ đó 
                if (IsWorkingDays(startDate, startDate.Year))
                {
                    var newDate = startDate.EndOfDay().AddHours(7).AddMinutes(0).AddSeconds(01);
                    betweenTime = endDate.Subtract(newDate);
                }
                else
                    betweenTime = endDate.Subtract(startDate);

                // Nếu endDate là ngày lễ thì trừ đi số thời gian của endDate
                //if (IsWorkingDays(endDate, endDate.Year))
                //{
                //    betweenTime = betweenTime.Subtract(new TimeSpan(0, endDate.Hour, endDate.Minute, endDate.Second));
                //}

                // Lặp trong khoảng startDate và endDate để trừ đi ngày lễ
                DateTimeOffset dateIndex = startDate.AddDays(1);
                for (var day = startDate.AddDays(1).Date; day.Date <= endDate.AddDays(-1).Date; day = day.AddDays(1))
                {
                    if (IsWorkingDays(dateIndex, startDate.Year))
                    {
                        betweenTime = betweenTime.Add(new TimeSpan(-1, 00, 00, 00));
                    }
                    dateIndex = dateIndex.AddDays(1);
                }
            }

            if (betweenTime.Days < 0 || betweenTime.Hours < 0)
            {
                leadtime = "";
            }
            else
            {
                leadtime = betweenTime.TotalDays.ToString("F", new CultureInfo("en-US"));
            }

            return leadtime;
        }

        public static double GetLeadTimeDouble(DateTimeOffset endDate, DateTimeOffset startDate)
        {
            double leadtime = 0;
            var betweenTime = new TimeSpan();

            // Nếu startDate, endDate cùng 1 ngày và vào ngày chủ nhật/lễ
            if (endDate.Date == startDate.Date && IsWorkingDays(startDate, startDate.Year))
            {
                betweenTime = endDate.Subtract(startDate);
            }
            else
            {
                // Nếu startDate vào chủ nhật/lễ thì startDate sẽ được tính từ 7h sáng hôm sau của ngày chủ nhật/lễ đó 
                if (IsWorkingDays(startDate, startDate.Year))
                {
                    var newDate = startDate.EndOfDay().AddHours(7).AddMinutes(0).AddSeconds(01);
                    betweenTime = endDate.Subtract(newDate);
                }
                else
                    betweenTime = endDate.Subtract(startDate);

                // Nếu endDate là ngày lễ thì trừ đi số thời gian của endDate
                //if (IsWorkingDays(endDate, endDate.Year))
                //{
                //    betweenTime = betweenTime.Subtract(new TimeSpan(0, endDate.Hour, endDate.Minute, endDate.Second));
                //}

                // Lặp trong khoảng startDate và endDate để trừ đi ngày lễ
                DateTimeOffset dateIndex = startDate.AddDays(1);
                for (var day = startDate.AddDays(1).Date; day.Date <= endDate.AddDays(-1).Date; day = day.AddDays(1))
                {
                    if (IsWorkingDays(dateIndex, startDate.Year))
                    {
                        betweenTime = betweenTime.Add(new TimeSpan(-1, 00, 00, 00));
                    }
                    dateIndex = dateIndex.AddDays(1);
                }
            }

            if (betweenTime.Days < 0 || betweenTime.Hours < 0)
            {
                leadtime = 0;
            }
            else
            {
                leadtime = betweenTime.TotalDays;
            }

            return leadtime;
        }

        public static double GetLeadTimeDoubleFrom00(DateTimeOffset endDate, DateTimeOffset startDate)
        {
            double leadtime = 0;
            var betweenTime = new TimeSpan();

            // Nếu startDate, endDate cùng 1 ngày và vào ngày chủ nhật/lễ
            if (endDate.Date == startDate.Date && IsWorkingDays(startDate, startDate.Year))
            {
                betweenTime = endDate.Subtract(startDate);
            }
            else
            {
                // Nếu startDate vào chủ nhật/lễ thì startDate sẽ được tính từ 7h sáng hôm sau của ngày chủ nhật/lễ đó 
                if (IsWorkingDays(startDate, startDate.Year))
                {
                    var newDate = startDate.EndOfDay().AddHours(0).AddMinutes(0).AddSeconds(01);
                    betweenTime = endDate.Subtract(newDate);
                }
                else
                    betweenTime = endDate.Subtract(startDate);

                // Nếu endDate là ngày lễ thì trừ đi số thời gian của endDate
                //if (IsWorkingDays(endDate, endDate.Year))
                //{
                //    betweenTime = betweenTime.Subtract(new TimeSpan(0, endDate.Hour, endDate.Minute, endDate.Second));
                //}

                // Lặp trong khoảng startDate và endDate để trừ đi ngày lễ
                DateTimeOffset dateIndex = startDate.AddDays(1);
                for (var day = startDate.AddDays(1).Date; day.Date <= endDate.AddDays(-1).Date; day = day.AddDays(1))
                {
                    if (IsWorkingDays(dateIndex, startDate.Year))
                    {
                        betweenTime = betweenTime.Add(new TimeSpan(-1, 00, 00, 00));
                    }
                    dateIndex = dateIndex.AddDays(1);
                }
            }

            if (betweenTime.Days < 0 || betweenTime.Hours < 0)
            {
                leadtime = 0;
            }
            else
            {
                leadtime = betweenTime.TotalDays;
            }

            return leadtime;
        }

        public static int GetDplusInDc(DateTimeOffset startDate, DateTimeOffset? endDate, int orderStatus)
        {
            int dplus = 0;
            int year = startDate.Year;
            if (orderStatus == 15 && endDate != null)
            {
                DateTimeOffset date = startDate;
                DateTimeOffset dateIndex = startDate;
                for (var day = startDate.Date; day.Date <= endDate.Value.Date; day = day.AddDays(1))
                {
                    if (!IsWorkingDays(dateIndex, year))
                    {
                        dplus++;
                    }
                    if (IsWorkingDays(dateIndex, year) && startDate.Date == endDate.Value.Date)
                    {
                        dplus++;
                    }
                    dateIndex = dateIndex.AddDays(1);
                }
            }
            else
            {
                DateTimeOffset date = startDate;
                DateTimeOffset dateIndex = startDate;
                for (var day = startDate.Date; day.Date <= DateTimeOffset.Now.Date; day = day.AddDays(1))
                {
                    if (!IsWorkingDays(dateIndex, year))
                    {
                        dplus++;
                    }
                    if (IsWorkingDays(dateIndex, year) && startDate.Date == DateTimeOffset.Now.Date)
                    {
                        dplus++;
                    }
                    dateIndex = dateIndex.AddDays(1);
                }
            }
            //Nếu thời gian nhận hàng vào DC phát lớn hơn 10h
            int receiveHour = startDate.TimeOfDay.Hours;
            if (receiveHour >= 10)
            {
                dplus = dplus - 1;
            }
            return dplus;
        }
        public static int GetDplus2(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            int dplus = 0;
            DateTimeOffset dateIndex = startDate.Value;
            int year = startDate.Value.Year;
            for (var day = startDate.Value.Date; day.Date <= endDate.Value.Date; day = day.AddDays(1))
            {
                if (!IsWorkingDays(dateIndex, year))
                {
                    dplus++;
                }
                if (startDate.Value.Date == endDate.Value.Date && IsWorkingDays(dateIndex, year))
                {
                    dplus++;
                }
                dateIndex = dateIndex.AddDays(1);
            }

            return dplus;
        }

        public static DateTimeOffset GetReceiveDateLeadTime(DateTimeOffset receiveDate)
        {
            var receiveDateLT = new DateTimeOffset();
            if (receiveDate.Hour >= 17)
                receiveDateLT = receiveDate.EndOfDay().AddHours(7).AddMinutes(0).AddSeconds(01);
            else if (receiveDate.Hour <= 7)
                receiveDateLT = receiveDate.StartOfDay().AddHours(7).AddMinutes(0).AddSeconds(01);
            else
                receiveDateLT = receiveDate;

            return receiveDateLT;
        }
    }
}
