using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddError = "The object couldn't add to the sytem."; 
        public static string AddSuccess = "The object have been added to the system.";
        public static string DeleteError = "The object haven't been deleted from the system.";
        public static string DeleteSuccess = "The object have been deleted from the system.";
        public static string MaintenanceTime = "In these our the system in MaintenanceTime";
        public static string IsNull = "The object is not exist";
        public static string UpdateError = "The object couldn't Update.";
        public static string UpdateSuccess = "The Object Updated successfully";
        public static string ReturnCar = "The car has been returned";
    }

}
