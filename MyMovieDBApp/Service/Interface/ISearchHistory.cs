using MyMovieDBApp.Models;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service.Interface
{
    public interface ISearchHistory
    {
        IEnumerable<SearchHistory> GetSearchHistory();

        SearchHistory GetSearchHistory(int id);

        SearchHistory CreateSearchHistory(SearchHistory SearchHistory);

        void DeleteSearchHistory(int SearchHistoryId);
    }
}
