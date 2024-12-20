﻿using Basketball.Models;

namespace Basketball.Services
{
    public class CountryService : ICountryService
    {
        private static readonly List<Country> AllCountries = new List<Country>
        {
            new Country { Id = 1, Name = "United States" }
        };

        // get all
        public Task<List<Country>> GetAllCountries()
        {
            return Task.FromResult(AllCountries);
        }

        // get by id
        public Task<Country> GetCountry(int id)
        {
            return Task.FromResult(AllCountries.FirstOrDefault(x => x.Id == id));
        }

        // create country data
        public Task CreateCountry(Country country)
        {
            AllCountries.Add(country);
            return Task.CompletedTask;
        }

        // update
        public Task<Country?> UpdateCountry(int id, Country country)
        {
            var c = AllCountries.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                c.Name = country.Name;
            }
            return Task.FromResult(c);
        }

        // delete
        public Task DeleteCountry(int id)
        {
            var c = AllCountries.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                AllCountries.Remove(c);
            }

            return Task.CompletedTask;
        }
    }
}
