using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    public class MyAppApiResult<T>
    {
        public MyAppApiResult() {
            this.HasErroes = false;
            this.Success = true;
            this.Messages = new List<string>();
            this.AllMessages = "";
        }
        public MyAppApiResult(MyAppApiResult<T> source) {
            this.HasErroes = false;
            this.Success = true;
            this.AllMessages = "";
            this.Messages = new List<string>();
            this.Data = source.Data;
        }

        public virtual T Data { get; set; }
        public virtual bool HasErroes { get; set; }
        public virtual bool Success { get; set; }
        public virtual string AllMessages { get; set; }
        //public virtual List<Exception> Errors { get; set; }
        public virtual List<string> Messages { get; set; }

        public virtual void AddError(string error) {
            Success = false;
            HasErroes = true;
            this.Messages.Add(error);
            this.AllMessages = this.AllMessages + error;
        }
        //public virtual void AddError(Exception error);
        //public virtual MyAppApiResult<TDestination> MapTo<TDestination>();
    }

    
}
