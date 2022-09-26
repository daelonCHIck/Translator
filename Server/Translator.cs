using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Переводчик.Server
{
    public partial class Translator
    {
        public int LanguageId { get; set; }
        public string Rus { get; set; }
        public string Eng { get; set; }
        public string Deu { get; set; }
        public string Chin { get; set; }
        public string Jap { get; set; }
        public string Corea { get; set; }
    }
}
