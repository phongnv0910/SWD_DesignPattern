using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Category
    {
        public Category()
        {
            Styles = new HashSet<Style>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Style> Styles { get; set; }
    }
}
