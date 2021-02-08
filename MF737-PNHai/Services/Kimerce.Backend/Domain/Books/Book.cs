using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Domain.Books
{
    /// <summary>
    /// 1 Bảng trong Db thứ 2 có tên book 
    /// </summary>
    public class Book
    {
        
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        
        public int? CreatorUserId { get; set; }

        public int? LastModifierUserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Single Price { get; set; }

        public DateTime PublisgDate { get; set; }


    }
}
