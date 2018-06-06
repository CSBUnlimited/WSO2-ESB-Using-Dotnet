﻿using System;

namespace FastFoodOnline.Base.DTOs
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public DateTime RespondDateTime { get; set; }

        protected BaseResponse()
        {
            RespondDateTime = DateTime.Now;
        }
    }
}
