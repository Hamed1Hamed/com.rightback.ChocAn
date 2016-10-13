using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services
{
   public abstract class BaseService
    {

        protected ChocAnDBModel db;

        public BaseService()
        {
            this.db = new ChocAnDBModel();
        }
    }
}
