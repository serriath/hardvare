using System;

namespace Hardvare.Common.DataTransferObjects
{
    public class PagedDto<T>
    {
        public T Data { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages
        {
            get
            {
                var baseNumber = (int)Math.Floor((float)TotalRecords / PageSize);

                return TotalRecords % PageSize == 0 ? baseNumber : baseNumber + 1;
            }
        }

    }
}
