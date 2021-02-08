  namespace Kimerce.Backend.Infrastructure.SmartTable
{
    /// <summary>
    /// Tham số tìm kiếm
    /// </summary>
    public class SmartTableParam
    {
        /// <summary>
        /// Phân trang
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Điều kiện tìm kiếm
        /// </summary>
        public Search Search { get; set; }

        /// <summary>
        /// Điều kiện sắp xếp
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        /// Có phải xuất dữ liệu hay không?
        /// </summary>
        public bool IsExport { get; set; } = false;

    }
}
