using System;

namespace FastFoodOnline.Base.DTOs
{
    /// <summary>
    /// Request's Common data
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// Request reseved time to server
        /// </summary>
        public DateTime RequestedDateTime { get; }

        /// <summary>
        /// Constuctor - Initilizing required properties
        /// </summary>
        protected BaseRequest()
        {
            RequestedDateTime = DateTime.Now;
        }
    }
}
