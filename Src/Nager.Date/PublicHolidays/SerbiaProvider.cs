﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Serbia
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Serbia
    /// </summary>
    public class SerbiaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        public SerbiaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.RS;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Božić", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 15, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 16, "Dan državnosti Srbije", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Veliki petak", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Vaskrs (Uskrs)", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Vaskrsni (Uskrsni) ponedeljak", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Dan primirja", "Armistice Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
