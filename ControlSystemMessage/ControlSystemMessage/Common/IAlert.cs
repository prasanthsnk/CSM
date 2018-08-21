using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystemMessage.Common
{
    public interface IAlert
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
