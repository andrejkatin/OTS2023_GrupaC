using System;


namespace OTS2023_GrupaC.Exceptions
{
    public class LocationOutsideOfMapException: Exception
    {
        public LocationOutsideOfMapException()
        {

        }

        public LocationOutsideOfMapException(string message) : base(message)
        {

        }
    }
}
