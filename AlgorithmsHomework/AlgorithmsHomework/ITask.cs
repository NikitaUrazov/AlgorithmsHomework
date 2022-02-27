using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    interface ITask
    {
        public int TaskID { get; }

        public string TaskName { get; }

        public void ShowResult();
    }
}
