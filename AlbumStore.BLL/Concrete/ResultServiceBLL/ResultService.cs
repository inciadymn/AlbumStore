using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumStore.BLL.Concrete.ResultServiceBLL
{
    public class ResultService<T>
    {
        //burayı biz yazdık  //hata yönetimini yaptık 
        public ResultService()
        {
            Errors = new List<ErrorItem>();//hata sepetim oldu. eğer bu nesne newlenirse sepetim oluşmuş olacak ve bu sepete hatalarımı ekleyeceğim
        }        
        public bool HasError { get; set; }
        public List<ErrorItem> Errors { get; set; }
        public T Data { get; set; }

        public void AddError(string errorType, string errorMessage) 
        {
            Errors.Add(new ErrorItem { ErrorType = errorType, ErrorMessage = errorMessage });
            HasError = true;
        }
    }

    public class ErrorItem
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
