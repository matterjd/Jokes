﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Jokes.Models
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string aJoke { get; set; }
    }
}
