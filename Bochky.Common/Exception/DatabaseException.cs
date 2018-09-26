using System;


namespace BochkyLink.Common.Exception
{
    /// <summary>
    /// Исключение уровня базы данных
    /// </summary>
    public class DatabaseException : System.Exception
    {
        public DatabaseException() : base("Произошла ошибка при обращении к базе данных") { }
        public DatabaseException(string message) : base(message) { }
    }
}
