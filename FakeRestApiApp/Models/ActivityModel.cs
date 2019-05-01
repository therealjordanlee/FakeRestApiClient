using System;

namespace FakeRestApiApp.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
