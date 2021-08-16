using System;
using System.Collections.Generic;
using System.Text;

namespace MoodApp.Model
{
    public class Mood
    {
        public string mood { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string extras { get; set; }
    }

    public class MoodList
    {
        public List<Mood>  moods { get; set; }
    }
}
