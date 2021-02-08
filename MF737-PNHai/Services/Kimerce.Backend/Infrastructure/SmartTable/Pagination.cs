namespace Kimerce.Backend.Infrastructure.SmartTable
{
    public class Pagination
    {
        /// <summary>
        /// Từ
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Trang thứ
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Kích thước trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Bản ghi bắt đầu
        /// </summary>
        public int Start => (PageIndex - 1) * PageSize;

        /// <summary>
        /// Tổng số lượng bản ghi
        /// </summary>
        public int TotalItemCount { get; set; }


        public int Number { get; set; }
        public int NumberOfPages { get; set; }
    }
}