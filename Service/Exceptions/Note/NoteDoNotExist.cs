using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.Note
{
    [Serializable]
    public class NoteDoNotExist : Exception
    {
        public NoteDoNotExist() : base("Note doesn't exists.") { }
    }
}
