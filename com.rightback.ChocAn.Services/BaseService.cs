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
        //  subclasses should use only one instance of the db context
        protected  static ChocAnDBModel db=new ChocAnDBModel();
    }
}
