using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service
{
    public class SearchHistorieservice : ISearchHistory
    {
        private UserContext _userContext;

        public SearchHistorieservice(UserContext userContext)
        {
            _userContext = userContext;
        }

        public SearchHistory CreateSearchHistory(SearchHistory SearchHistory)
        {
            _userContext.SearchHistories.Add(SearchHistory);
            _userContext.SaveChanges();
            return SearchHistory;
        }

        public void DeleteSearchHistory(int SearchHistoryId)
        {
            _userContext.SearchHistories.Remove(GetSearchHistory(SearchHistoryId));
            _userContext.SaveChanges();
        }

        public SearchHistory GetSearchHistory(int id)
        {
            return _userContext.SearchHistories.Find(id);
        }

        public IEnumerable<SearchHistory> GetSearchHistory()
        {
            return _userContext.SearchHistories;
        }
    }
}
