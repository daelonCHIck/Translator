using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Переводчик.Server
{
    public partial class Translation
    {
        public Translation()
        {
            JournalLangFromNavigation = new HashSet<Journal>();
            JournalLangToNavigation = new HashSet<Journal>();
        }

        public int LanguageId { get; set; }
        public string LangName { get; set; }

        public virtual ICollection<Journal> JournalLangFromNavigation { get; set; }
        public virtual ICollection<Journal> JournalLangToNavigation { get; set; }
    }
}
