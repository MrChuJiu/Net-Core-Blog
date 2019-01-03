using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Blog.ViewModels
{
    public class SimpleMessage<T>
    {
        public SimpleMessage() {
            this.code = 200;
            this.Inform = "";
        }

        public void InfoMessage(string Inform) {
            this.code = 203;
            this.Inform = Inform;
        }
        public void ErrorMessage(string Inform)
        {
            //服务器错误
            this.code = 405;
            this.Inform = Inform;
            //记录人日志
        }
        public void SucceedMessage(string Inform)
        {
            this.code = 200;
            this.Inform = Inform;
        }
        public void RedirectMessage(string Inform)
        {
            this.code = 404;
            this.Inform = Inform;
        }
        public int code { get; set; }
        public string Inform { get; set; }

        public T data { get; set; }
    }
}
