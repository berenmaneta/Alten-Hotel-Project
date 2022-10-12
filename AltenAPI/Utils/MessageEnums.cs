using System.ComponentModel;
using System.Reflection;

namespace AltenAPI.Utils
{
    public class MessageEnums
    {
        public enum RolesEnum
        {
            Admin,
            Standard
        }

        public enum DeleteMessageEnum
        {
            [Description("Booking deleted successfully!")]
            Success = 1,
            [Description("Booking not found!")]
            NotFound = 0,
            [Description("User do not own the booking!")]
            NotAllowed = -1
        }

        public enum UpdateMessageEnum
        {
            [Description("Booking updated successfully!")]
            Success = 1,
            [Description("Booking not found!")]
            NotFound = 0,
            [Description("User do not own the booking!")]
            NotAllowed = -1
        }

        public enum CancelMessageEnum
        {
            [Description("Booking cancelled successfully!")]
            Success = 1,
            [Description("Booking not found!")]
            NotFound = 0,
            [Description("User do not own the booking!")]
            NotAllowed = -1
        }

        public enum CreateMessageEnum
        {
            [Description("Booking created successfully!")]
            Success = 1,
            [Description("Error creating the booking!")]
            NotFound = 0,
            [Description("Booking missing required information!")]
            NotAllowed = -1
        }

        public enum CreateUserMessageEnum
        {
            [Description("User created successfully!")]
            Success = 1,
            [Description("Error creating the user!")]
            NotFound = 0,
            [Description("User missing required information!")]
            NotAllowed = -1
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }
            return value.ToString();
        }

    }
}
