using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystemMessage.Common
{
    public static class Constants
    {
        //Query
        public static string QRY_AREAS = "SELECT Area from Messages GROUP BY Area";
        public static string QRY_SYSTEMS = "SELECT Source from Messages GROUP BY Source";

        //Strings
        public static string EMPTY = "";
        public static string SELECT_PLANT_AREA = "Select Plant Area";
        public static string SELECT_SYSTEM = "Select System";
    }
}
