using System;

namespace FastFoodOnline.Base.DTOs
{
    /// <summary>
    /// Response's Common data
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// Is this a success response or not
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Status code of the response
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// If something need to inform
        /// Most of of the time this is a error message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// If there's a error, full error message
        /// </summary>
        public string MessageDetails { get; set; }
        /// <summary>
        /// Responded date time
        /// </summary>
        public DateTime RespondDateTime { get; set; }

        /// <summary>
        /// Constuctor - Initilizing required properties
        /// </summary>
        protected BaseResponse()
        {
            RespondDateTime = DateTime.Now;
        }
    }
}
