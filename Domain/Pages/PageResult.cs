using System;
using System.Collections.Generic;

namespace Domain.Pages
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPage { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public PageResult(List<T>items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;
            TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public PageResult(List<T> items, int totalCount, int itemsFrom, int itemsTo, int totalPage)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = itemsFrom;
            ItemsTo = itemsTo;
            TotalPage = totalPage;
        }


    }

  
}
