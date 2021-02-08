using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Success = true;
        }

        public ResponseModel(Exception exception)
            : this()
        {
            Success = false;
            var innerEx = exception;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }

            Message = innerEx.Message;
        }

        #region Public Properties

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        #endregion
    }
}
