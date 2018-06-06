using System;

namespace FastFoodOnline.Resources.ViewModels
{
    public class SentEmailViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}
