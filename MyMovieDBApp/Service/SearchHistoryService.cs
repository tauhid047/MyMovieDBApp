using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovieDBApp.Service
{
    public class SearchHistoryservice : ISearchHistory
    {
        private UserContext _userContext;

        public SearchHistoryservice(UserContext userContext)
        {
            _userContext = userContext;
        }

        public SearchHistory CreateSearchHistory(SearchHistory SearchHistory)
        {
            _userContext.SearchHistory.Add(SearchHistory);
            _userContext.SaveChanges();
            return SearchHistory;
        }

        public SearchHistory GetSearchHistoryByKeyWord(string keyWord)
        {
            return _userContext.SearchHistory.ToList().FirstOrDefault(x => x.KeyWord == keyWord);
        }

        public IEnumerable<SearchHistory> GetSearchHistory()
        {
            return _userContext.SearchHistory;
        }
    }
}
