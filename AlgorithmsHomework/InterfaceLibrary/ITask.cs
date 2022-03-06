using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    public interface ITask
    {
        int TaskID { get; }

        string TaskName { get; }

        void ShowResult();
    }
}
