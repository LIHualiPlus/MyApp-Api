using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.models
{
    public class ArticalListModel
    {
        public System.Guid Id { get; set; }
        public string AritcleName { get; set; }
        public Nullable<System.Guid> AritcleAuthorId { get; set; }
        public Nullable<System.DateTime> WriteTime { get; set; }
        //public string Text { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> ChildType { get; set; }
        public string SimpleText { get; set; }
    }
}
