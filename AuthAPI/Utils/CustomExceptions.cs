namespace AltenAPI.Utils
{
    public class CustomExceptions
    {
    }

    [Serializable]
    class MissingUserInfoException : Exception
    {
        public MissingUserInfoException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }

    [Serializable]
    class BookingException : Exception
    {
        public BookingException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }


    [Serializable]
    class BookingTooLongException : Exception
    {
        public BookingTooLongException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }

    [Serializable]
    class BookingTooFarException : Exception
    {
        public BookingTooFarException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }

    [Serializable]
    class BookingForTodayException : Exception
    {
        public BookingForTodayException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }



}
