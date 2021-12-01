using MyMovieDBApp.Models;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service.Interface
{
    public interface ISearchHistory
    {
        IEnumerable<SearchHistory> GetSearchHistory();

        SearchHistory GetSearchHistoryByKeyWord(string id);

        SearchHistory CreateSearchHistory(SearchHistory SearchHistory);
    }
}
