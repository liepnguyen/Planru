using Planru.Crosscutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Data
{
    public class PageResult<T>
    {
        private IEnumerable<T> _items;
        private int _pageNumber;
        private int _pageSize;
        private long _totalItems;

        public IEnumerable<T> Items { get { return _items; } }
        public int PageNumber { get { return _pageNumber; } }
        public int PageSize { get { return _pageSize; } }
        public long TotalItems { get { return _totalItems; } }

        public int TotalPages 
        {
            get { return (int)Math.Ceiling((double)TotalItems / PageSize); }
        }
        
        public PageResult(IEnumerable<T> items, int pageNumber, int pageSize, long totalItems)
        {
            _items = items;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _totalItems = totalItems;
        }

        public PageResult<TItem> ToPageResult<TItem>(ITypeAdapter typeAdapter)
        {
            var items = this.Items.Select(obj => 
                (TItem)typeAdapter.Adapt(obj, obj.GetType(), typeof(TItem)));

            var pageResult = new PageResult<TItem>(items, this.PageNumber, this.PageSize, this.TotalItems);

            return pageResult;
        }
    }
}
