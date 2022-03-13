using System;

namespace FileManagement.Data.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
