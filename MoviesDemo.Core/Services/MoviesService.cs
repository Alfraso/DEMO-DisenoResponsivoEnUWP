﻿using MoviesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoviesDemo.Core.Services
{
    public class MoviesService : IMoviesService
    {
        private IEnumerable<MovieModel> _movies;

        public async Task<IEnumerable<MovieModel>> GetMovies()
        {
            if (_movies == null)
            {
                string xml;
                using (var client = new HttpClient())
                {
                    xml = await client.GetStringAsync("http://www.apple.com/trailers/home/xml/current.xml");
                }

                _movies = ProcessMoviesXml(xml);
            }

            return _movies;
        }

        private IEnumerable<MovieModel> ProcessMoviesXml(string xml)
        {
            var doc = XDocument.Parse(xml);

            return doc.Descendants("movieinfo").Select(s =>
            {
                var info = s.Element("info");
                var poster = s.Element("poster");
                var genre = s.Element("genre");
                var cast = s.Element("cast");

                return new MovieModel()
                {
                    Id = uint.Parse(s.Attribute("id").Value),
                    Title = info.Element("title").Value,
                    Runtime = info.Element("runtime").Value,
                    Director = info.Element("director").Value,
                    RelaseDate = info.Element("releasedate").Value,
                    Genre = string.Join(", ", genre.Elements().Select(g => g.Value)),
                    Cast = string.Join(", ", cast.Elements().Select(g => g.Value)),
                    Description = info.Element("description").Value,
                    Poster = poster.Element("location").Value,
                    LargePoster = poster.Element("xlarge").Value
                };
            });
        }
    }
}
