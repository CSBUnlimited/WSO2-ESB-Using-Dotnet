using System;
using System.ComponentModel.DataAnnotations;

namespace FastFoodOnline.Base.DTOs
{
    public abstract class BaseRequest
    {
        public DateTime RequestedDateTime { get; }

        protected BaseRequest()
        {
            RequestedDateTime = DateTime.Now;
        }
    }
}
