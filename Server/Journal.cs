using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Переводчик.Server
{
    public partial class Journal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int LangFrom { get; set; }
        public int LangTo { get; set; }

        public virtual Translation LangFromNavigation { get; set; }
        public virtual Translation LangToNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
