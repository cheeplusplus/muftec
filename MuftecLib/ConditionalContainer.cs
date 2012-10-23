using System;
using System.Collections.Generic;

namespace Muftec.Lib
{
    class ConditionalContainer
    {
        public Queue<MuftecStackItem> TrueQueue { get; set; }
        public Queue<MuftecStackItem> FalseQueue { get; set; }
    }
}
