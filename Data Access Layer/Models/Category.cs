using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
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
